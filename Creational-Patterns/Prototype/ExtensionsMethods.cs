using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Prototype
{
    public static class ExtensionsMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        public static T DeepCopyJson<T>(this T self)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(self));
        }
    }
}