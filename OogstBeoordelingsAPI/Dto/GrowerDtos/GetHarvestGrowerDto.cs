using OogstBeoordelingsAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Dto.HarvestDtos
{
    public class GetHarvestGrowerDto
    {
        public Byte[] File { get; set; }
        [Required]
        public string HarvestId { get; set; }
        [Required]
        public int WeightKG { get; set; }
        [Required]
        public string SubType { get; set; }
        [Required]
        public DateTime HarvestDate { get; set; }
        [Required]
        public HarvestType Type { get; set; }
        public HarvestStatus status { get; set; }

        public GetHarvestGrowerDto(Harvest harvest, Byte[] file)
        {
            File = file;
            HarvestId = harvest.Id;
            WeightKG = harvest.WeightKG;
            SubType = harvest.SubType;
            HarvestDate = harvest.HarvestDate;
            Type = harvest.Type;
            status = harvest.Status;
        }
    }
}
