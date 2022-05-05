namespace BebraSoftware.TodoList.Managers.WriterManager.JsonFileWriter
{
    using System;
    using System.IO;

    using Newtonsoft.Json;

    using NLog;

    public class JsonFileWriter<T> : IWriterManager<T, FileInfo>
    {
        #region Fields

        private readonly JsonSerializerSettings _defaultSettings;

        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public JsonFileWriter()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _defaultSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        #endregion

        #region Methods

        public bool Write(T obj, FileInfo info)
        {
            return Write(obj, info, null);
        }

        public bool Write(T obj, FileInfo fileInfo, JsonSerializerSettings settings)
        {
            try
            {
                string result = JsonConvert.SerializeObject(obj, Formatting.Indented, settings ?? _defaultSettings);

                using (StreamWriter sw = fileInfo.CreateText())
                {
                    sw.Write(result);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(() => $"{ex}");
                return false;
            }
        }

        #endregion
    }
}
