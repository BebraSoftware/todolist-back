namespace BebraSoftware.TodoList.Helpers
{
    public class AppSettings : IAppSettings
    {
        private readonly string _secretKey;

        public string SecretKey => _secretKey;

        public AppSettings()
        {
            _secretKey = "todolist_secret_key";
        }
    }
}
