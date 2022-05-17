namespace BebraSoftware.TodoList.Services.UserService
{
    using System;
    using System.Collections.Generic;

    using Models.Login;
    using Models.Logout;
    using Models.User;

    public interface IUserService
    {
        #region Methods

        LoginResponseModel Registrate(LoginRequestModel model);

        LoginResponseModel Authenticate(LoginRequestModel model);

        bool Logout(LogoutRequestModel model);

        IEnumerable<RegularUser> GetAll();

        RegularUser GetById(Guid id);

        #endregion
    }
}
