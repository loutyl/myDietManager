namespace MyDietManagerAbstract.Abstraction.Security
{
    public interface IAuthentifactionManager<T>
    {
        T Authenticate(string username, string password);
    }
}
