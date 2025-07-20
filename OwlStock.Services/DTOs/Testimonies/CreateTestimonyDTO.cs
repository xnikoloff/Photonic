using OwlStock.Domain.Entities;

namespace OwlStock.Services.DTOs.Testimonies
{
    public class CreateTestimonyDTO
    {
        public Testimony? Testimony { get; set; }

        public string? ReCaptchaToken { get; set; }
    }
}
