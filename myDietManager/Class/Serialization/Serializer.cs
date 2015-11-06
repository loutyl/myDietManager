using System.IO;
using System.Xml.Serialization;

namespace myDietManager.Class.Serialization
{
    public class Serializer<T>
    {
        public string SerializeObject(T objectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(objectToSerialize.GetType());
            using ( var textWriter = new StringWriter() )
            {
                xmlSerializer.Serialize(textWriter, objectToSerialize);
                return textWriter.ToString();
            }

        }

        public T DeserializeObject(string stringDeserialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(new StringReader(stringDeserialize));
        }
    }
}
