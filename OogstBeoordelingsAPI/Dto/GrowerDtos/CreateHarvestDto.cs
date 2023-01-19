using OogstBeoordelingsAPI.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OogstBeoordelingsAPI.HarvestDtos
{
    public class CreateHarvestDto
    {
        public IFormFile File { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HarvestType Type { get; set; }
        [Required]
        public string SubType { get; set; }
        [Required]
        public DateTime HarvestDate { get; set; }
        [Required]
        public int WeightKG { get; set; }

        public Harvest MapToHarvest(User grower)
        {
            return new Harvest()
            {
                GrowerId = grower.Id,
                GrowerName = $"{grower.FirstName} {grower.LastName}",
                HarvestDate = HarvestDate,
                Type = Type,
                SubType = SubType,
                WeightKG = WeightKG,
                harvesterAddres = $"{grower.Adres}, {grower.Zipcode}, {grower.City}"
            };
        }

    }
}
