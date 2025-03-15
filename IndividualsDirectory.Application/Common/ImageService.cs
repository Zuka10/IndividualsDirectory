using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace IndividualsDirectory.Application.Common;

public class ImageService(IWebHostEnvironment webHostEnvironment)
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        if (image == null || image.Length == 0)
            throw new ArgumentException("Invalid image file.");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(image.FileName).ToLower();

        if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
            throw new ArgumentException("Only JPG and PNG files are allowed.");

        if (image.Length > 2 * 1024 * 1024)
            throw new ArgumentException("File size exceeds 2MB limit.");

        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        Directory.CreateDirectory(uploadsFolder);

        string uniqueFileName = $"{Guid.NewGuid()}_{image.FileName}";
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream);
        }

        return $"/images/{uniqueFileName}";
    }
}