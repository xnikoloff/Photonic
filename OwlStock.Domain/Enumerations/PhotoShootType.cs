using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OwlStock.Domain.Enumerations
{
    public enum PhotoShootType
    {
        [Description("Индивидуална фотосесия")]
        [Display(Name = "Индивидуална фотосесия")]
        Personal = 1,

        [Description("Бизнес портрет")]
        [Display(Name = "Бизнес портрет")]
        BusinessPortrait = 2,

        [Description("Сватба")]
        [Display(Name = "Сватба")]
        Wedding = 3,

        [Description("Сватба Plus")]
        [Display(Name = "Сватба Plus")]
        WeddingPlus = 4,

        [Description("Абитуриентски бал")]
        [Display(Name = "Абитуриентски бал")]
        Prom = 5,

        [Description("Семейна фотосесия")]
        [Display(Name = "Семейна фотосесия")]
        Family = 6,

        [Description("Семейна фотосесия Plus")]
        [Display(Name = "Семейна фотосесия Plus")]
        FamilyPlus = 7,

        [Description("Семейна фотосесия Extra")]
        [Display(Name = "Семейна фотосесия Extra")]
        FamilyExtra = 8,

        [Description("Автомобил")]
        [Display(Name = "Автомобил")]
        Automotive = 9,

        [Description("Друг")]
        [Display(Name = "Друг")]
        Other = 10,

        [Description("Продукт")]
        [Display(Name = "Продукт")]
        Product = 11,

        [Description("Свето кръщене")]
        [Display(Name = "Свето кръщение")]
        Baptism = 12,

        [Description("Индивидуална фотосесия Plus")]
        [Display(Name = "Индивидуална фотосесия Plus")]
        PersonalPlus = 13,

        [Description("Индивидуална фотосесия Extra")]
        [Display(Name = "Индивидуална фотосесия Extra")]
        PersonalExtra = 14,

        [Description("Сватба Extra")]
        [Display(Name = "Сватба Extra")]
        WeddingExtra = 15,

        [Description("Абитуриентски бал Plus")]
        [Display(Name = "Абитуриентски бал Plus")]
        PromPlus = 16,

        [Description("Абитуриентски бал Extra")]
        [Display(Name = "Абитуриентски бал Extra")]
        PromExtra = 17,

        [Description("Свето кръщене Plus")]
        [Display(Name = "Свето кръщене Plus")]
        BaptismPlus = 18,

        [Description("Свето кръщене Extra")]
        [Display(Name = "Свето кръщене Extra")]
        BaptismExtra = 19,

        [Description("Събитие")]
        [Display(Name = "Събитие")]
        Event = 20,

        [Description("Продукт Plus")]
        [Display(Name = "Продукт Plus")]
        ProductPlus = 21,

        [Description("Автомобил Артистичен")]
        [Display(Name = "Автомобил Артистичен")]
        AutomotivePlus = 22,

        [Description("Автомобил Rollin'")]
        [Display(Name = "Автомобил Rollin'")]
        AutomotiveExtra = 23,
    }
}
