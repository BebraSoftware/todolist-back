namespace BebraSoftware.TodoList.Models.Task
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Taskname { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsImportant { get; set; }
    }
}