using OogstBeoordelingsAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.HarvestDtos
{
    public class CreateHarvestDto
    {
        public IFormFile File { get; set; }
        [Required]
        public int WeightKG { get; set; }
        [Required]
        public string SubType { get; set; }
        [Required]
        public DateTime HarvestDate { get; set; }
        [Required]
        public HarvestType Type { get; set; }
    }
}
