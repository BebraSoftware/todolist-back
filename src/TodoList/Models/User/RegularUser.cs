namespace BebraSoftware.TodoList.Models.User
{
    using System;

    public class RegularUser
    {
        #region Properties

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        #endregion
    }
}
