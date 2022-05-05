namespace BebraSoftware.TodoList.Models.ToDoListTasks
{
    using System;

    public class ToDoListTasks
    {
        
        public int Id { get; set; }

        public string Username { get; set; }

        public string TaskName { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsImportant { get; set; }

    }
}
