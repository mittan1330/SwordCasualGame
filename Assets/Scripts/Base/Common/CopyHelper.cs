using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CopyHelper
{
    /// <summary>
    /// DeepCopy
    /// https://blog.unikktle.com/c%E3%81%A7list%E3%82%92%E5%80%A4%E3%82%B3%E3%83%94%E3%83%BCdeepcopy%E3%81%99%E3%82%8B%E9%9A%9B%E3%81%AE%E3%81%8A%E5%8B%A7%E3%82%81/
    /// </summary>
    public static T DeepCopy<T>(this T src)
    {
        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, src);
            stream.Position = 0;

            return (T)formatter.Deserialize(stream);
        }
    }
}
