namespace BebraSoftware.TodoList.Services.UserService
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    using Microsoft.IdentityModel.Tokens;

    using Models.User;
    using Models.Login;
    using Models.Logout;

    using Helpers;

    public class UserService : IUserService
    {
        #region Fields

        private readonly List<RegularUser> _users;

        private readonly IAppSettings _appSettings;

        #endregion

        #region Constructors

        public UserService(IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _users = new List<RegularUser>();
        }

        #endregion

        #region Methods

        public bool Logout(LogoutRequestModel model)
        {
            var user = _users?.SingleOrDefault(
                x => x.Username == model.Username);

            _users?.Remove(user);

            return user != null;
        }

        public LoginResponseModel Registrate(LoginRequestModel model)
        {
            var user = _users?.SingleOrDefault(x => x.Username == model.Username);

            if (user == null)
            {
                _users.Add(new RegularUser
                {
                    Id = Guid.NewGuid(),
                    Username = model.Username,
                    Password = model.Password
                });
            }

            var response = Authenticate(model);

            return response;
        }

        public LoginResponseModel Authenticate(LoginRequestModel model)
        {
            var user = _users?.SingleOrDefault(
                x => x.Username == model.Username &&
                x.Password == model.Password);

            if (user == null)
                return null;

            var token = GenerateJwtToken(user);

            return new LoginResponseModel(user, token);
        }

        public IEnumerable<RegularUser> GetAll()
        {
            return _users;
        }

        public RegularUser GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        private string GenerateJwtToken(RegularUser user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
