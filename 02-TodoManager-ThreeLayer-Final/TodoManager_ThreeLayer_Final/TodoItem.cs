using System.Text.Json.Serialization;

namespace TodoManager_ThreeLayer_Final
{
  
internal class TodoItem
    {
        private string title;
        private DateTime dueDate;
        private bool isCompleted;

        [JsonInclude]
        public int Id { get; private set; }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Заглавието е задължително");

                title = value;
            }
        }
        public string Description { get; set; }
        public DateTime DueDate { 
            get
            {
                return dueDate;
            }
            set
            {
                if (value < DateTime.Today)
                    throw new ArgumentException("Крайната дата не трябва да е в миналото");

                dueDate = value;
            }
        }

        [JsonInclude]
        public bool IsCompleted { get
            {
                return isCompleted;
            }
            private set 
            { 
                isCompleted = value;
            } 
        }

        public TodoItem()
        {

        }

        public TodoItem(int id, string title, string description, DateTime dueDate)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id трябва да е положително число");

            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;

        }

        public void Completed()
        {
            if (IsCompleted)
                throw new InvalidOperationException(
                    "Задачата вече е завършена.");

            isCompleted = true;
        }

        public override string ToString()
        {
            var status = IsCompleted ? "Завършена" : "Незавършена";

            return $"{Id}. {Title} | {Description} | {DueDate:d} | {status}";
        }
    }
}
