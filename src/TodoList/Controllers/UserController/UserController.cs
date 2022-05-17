namespace BebraSoftware.TodoList.Controllers.UserController
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Services.UserService;

    using Models.Login;
    using Models.Logout;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Constructors

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region GET

        [HttpGet]
        public object GetUsers()
        {
            var users = _userService.GetAll();
            return users;
        }

        [HttpGet("{id}")]
        public object GetUser(Guid id)
        {
            var user = _userService.GetById(id);
            return user;
        }

        #endregion

        #region POST

        [Route("Registrate")]
        [HttpPost]
        public object PostRegistrate(LoginRequestModel model)
        {
            var response = _userService.Registrate(model);

            if (response == null)
            {
                var message = "Username is already exist!";
                return BadRequest(message);
            }

            return Ok(response);
        }

        [Route("Authenticate")]
        [HttpPost]
        public object PostAuthenticate(LoginRequestModel model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                var message = "Username or password is incorrect";
                return BadRequest(message);
            }

            return Ok(response);
        }

        #endregion

        #region DELETE

        [Route("Logout")]
        [HttpDelete]
        public object DeleteLogout(LogoutRequestModel model)
        {
            var response = _userService.Logout(model);

            return response ? "Successfully logout" : "Failure logout!";
        }

        #endregion
    }
}
