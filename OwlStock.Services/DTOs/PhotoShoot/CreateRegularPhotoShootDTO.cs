using OwlStock.Domain.Common;
using OwlStock.Domain.Entities;
using OwlStock.Services.Common.HelperClasses;
using System.ComponentModel.DataAnnotations;

namespace OwlStock.Services.DTOs.PhotoShoot
{
    public class CreateRegularPhotoShootDTO : CreatePhotoshootDTO
    {
        //it is required but is valided in the controller,
        //not with attribute
        [Display(Name = "Дата")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Час е задължително поле")]
        [Display(Name = "Час")]
        public TimeOnly ReservationTime { get; set; }

        public bool IsPlaceSelected { get; set; }

        [Required]
        public bool IsPlace { get; set; }

        public Guid PlaceId { get; set; }

        [Required(ErrorMessage = "Изберете град или популярно място")]
        public string? SelectedSettlementId { get; set; }

        [Display(Name = "Нека ние изберем място за Вас")]
        public bool IsDecidedByUs { get; set; }

        [Required(ErrorMessage = "Място на фотосесията е задължително")]
        [Display(Name = "Място на фотосесията")]
        [MaxLength(ModelConstraints.UserPlace)]
        public string? UserPlace { get; set; }

        [Display(Name = "Линк към Google Maps (по избор)")]
        [MaxLength(ModelConstraints.GoogleMapsLinkDescriptionMxLength)]
        public string? GoogleMapsLink { get; set; }

        [Display(Name = "Желая превоз до локацията")]
        public bool TransportCustomer { get; set; }
        public string? PickUpAddress { get; set; }

        public decimal FuelPrice { get; set; }

        public Dictionary<DateOnly, IEnumerable<TimeSlot>>? Calendar { get; set; }
        public List<Region>? ServicedRegions { get; set; }
        public IEnumerable<WorkingTime>? WorkingHoursSpan { get; set; }
    }
}
