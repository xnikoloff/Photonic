using OwlStock.Services.DTOs.HomePage;

namespace OwlStock.Services.Facades.Interfaces
{
    public interface IHomeFacade
    {
        Task<HomePageDTO> GetHomeData();
    }
}
