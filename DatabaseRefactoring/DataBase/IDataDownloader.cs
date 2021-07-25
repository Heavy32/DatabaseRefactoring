namespace DatabaseRefactoring.DataBase
{
    public interface IDataDownloader<out TModel, in TParameters>
    {
        public TModel GetData(TParameters parameters);
    }
}
