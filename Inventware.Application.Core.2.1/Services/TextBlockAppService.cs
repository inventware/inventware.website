
namespace Inventware.Application.Core2.Services
{
    //public interface ITextBlockAppService : IDisposable
    //{
    //    Task<ResponseMessage<TextBlockDTO>> GetUndeleteAndActiveBlocks();

    //    Task<ResponseMessage<TextBlockDTO>> Create(RequestMessage<TextBlockDTO> request);
    //}





    //public class TextBlockAppService : AppServiceBase<TextBlock, Guid>, ITextBlockAppService
    //{
    //    private readonly ITextBlockService _BlockService;

    //    public TextBlockAppService(IUnitOfWork unitOfWork, IMapper mapper, ITextBlockService blockService)
    //        : base(unitOfWork, mapper)
    //    {
    //        _BlockService = blockService;
    //    }


    //    public async Task<ResponseMessage<TextBlockDTO>> GetUndeleteAndActiveBlocks()
    //    {
    //        try
    //        {
    //            var listOfBlockDTos = _Mapper.Map<IEnumerable<TextBlock>, IEnumerable<TextBlockDTO>>(await
    //                _BlockService.GetUndeleteAndActiveBlocks());

    //            return new ResponseMessage<TextBlockDTO>
    //            {
    //                ListOfDTos = listOfBlockDTos,
    //                IsSuccess = true
    //            };
    //        }
    //        catch (Exception err)
    //        {
    //            return new ResponseMessageForError<TextBlockDTO>(err).Load();
    //        }
    //    }


    //    public async Task<ResponseMessage<TextBlockDTO>> Create(RequestMessage<TextBlockDTO> request)
    //    {
    //        try
    //        {
    //            var block = new TextBlockToBeCreatedFactory(request.DTo.Name, request.DTo.Content,
    //                request.DTo.IsVisible, request.DTo.LoggedUser).Create();
    //            await _BlockService.Create(block);

    //            return new ResponseMessage<TextBlockDTO>
    //            {
    //                DTo = request.DTo,
    //                IsSuccess = true
    //            };
    //        }
    //        catch (Exception err)
    //        {
    //            return new ResponseMessageForError<TextBlockDTO>(err).Load();
    //        }
    //    }


    //    public void Dispose()
    //    {
    //        GC.SuppressFinalize(this);
    //    }
    //}
}
