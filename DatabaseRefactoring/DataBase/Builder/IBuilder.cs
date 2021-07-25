namespace DatabaseRefactoring.DataBase.Builder
{
    public interface IBuilder<out TResult, in TSource>
    {
        public TResult Build(TSource source);
    }
}
