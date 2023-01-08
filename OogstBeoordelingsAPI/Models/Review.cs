using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Models
{
    public class Review
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string ReviewerName { get; set; }
        [Required]
        public int ReviewerId { get; set; }
        [Required]
        public int WeightKG { get; set; }
        [Required]
        public string Description { get; set; }
        public string? AdditionalInformation { get; set; }
        [Required]
        public int MarkPresentation { get; set; }
        [Required]
        public int MarkMoisture { get; set; }
        [Required]
        public int MarkTaste { get; set;}
    }
}
