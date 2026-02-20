using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OwlStock.Domain.Enumerations
{
    public enum PhotoShootType
    {
        [Display(Name = "Индивидуална фотосесия")]
        Personal = 1,

        [Display(Name = "Бизнес портрет")]
        BusinessPortrait = 2,

        [Display(Name = "Сватба")]
        Wedding = 3,

        [Display(Name = "Сватба Plus")]
        WeddingPlus = 4,

        [Display(Name = "Абитуриентски бал")]
        Prom = 5,

        [Display(Name = "Семейна фотосесия")]
        Family = 6,

        [Display(Name = "Семейна фотосесия Plus")]
        FamilyPlus = 7,

        [Display(Name = "Семейна фотосесия Extra")]
        FamilyExtra = 8,

        [Display(Name = "Автомобил")]
        Automotive = 9,

        [Display(Name = "Друг")]
        Other = 10,

        [Display(Name = "Продукт")]
        Product = 11,

        [Display(Name = "Свето кръщение")]
        Baptism = 12,

        [Display(Name = "Индивидуална фотосесия Plus")]
        PersonalPlus = 13,

        [Display(Name = "Индивидуална фотосесия Extra")]
        PersonalExtra = 14,

        [Display(Name = "Сватба Extra")]
        WeddingExtra = 15,

        [Display(Name = "Абитуриентски бал Plus")]
        PromPlus = 16,

        [Display(Name = "Абитуриентски бал Extra")]
        PromExtra = 17,

        [Display(Name = "Свето кръщене Plus")]
        BaptismPlus = 18,

        [Display(Name = "Свето кръщене Extra")]
        BaptismExtra = 19,

        [Display(Name = "Събитие")]
        Event = 20,

        [Display(Name = "Продукт Plus")]
        ProductPlus = 21,

        [Display(Name = "Автомобил Артистичен")]
        AutomotivePlus = 22,

        [Display(Name = "Автомобил Rollin'")]
        AutomotiveExtra = 23,
    }
}
