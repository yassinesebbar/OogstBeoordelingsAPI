using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Models
{
    public enum HarvestStatus
    {
        Pending = 1,
        ToBeReviewed = 2,
        ToBeSold = 3,
        Closed = 4
    }

    public enum HarvestType
    {
        Fruit = 1,
        Vegetable = 2,
    }

    public class Harvest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [Required]
        public int GrowerId { get; set; }
        [Required]
        public string GrowerName { get; set; } = string.Empty;
        public int ReviewerId { get; set; } = 0;
        public string ReviewerName { get; set; } = string.Empty;
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
