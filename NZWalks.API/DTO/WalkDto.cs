using NZWalks.API.Model.Data;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class WalkDto
    {


        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        [Required]
        public string? WalkImageUrl { get; set; }
        [Required]
        public Diffculty Diffculty { get; set; }
        [Required]
        public Region Region { get; set; }
        //[Required]
        //public Guid DiffcultyId { get; set; }
        //[Required]
        //public Guid RegionId { get; set; }
    }
}
