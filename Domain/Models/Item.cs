using rest_api_items.Domain.Helpers;

namespace rest_api_items.Domain.Models
{
    public class Item
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ManufacturerName {get; set;}
        public string Model {get; set;}
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}