using System.ComponentModel.DataAnnotations;

namespace NzWals.WebApp.Models
{
    public class RegisterRequestVM
    {


        [Required]
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }


        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
