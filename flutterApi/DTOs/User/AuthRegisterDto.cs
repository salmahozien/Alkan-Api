using System.Text.Json.Serialization;

namespace flutterApi.DTOs.User
{
    public class AuthRegisterDto
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        // public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public string RegWay { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
         public DateTime ExpiresOn { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }

    }
}
