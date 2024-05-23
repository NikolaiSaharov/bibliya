using System.IO;
using System.Text.Json;

namespace SerializationLibrary1
{
    public class SerializationDeserialization<T>
    {
        private readonly string filePath;

        public SerializationDeserialization(string filePath)
        {
            this.filePath = filePath;
        }

        public void SerializeToFile(T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(filePath, json);
        }

        public T DeserializeFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
            else
            {
                throw new FileNotFoundException("Файл не найден.", filePath);
            }
        }

        public string Serialize(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public T Deserialize(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}