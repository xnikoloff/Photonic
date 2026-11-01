using System.ComponentModel.DataAnnotations;

namespace OwlStock.Domain.Enumerations
{
    public enum GiftCardStatus
    {
        [Display(Name = "Очаква плащане")]
        New = 1,

        [Display(Name = "Активен")]
        Active = 2,

        [Display(Name = "Отказан")]
        Declined = 3,

        [Display(Name = "Използван")]
        Used = 4
    }
}
