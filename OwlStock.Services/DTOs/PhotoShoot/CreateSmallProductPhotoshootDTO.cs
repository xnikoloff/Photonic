using OwlStock.Domain.Common;
using OwlStock.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace OwlStock.Services.DTOs.PhotoShoot
{
    public class CreateSmallProductPhotoshootDTO
    {
        [MaxLength(ModelConstraints.PersonEmailMaxLength)]
        public string? PersonEmail { get; set; }

        [Display(Name = "Тип на фотосесията")]
        [Required(ErrorMessage = "Тип на фотосесията е задължително поле")]
        public PhotoShootType PhotoShootType { get; set; } = PhotoShootType.Product;

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

        [Display(Name = "Описание")]
        [MaxLength(ModelConstraints.PhotoShootTypeDescriptionMaxLength)]
        public string? PhotoShootTypeDescription { get; set; }

        [Display(Name = "Малък продукт")]
        public bool IsSmallProduct { get; set; } = true;

        [Display(Name = "Не желая да получа снимките си чрез сайта на Photonic")]
        public bool DoNotUploadPhotos { get; set; }

        [Display(Name = "Начин на получаване на снимки")]
        public PhotoDeliveryMethod? PhotoDeliveryMethod { get; set; }

        [Display(Name = "Адрес или офис на Econt")]
        [MaxLength(ModelConstraints.PhotoDeliveryAddressMxLength)]
        public string? PhotoDeliveryAddress { get; set; }

        public decimal Price { get; set; }

        public string? IdentityUserId { get; set; }

        public string? Password { get; set; }
    }
}
