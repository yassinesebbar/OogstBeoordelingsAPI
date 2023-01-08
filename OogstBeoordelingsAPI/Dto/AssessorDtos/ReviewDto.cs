using OogstBeoordelingsAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Dto.AssessorDtos
{
    public class ReviewDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public int WeightKG { get; set; }
        [Required]
        public string Description { get; set; }
        public string? OptionalAdditionalInfo { get; set; }
        [Required]
        public int MarkPresentation { get; set; }
        [Required]
        public int MarkMoisture { get; set; }
        [Required]
        public int MarkTaste { get; set; }

        public Review MapToReview()
        {
            return new Review()
            {
                Id = Id,
                Description = Description,
                AdditionalInformation = OptionalAdditionalInfo,
                WeightKG = WeightKG,
                MarkPresentation = MarkPresentation,
                MarkTaste = MarkTaste,
                MarkMoisture = MarkMoisture
            };
        }
    }
}
