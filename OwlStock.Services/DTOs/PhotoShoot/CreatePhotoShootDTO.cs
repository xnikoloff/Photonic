using OwlStock.Domain.Common;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.Common.HelperClasses;
using System.ComponentModel.DataAnnotations;

namespace OwlStock.Services.DTOs.PhotoShoot
{
    public class CreatePhotoShootDTO
    {
        [MaxLength(ModelConstraints.PersonEmailMaxLength)]
        public string? PersonEmail { get; set; }

        [Display(Name = "Тип на фотосесията")]
        [Required(ErrorMessage = "Тип на фотосесията е задължително поле")]
        public PhotoShootType PhotoShootType { get; set; }

        [Required(ErrorMessage = "Име е задължително поле")]
        [Display(Name = "Име")]
        [MaxLength(ModelConstraints.PersonNameMaxLength)]
        public string? PersonFirstName { get; set; }

        [Required(ErrorMessage = "Фамилия е задължително поле")]
        [Display(Name = "Фамилия")]
        [MaxLength(ModelConstraints.PersonNameMaxLength)]
        public string? PersonLastName { get; set; }

        [Required(ErrorMessage = "Телефон е задължително поле")]
        [Display(Name = "Телефон")]
        [MaxLength(ModelConstraints.PersonPhoneMaxLenth)]
        public string? PersonPhone { get; set; }

        //it is required but is valided in the controller,
        //not with attribute
        [Display(Name = "Дата")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Час е задължително поле")]
        [Display(Name = "Час")]
        public TimeOnly ReservationTime { get; set; }
        
        [Display(Name = "Описание")]
        [MaxLength(ModelConstraints.PhotoShootTypeDescriptionMaxLength)]
        public string? PhotoShootTypeDescription { get; set; }

        public bool IsPlaceSelected { get; set; }

        [Required]
        public bool IsPlace { get; set; }

        public Guid PlaceId { get; set; }

        [Required(ErrorMessage = "Изберете град или популярно място")]
        public string? SelectedSettlementId { get; set; }

        [Display(Name = "Нека ние изберем място за Вас")]
        public bool IsDecidedByUs { get; set; }

        [Display(Name = "Малък продукт")]
        public bool IsSmallProduct { get; set; }

        [Required(ErrorMessage = "Място на фотосесията е задължително")]
        [Display(Name = "Място на фотосесията")]
        [MaxLength(ModelConstraints.UserPlace)]
        public string? UserPlace { get; set; }

        [Display(Name = "Линк към Google Maps")]
        [MaxLength(ModelConstraints.GoogleMapsLinkDescriptionMxLength)]
        public string? GoogleMapsLink { get; set; }

        [Display(Name = "Не желая да получа снимките си чрез сайта на Photon")]
        public bool DoNotUploadPhotos { get; set; }

        [Display(Name = "Начин на получаване на снимки")]
        public PhotoDeliveryMethod? PhotoDeliveryMethod { get; set; }

        [Display(Name = "Адрес или офис на Econt")]
        [MaxLength(ModelConstraints.PhotoDeliveryAddressMxLength)]
        public string? PhotoDeliveryAddress { get; set; }

        [Display(Name = "Желая превоз до локацията")]
        public bool TransportCustomer { get; set; }
        public string? PickUpAddress { get; set; }

        public decimal Price { get; set; }

        public decimal FuelPrice { get; set; }
        
        public Dictionary<DateOnly, IEnumerable<TimeSlot>>? Calendar { get; set; }
        public List<Region>? ServicedRegions { get; set; }

        public string? IdentityUserId { get; set; }

        public string? Password { get; set; }
    }
}
