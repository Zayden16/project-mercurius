using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MercuriusApi.Helpers;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IUserRepository _userRepository;
        private List<User> _users;
        private readonly AppSettings _appSettings;

        public AuthenticationController(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _users = _userRepository.GetUserRecords();
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody]AuthenticateRequest requestModel)
        {
            var response = DoAuth(requestModel);
            if (response == null)
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }

            return Ok(response);
        }

        private AuthenticateResponse DoAuth(AuthenticateRequest authReq)
        {
            var user = _users.SingleOrDefault(x =>
                x.User_DisplayName == authReq.Username && x.User_Password == authReq.Password);
            if (user == null) return null;
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.User_Id.ToString())}),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}