using System.ComponentModel.DataAnnotations;

namespace OwlStock.Domain.Enumerations
{
    public enum Category
    {
        [Display(Name = "Пейзаж")]
        Landscape = 1,

        [Display(Name = "Природа")]
        Nature = 2,

        [Display(Name = "Стрийт")]
        Street = 3,

        [Display(Name = "Шарки")]
        Patterns = 4,

        [Display(Name = "Животни")]
        Animals = 5,

        [Display(Name = "Мода")]
        Fashion = 6,

        [Display(Name = "Храна")]
        Food = 7,

        [Display(Name = "Тапети")]
        Wallpapers = 8,

        [Display(Name = "Пътешествия")]
        Travel = 9,

        [Display(Name = "Хора")]
        People = 10,

        [Display(Name = "Портрети")]
        Portrait = 11,

        [Display(Name = "Бизнес")]
        Business = 12,

        [Display(Name = "Спорт")]
        Sport = 13,

        [Display(Name = "Автомобил")]
        Automotive = 14,

        [Display(Name = "Здраве")]
        Health = 15,

        [Display(Name = "Изкуство")]
        Arts = 16,

        [Display(Name = "Архитектура")]
        Architectural = 17,

        [Display(Name = "Събития")]
        Events = 18,

        [Display(Name = "Нощна")]
        Night = 19,

        [Display(Name = "Астро")]
        Astro = 20,

        [Display(Name = "Макро")]
        Macro = 22,

        [Display(Name = "Сватба")]
        Wedding = 23,

        [Display(Name = "Продукт")]
        Product = 24,

        [Display(Name = "Фотосесия за бременни")]
        Pregnancy = 25,

        [Display(Name = "Абитуриентски бал")]
        Prom = 26,

        [Display(Name = "Свето кръщене")]
        Baptism = 27,

        [Display(Name = "Друго")]
        Other = 28,

        [Display(Name = "Семейна")]
        Family = 29,
            
        [Display(Name = "Всичко")]
        All = 30
    }
}
