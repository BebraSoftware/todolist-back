namespace BebraSoftware.TodoList.Managers.WriterManager
{
    public interface IWriterManager<in T, in TInfo>
    {
        #region Methods

        bool Write(T obj, TInfo info);

        #endregion
    }
}
