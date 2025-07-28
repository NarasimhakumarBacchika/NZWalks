namespace NZWalks.API.DTO
{
    public class LoginResponseDto
    {

            public string JwtToken {  get; set; }
       
            public string Token { get; set; }
            public string Username { get; set; }
            public List<string> Roles { get; set; }
        
    }
}
