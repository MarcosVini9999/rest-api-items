using System.ComponentModel.DataAnnotations;

namespace rest_api_items.Resources
{
    public class SaveItemResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string ManufacturerName {get; set;}

        [Required]
        [MaxLength(30)]
        public string Model {get; set;}
    }
}