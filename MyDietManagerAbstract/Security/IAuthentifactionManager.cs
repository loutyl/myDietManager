namespace MyDietManagerAbstract.Security
{
    public interface IAuthentifactionManager<out T>
    {
        T Authenticate(string username, string password);
    }
}
