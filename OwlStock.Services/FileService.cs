using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class FileService : IFileService
    {
        private readonly IPhotoResizer _photoResizer;
        private readonly ILogger<FileService> _logger;

        public FileService(IPhotoResizer photoResizer, ILogger<FileService> logger)
        {
            _photoResizer = photoResizer;
            _logger = logger;
        }

        public bool CreatePhotoFile(PhotoBase photo)
        {
            if (File.Exists(photo.FilePath))
            {
                return true;
            }

            if (!Directory.Exists(photo.FilePath))
            {
                Directory.CreateDirectory(photo.FilePath ?? throw new NullReferenceException($"{photo.FilePath} is null"));
            }

            if(photo.FileName is null)
            {
                _logger.LogInformation("{FileName} is null in {Method}, {Class}, {DateTime}", nameof(photo.FileName), nameof(CreatePhotoFile), nameof(AdministrationService), DateTime.Now);
                throw new NullReferenceException($"{nameof(photo.FileName)}");
            }

            if(photo.FileData is null)
            {
                _logger.LogInformation("{FileData} is null in {Method}, {Class}, {DateTime}", nameof(photo.FileData), nameof(CreatePhotoFile), nameof(AdministrationService), DateTime.Now);
                throw new NullReferenceException($"{nameof(photo.FileData)} is null");
            }

            switch (photo)
            {
                case GalleryPhoto:
                {
                    using FileStream streamOriginalSize = File.OpenWrite(Path.Combine(photo.FilePath, $"OriginalSize_{photo.FileName}").Replace('\\', '/'));
                    using FileStream streamSmallSize = File.OpenWrite(Path.Combine(photo.FilePath, $"Small_{photo.FileName}").Replace('\\', '/'));
                    
                    streamOriginalSize.Write(photo.FileData, 0, photo.FileData.Length);
                    byte[] resized = _photoResizer.Resize(photo.FileData, PhotoSize.Small);
                    streamSmallSize.Write(resized, 0, resized.Length);
                    
                    break;
                }

                case PhotoShootPhoto:
                {
                    using FileStream streamOriginalSize = File.OpenWrite(Path.Combine(photo.FilePath, photo.FileName).Replace('\\', '/'));
                    streamOriginalSize.Write(photo.FileData, 0, photo.FileData.Length);
                    
                    break;
                }
            }
            
            return false;
        }

        public bool CreatePlacePhotoFile(CreatePlacePhotoFileDTO dto)
        {
            if (dto.PhotoBase == null)
            {
                throw new NullReferenceException($"{nameof(dto.PhotoBase)} is null");
            }

            if (dto.PhotoBase.FilePath == null)
            {
                throw new NullReferenceException($"{nameof(dto.PhotoBase.FilePath)} is null");
            }

            int lastIndexOfSlash = dto.PhotoBase.FilePath.LastIndexOf('\\');
            string directoryPath = dto.PhotoBase.FilePath[..lastIndexOfSlash];

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if(dto.FileData == null)
            {
                throw new NullReferenceException(nameof(dto.FileData));
            }

            byte[]? bytes = dto.FileData;
            using FileStream streamSmallSize = File.OpenWrite(dto?.PhotoBase?.FilePath ?? "");
            streamSmallSize.Write(bytes, 0, bytes.Length);

            return true;
        }

        public async Task CreateIFormFile(IFormFile file, string webRootPath)
        {
            if(file == null) 
            { 
                throw new NullReferenceException($"{nameof(file)} is null");
            }

            string filePath = Path.Combine(webRootPath, "resources", "images", file.FileName);
            if (file.Length > 0)
            {
                using Stream fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
