namespace BebraSoftware.TodoList.Models.Logout
{
    using System.ComponentModel.DataAnnotations;

    public class LogoutRequestModel
    {
        #region Properties

        [Required]
        public string Username { get; set; }

        #endregion
    }
}
