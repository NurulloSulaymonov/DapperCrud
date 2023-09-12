using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public interface IfileService
{
    Task<string?> AddFile(IFormFile file, string folder);
    bool DeleteFile(string filename,string folder);

}