using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OwlStock.Domain.Enumerations
{
    public enum PhotoshootStatus
    {
        [Display(Name = "Активен")]
        New = 1,

        //Accepted = 2,

        [Display(Name = "Отказан")]
        Declined = 3,

        [Display(Name = "Активен")]
        Cancelled = 4,

        [Display(Name = "Приключен")]
        Completed = 5,

        [Display(Name = "Служебен")]
        Service = 6
    }
}
