using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDietManagerAbstract.Serialization
{
    public interface ISerializer<T>
    {
        string SerializeObject(T objectToSerialize);
        T DeserializeObejct(string toDeserialize);
    }
}
