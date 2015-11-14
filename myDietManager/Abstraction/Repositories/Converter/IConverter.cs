namespace myDietManager.Abstraction.Repositories.Converter
{
    public interface IConverter<T, TResult>
    {
        TResult Convert(T objectToConvert);
        T ConvertBack(TResult objectToConvert);
    }
}
