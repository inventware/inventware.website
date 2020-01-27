using AutoMapper;
using IAS.Data.Core2.Repositories;
using IAS.Domain.Core2.Bus;
using Inventware.Application.Core._2._1.Contracts;
using Inventware.Domain.Core2.Repositories;


namespace Inventware.Application.Core._2._1.Services
{
    public class BannerAppService : IBannerAppService
    {
        private IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly IBannerRepository _bannerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;

        public BannerAppService(IMapper mapper, IBannerRepository bannerRepository,
            IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _bannerRepository = bannerRepository;
            _eventStoreRepository = eventStoreRepository;
        }


        //public async Task<BannerToDisplayInFrontEndDTO> GetById(Guid legalPersonId)
        //{
        //    var generatorFact = await _bannerRepository.GetByIdAsync(legalPersonId);
        //    return _mapper.Map<Banner, BannerToDisplayInFrontEndDTO>(generatorFact);
        //}


        //public async Task<IList<BannerToDisplayInFrontEndDTO>> GetAllActiveGeneratorFacts()
        //{
        //    var listOfGeneratorFacts = await _bannerRepository.GetAllActivesAsync();
        //    return _mapper.Map<IList<BannerToDisplayInFrontEndDTO>>(listOfGeneratorFacts);
        //}


        //public Task<CommandResult> Create(CreateBannerDTO createStructureModelDTO)
        //{
        //    var createGeneratorFactCommand = _mapper.Map<CreateBannerDTO>(createStructureModelDTO);
        //    return _bus.SendCommand(createGeneratorFactCommand);
        //}


        //public Task<CommandResult> Update(UpdateBannertDTO updateStructureModelDTO)
        //{
        //    var updateGeneratorFactCommand = _mapper.Map<UpdateBannertDTO>(updateStructureModelDTO);
        //    return _bus.SendCommand(updateGeneratorFactCommand);
        //}


        //public Task<CommandResult> LogicalExclusion(LogicalExclusionBannerDTO logicalExclusionStructureModelDTO)
        //{
        //    var logicalExclusionGeneratorFactCommand = _mapper.Map<LogicalExclusionBannerDTO>(
        //        logicalExclusionStructureModelDTO);
        //    return _bus.SendCommand(logicalExclusionGeneratorFactCommand);
        //}
    }
}
