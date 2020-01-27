using IAS.Domain.Core2.Bus;
using IAS.Domain.Core2.Commands;
using Inventware.Domain.Core2.Commands.CustomerCase;
using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Repositories;
using Inventware.Domain.Core2.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Inventware.Domain.Core2.CommandHandlers
{
    public class CustomerCaseCommandHandler : CommandHandlerGenericBase<CustomerCase, IUnitOfWorkForSite>,
        IRequestHandler<CreateCustomerCaseCommand, CommandResult>,
        IRequestHandler<UpdatedCustomerCaseCommand, CommandResult>,
        IRequestHandler<LogicalExclusionCustomerCaseCommand, CommandResult>
    {
        private readonly ICustomerCaseRepository _customerCaseRepository;
        private readonly ICustomerRepository _customerRepository;


        public CustomerCaseCommandHandler(ICustomerCaseRepository customerCaseRepository, ICustomerRepository 
            customerRepository, IMediatorHandler mediator, IUnitOfWorkForSite unitOfWork)
        : base(mediator, unitOfWork)
        {
            _customerCaseRepository = customerCaseRepository;
            _customerRepository = customerRepository;
        }


        public Task<CommandResult> Handle(CreateCustomerCaseCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            var customerCaseExisting = _customerCaseRepository.GetAnotherIdAndSameTitlesync(command.Id,
                command.Title).Result;
            if (customerCaseExisting != null)
            {
                NotifyCommandError("Já existe um título igual a '" + command.Title + "' para um outro case de sucesso" +
                    " criado no dia '" + command.CreatedOn.ToShortDateString() + "'.", 
                    typeof(CreateCustomerCaseCommand).ToString());
                return Response();
            }

            var customerFounded = _customerRepository.GetById(command.CustomerId);
            if (customerFounded == null)
            {
                NotifyCommandError("Não foi encontrado um cliente através de seu id, para vincular o case de sucesso.",
                    typeof(CreateCustomerCaseCommand).ToString());
                return Response();
            }

            var generatorFact = new CustomerCase(command.Id, command.Title, null, command.CreatedOn, 
                command.CreatedByApplicationUserId, command.LastUpdated, command.LastUpdatedByApplicationUserId, 
                command.IsDeleted, command.IsActive, new List<CustomerImage>(), new List<TextBlock>());

            _customerCaseRepository.Create(generatorFact);

            if (Commit())
            {
                // _bus.PublishEvent(new CreatePhysicalPersonEvent(legalPerson.Id, legalPerson.Code,
                // legalPerson.Description));
            }
            return Response();
        }


        public Task<CommandResult> Handle(UpdatedCustomerCaseCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            var existingGeneratorFact = _customerCaseRepository.GetByIdAsync(command.Id).Result;
            if (existingGeneratorFact == null)
            {
                NotifyCommandError("Não foi possível encontrar o fato gerador (evento, investimento, etc), à partir de " +
                    "seu Id, para que possa de ser atualizado.", typeof(UpdatedCustomerCaseCommand).ToString());
                return Response();
            }

            var customerFounded = _customerRepository.GetById(command.CustomerId);
            if (customerFounded == null)
            {
                NotifyCommandError("Não foi encontrado um cliente através de seu id, para vincular o case de sucesso.",
                    typeof(UpdatedCustomerCaseCommand).ToString());
                return Response();
            }

            var customerCaseExisting = _customerCaseRepository.GetAnotherIdAndSameTitlesync(command.Id,
                command.Title).Result;
            if (customerCaseExisting != null)
            {
                NotifyCommandError("Já existe um título igual a '" + command.Title + "' para um outro case de sucesso" +
                    " criado no dia '" + command.CreatedOn.ToShortDateString() + "'.",
                    typeof(UpdatedCustomerCaseCommand).ToString());
                return Response();
            }

            // Posteriormente deve ser carregado com registros persistidos no banco de dados.
            var listOfImages = new List<CustomerImage>();
            var listOfTextBlocks = new List<TextBlock>();

            var generatorFact = new CustomerCase(command.Id, command.Title, null, command.CreatedOn,
                command.CreatedByApplicationUserId, command.LastUpdated, command.LastUpdatedByApplicationUserId,
                command.IsDeleted, command.IsActive, listOfImages, listOfTextBlocks);

            _customerCaseRepository.Update(generatorFact);

            if (Commit())
            {
                //_bus.PublishEvent(new UpdatePhysicalPersonEvent(structureModel.Id, structureModel.Code,
                //    structureModel.Description));
            }

            return Response();
        }


        public Task<CommandResult> Handle(LogicalExclusionCustomerCaseCommand command, CancellationToken
            cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            var existingGeneratorFact = _customerCaseRepository.GetByIdAsync(command.Id).Result;
            if (existingGeneratorFact == null)
            {
                NotifyCommandError("Não foi possível excluir o lançamento de pagamento da pessoa jurídica, através de " +
                    "seu Id.", typeof(LogicalExclusionCustomerCaseCommand).ToString());
                return Response();
            }

            _customerCaseRepository.LogicalExclusion(existingGeneratorFact);

            if (Commit())
            {
                // _bus.PublishEvent(new LogicalExclusionLegalPersonEvent(command.Id));
            }

            return Response();
        }


        public void Dispose()
        {
            _customerCaseRepository.Dispose();
        }
    }
}
