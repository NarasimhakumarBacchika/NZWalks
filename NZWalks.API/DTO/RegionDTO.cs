using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class RegionDTO
    {
        //  public Guid Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage="The Code size should be min 3 charcters")]
        [MaxLength(3, ErrorMessage = "The Code size should be max 3 charcters")]
        public string Code { get; set; }

        [Required]

        public string Name { get; set; }

       
        public string? RegionImageUrl { get; set; }
    }
}
