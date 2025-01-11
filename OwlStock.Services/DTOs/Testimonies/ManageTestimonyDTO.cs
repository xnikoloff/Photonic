using OwlStock.Domain.Entities;

namespace OwlStock.Services.DTOs.Testimonies
{
    public class ManageTestimonyDTO
    {
        public IEnumerable<Testimony>? NewTestimonies { get; set; }
        public IEnumerable<Testimony>? ApprovedTestimonies { get; set; }
        public IEnumerable<Testimony>? HiddenTestimonies { get; set; }
        public IEnumerable<Testimony>? UnhiddenTestimonies { get; set; }
        public IEnumerable<Testimony>? GoodTestimonies { get; set; }
        public IEnumerable<Testimony>? BadTestimonies { get; set; }
    }
}
