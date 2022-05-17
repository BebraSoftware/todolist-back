namespace BebraSoftware.TodoList.Models.Login
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequestModel
    {
        #region Properties

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        #endregion
    }
}
