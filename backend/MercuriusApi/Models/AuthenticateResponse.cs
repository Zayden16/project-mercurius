using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MercuriusApi.Models
{
    public class AuthenticateResponse
    {
        [JsonPropertyName("Id")]
        public int User_Id { get; set; }
        [JsonPropertyName("FirstName")]
        public string User_FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string User_LastName { get; set; }
        [JsonPropertyName("DisplayName")]
        public string User_DisplayName { get; set; }
        [JsonPropertyName("Token")]
        public string User_Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            User_Id = user.User_Id;
            User_FirstName = user.User_FirstName;
            User_LastName = user.User_LastName;
            User_DisplayName = user.User_DisplayName;
            User_Token = token;
        }
    }
}