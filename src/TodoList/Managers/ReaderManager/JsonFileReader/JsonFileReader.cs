namespace BebraSoftware.TodoList.Managers.ReaderManager.JsonFileReader
{
    using System;
    using System.IO;

    using Newtonsoft.Json;

    using NLog;

    public class JsonFileReader<T> : IReaderManager<T, FileInfo>
    {
        #region Fields

        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public JsonFileReader()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        #endregion

        #region Methods

        public T Read(FileInfo fileInfo)
        {
            try
            {
                using (StreamReader file = fileInfo.OpenText())
                {
                    string json = file.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(() => $"{ex}");
                return default(T);
            }
        }

        #endregion
    }
}
