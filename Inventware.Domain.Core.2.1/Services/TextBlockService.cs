using IAS.Domain.Core2.Services;
using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Inventware.Domain.Core2.Services
{
    public interface ITextBlockService /*: IService<Block, long>*/
    {
        Task<IEnumerable<TextBlock>> GetUndeleteAndActiveBlocks();

        Task Create(TextBlock block);

        Task Update(TextBlock block);

        Task DeleteLogical(TextBlock block);
    }





    public class TextBlockService : ServiceBase<TextBlock, Guid>, ITextBlockService
    {
        private readonly ITextBlockRepository _BlockRepository;


        public TextBlockService(ITextBlockRepository blockRepository) : base(blockRepository)
        {
            _BlockRepository = blockRepository;
        }


        public async Task<IEnumerable<TextBlock>> GetUndeleteAndActiveBlocks()
        {
            Expression<Func<TextBlock, bool>> filter = entity => entity.IsActive == true && entity.IsDeleted == false;
            var listOfBlocks = await _BlockRepository.GetAsync(filter);
            if (listOfBlocks == null || listOfBlocks.Count().Equals(0))
            {
                return new List<TextBlock>();
            }
            return listOfBlocks;
        }


        private async Task<bool> IsARepeatedCode(Guid blockId, string blockName)
        {
            Expression<Func<TextBlock, bool>> filter = entity => entity.Id == blockId && entity.Name == blockName
                && entity.IsActive == true && entity.IsDeleted == false;
            var listOfBlocks = await _BlockRepository.GetAsync(filter);
            if (listOfBlocks == null || listOfBlocks.Count().Equals(0))
            {
                return false;
            }
            return true;
        }


        public async Task Create(TextBlock block)
        {
            if (block == null){
                throw new ArgumentNullException("O Bloco de Texto não pode ser nulo.");
            }
            await CreateIfThereIsAnotherBlockWithTheSameCode(block);
        }

        private async Task CreateIfThereIsAnotherBlockWithTheSameCode(TextBlock block)
        {
            if (await IsARepeatedCode(block.Id, block.Name))
            {
                throw new Exception("Já houve um cadastro utilizando este valor para o NOME '" + block.Name +
                    "', não haver Blocos de Textos com nomes repetidos.");
            }
            await CreateAsync(block);
        }

        private async Task CreateAsync(TextBlock block)
        {
            try
            {
                _BlockRepository.Create(block);
            }
            catch (System.Exception err)
            {
                throw new Exception("Ocorreu um erro na gravação do Bloco de Texto, " + err.Message + ".");
            }
        }


        public async Task Update(TextBlock block)
        {
            if (block == null)
            {
                throw new ArgumentNullException("O Bloco de Texto não pode ser nulo.");
            }
            await UpdateIfThereArentAnotherBlockWithRepeatedCode(block);

        }

        private async Task UpdateIfThereArentAnotherBlockWithRepeatedCode(TextBlock block)
        {
            if (await IsARepeatedCode(block.Id, block.Name))
            {
                throw new Exception("Já houve um cadastro utilizando este valor para o NOME '" + block.Name +
                    "', não haver Blocos de Textos com nomes repetidos.");
            }
            _BlockRepository.Update(block);
        }


        public async Task DeleteLogical(TextBlock textblock)
        {
            if (textblock == null){
                throw new ArgumentNullException("O Bloco de Texto não pode ser nulo.");
            }
            _BlockRepository.LogicalExclusion(textblock);
        }
    }
}
