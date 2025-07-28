using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class AddWalkDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DiffcultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
