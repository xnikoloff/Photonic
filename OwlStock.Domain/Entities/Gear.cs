using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class Gear
    {
        [Key]
        public Guid Id { get; set; }
        
        public string? CameraBrand { get; set; }

        public string? CameraModel { get; set; }

        public string? CameraLens { get; set; }

        public string? AdditionalInformation { get; set; }

        //TODO: Add created/updated properties and set them in the service to call the last record by its date
        //public int MyProperty { get; set; }

        [NotMapped]
        public string DisplayName => $"{CameraBrand} {CameraModel} - {CameraLens}";
    }
}
