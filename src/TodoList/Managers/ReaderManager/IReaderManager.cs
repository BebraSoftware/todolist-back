namespace BebraSoftware.TodoList.Managers.ReaderManager
{
    public interface IReaderManager<out T, in TInfo>
    {
        #region Methods

        T Read(TInfo info);

        #endregion
    }
}
