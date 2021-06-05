namespace MercuriusApi.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.User_Id;
            FirstName = user.User_FirstName;
            LastName = user.User_LastName;
            Username = user.User_DisplayName;
            Token = token;
        }
    }
}