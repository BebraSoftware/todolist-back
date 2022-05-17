namespace BebraSoftware.TodoList.Models.Login
{
    using System;

    using Models.User;

    public class LoginResponseModel
    {
        #region Properties

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }

        #endregion

        #region Constructors

        public LoginResponseModel(RegularUser user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }

        #endregion
    }
}
