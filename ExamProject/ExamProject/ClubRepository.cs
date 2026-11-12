using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class ClubRepository
    {
        private readonly string filePath;

        public ClubRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public ClubData Load()
        {
            if (!File.Exists(filePath))
            {
                return new ClubData();
            }

            string json = File.ReadAllText(filePath);
            ClubData? data = JsonSerializer.Deserialize<ClubData>(json);

            if (data == null)
                throw new InvalidDataException("Файлът не съдържа данни");

            return data;
        }

        public void Save(ClubData data)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }
    }

    internal class ClubData
    {
        public int NextId { get; set; } = 1;
        public List<Club> Clubs { get; set; } = new List<Club>();
    }
}
