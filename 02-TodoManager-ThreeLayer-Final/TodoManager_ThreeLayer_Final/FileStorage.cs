using System.Text.Json;
using System.IO;

namespace TodoManager_ThreeLayer_Final
{
    internal class FileStorage
    {
        private readonly string path;

        public FileStorage(string path)
        {
            this.path = path;
        }

        public TodoStorage Load()
        {
            if (!File.Exists(path))
            {
                return new TodoStorage();
            }

            string json = File.ReadAllText(path);

            TodoStorage? storage =
                JsonSerializer.Deserialize<TodoStorage>(json);

            if (storage == null)
            {
                throw new InvalidDataException(
                    "Файлът не съдържа данни за задачите.");
            }

            return storage;
        }

        public void Save(TodoStorage storage)
        {
         
            string json =
                JsonSerializer.Serialize(storage);

            File.WriteAllText(path, json);
        }
    }
}

