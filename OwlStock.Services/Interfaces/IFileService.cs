using Microsoft.AspNetCore.Http;
using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs;

namespace OwlStock.Services.Interfaces
{
    public interface IFileService
    {
        bool CreatePhotoFile(PhotoBase photo);
        bool CreatePlacePhotoFile(CreatePlacePhotoFileDTO dto);
        Task CreateIFormFile(IFormFile file, string webRootPath);
    }
}
