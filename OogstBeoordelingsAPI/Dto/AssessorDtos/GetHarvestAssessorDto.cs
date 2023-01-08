using OogstBeoordelingsAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Dto.AssessorDtos
{
    public class GetHarvestAssessorDto
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
        [Required]
        public HarvestStatus status { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string GrowerName { get; set; }
        [Required]
        public int GrowerId { get; set; }

        public GetHarvestAssessorDto(Harvest harvest, Byte[] file)
        {
            File = file;
            HarvestId = harvest.Id;
            WeightKG = harvest.WeightKG;
            SubType = harvest.SubType;
            HarvestDate = harvest.HarvestDate;
            Type = harvest.Type;
            status = harvest.Status;
            Address = harvest.harvesterAddres;
            GrowerName = harvest.GrowerName;
            GrowerId = harvest.GrowerId;
        }
    }
}
