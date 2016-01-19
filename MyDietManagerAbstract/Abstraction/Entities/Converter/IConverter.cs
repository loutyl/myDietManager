namespace MyDietManagerAbstract.Abstraction.Entities.Converter
{
    public interface IConverter<T, TResult>
    {
        TResult Convert(T entity);
        T ConvertBack(TResult pocoObjectToConvert);
    }
}
