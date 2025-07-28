using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class LoginRequestDto
    {
        
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
