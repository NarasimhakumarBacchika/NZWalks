using System.ComponentModel.DataAnnotations;

namespace NzWals.WebApp.Models
{
    public class LoginRequestVM
    {
        [Required]

        [DataType(DataType.EmailAddress)]   
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
