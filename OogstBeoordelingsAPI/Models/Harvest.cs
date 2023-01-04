using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Models
{
    public enum HarvestStatus
    {
        Pending = 1,
        ToBeReviewed = 2,
        ToBeSold = 3,
        Finished = 4
    }

    public enum HarvestType
    {
        Fruit = 1,
        Vegetable = 2,
    }

    public class Harvest
    {
        public string Id { get; set; } = string.Empty;
        [Required]
        public int GrowerId { get; set; }
        [Required]
        public string GrowerName { get; set; } = string.Empty;
        public int ReviewerId { get; set; } = 0;
        public string ReviewerName { get; set; } = string.Empty;
        [Required]
        public string ImageFileName {get; set; }
        [Required]
        public int WeightKG { get; set; }
        [Required]
        public string SubType { get; set; }
        public decimal TotalPrice { get; set; } = decimal.Zero;
        [Required]
        public DateTime HarvestDate { get; set; }
        [Required]
        public HarvestType Type { get; set; }
        [Required]
        public HarvestStatus Status { get; set; }
        public Review? Review { get; set; }
    }
}
