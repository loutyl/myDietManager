namespace MyDietManagerAbstract.Abstraction.Serialization
{
    public interface ISerializer<T>
    {
        string SerializeObject(T objectToSerialize);
        T DeserializeObejct(string toDeserialize);
    }
}
