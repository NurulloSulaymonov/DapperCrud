using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class FileService : IfileService
{
    private readonly IWebHostEnvironment _environment;

    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    public async Task<string> AddFile(IFormFile file, string folder)
    {
        try
        {
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // kdfjkdfjdkfjdkfj.jpg
           //check for folder
            var folderPath = Path.Combine(_environment.WebRootPath, folder);
            if (Path.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(folderPath, filename);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public bool DeleteFile(string filename, string folder)
    {
        var filePath = Path.Combine(_environment.WebRootPath, folder,filename);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }
        else
        {
            return false;
        }
    }
}