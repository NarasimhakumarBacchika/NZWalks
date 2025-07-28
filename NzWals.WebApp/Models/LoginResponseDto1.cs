namespace NzWals.WebApp.Models
{
    public class LoginResponseDto1
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
