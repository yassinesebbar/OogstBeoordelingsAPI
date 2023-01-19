using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OogstBeoordelingsAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HarvestStatus
    {
        Pending,
        ToBeReviewed,
        ToBeSold,
        Closed
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HarvestType
    {
        Fruit,
        Vegetable,
    }

    public class Harvest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [Required]
        public int Uid { get; set; }  
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
        public DateTime CreatedAt { get; set; }
        [Required]
        [BsonRepresentation(BsonType.String)]
        public HarvestType Type { get; set; }
        [Required]
        [BsonRepresentation(BsonType.String)]
        public HarvestStatus Status { get; set; }
        public Review? Review { get; set; }
        public int YearCreated { get; set; }
        public string harvesterAddres { get; set; }

        public Harvest()
        {
            CreatedAt = DateTime.Now;
            YearCreated = DateTime.Now.Year;
            Status = HarvestStatus.Pending;
        }
    }
}
