using Microsoft.AspNetCore.Http;
using News365.Core.Utilities.Result;
using News365.Entities.Concrete;

namespace News365.Business.Abstract;
public interface IDocumentService
{
    Task<IDataResult<Document>> GetDocumentByIdAsync(string DocumentUnique);
    Task<IDataResult<List<Document>>> GetDocumentListAsync();
    Task<IDataResult<string>> AddUploadAsync(IFormFile file, string FolderName, string Image_Url = null, string Video_Url = null);
    Task<IDataResult<string>> UpdateUploadAsync(IFormFile file, string DocumentUnique, string FolderName, string Image_Url = null, string Video_Url = null);
}