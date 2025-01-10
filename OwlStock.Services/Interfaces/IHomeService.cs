using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.HomePage;

namespace OwlStock.Services.Interfaces
{
    public interface IHomeService
    {
        Task<HomePageDTO> GetHomeData();
    }
}
