using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.Place;

namespace OwlStock.Services.Interfaces
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> All();
        Task<IEnumerable<Place>> AllPopular();
        Task<IEnumerable<Place>> GetPopularPlacesByRegion(int regionId);
        Task<PlaceByIdDTO?> PlaceById(Guid id);
        Task<Guid> Create(CreatePlaceDTO place);
        Task<Guid> Update(Place place);
        Task<bool> UpdatePhotoId(Guid placeId, Guid photoId);
    }
}
