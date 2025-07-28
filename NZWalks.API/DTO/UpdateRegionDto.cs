using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class UpdateRegionDto
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }


        public string? RegionImageUrl { get; set; }

    }
}
