namespace BebraSoftware.TodoList.Models.Tasks
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string TaskName { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsImportant { get; set; }
    }
}