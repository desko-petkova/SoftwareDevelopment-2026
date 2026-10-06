namespace TodoManager_Simple
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem(int id, string title, string description, DateTime dueDate)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }
    internal class Program
    {
        private static List<TodoItem> tasks = new List<TodoItem>();
        private static int nextId = 1;

        static void Main(string[] args)
        {

           // Program program = new Program();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("======= TODO MANAGER ========");
                Console.WriteLine("1. Добави задача");
                Console.WriteLine("2. Покажи задачи");
                Console.WriteLine("3. Маркирай задача като изпълнена");
                Console.WriteLine("4. Изтрий задача");
                Console.WriteLine("x. Изход");

                Console.WriteLine();
                Console.Write("Избор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":
                        {
                            AddTodo();
                           
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            ListAllTodos();                            
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            CompleteTodo();                           
                            Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            DeleteTodo();                           
                            Console.ReadLine();
                            break;
                        }
                    case "x":
                        {
                            Console.WriteLine("Край на програмата");
                            Console.ReadLine();
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Невалиден избор.");

                            break;

                        }
                }

            }
        }

        private static void DeleteTodo()
        {
            Console.Clear();
            Console.WriteLine("=====  Изтрий задача =======");

            foreach (TodoItem todoItem in tasks)
            {
                Console.WriteLine($"{todoItem.Id}. {todoItem.Title}");
            }
            Console.Write("Избери Id: ");
            int id = int.Parse(Console.ReadLine());
            TodoItem deleteTask = null;

            foreach (TodoItem todoItem in tasks)
            {
                if (todoItem.Id == id)
                {
                    deleteTask = todoItem;
                    break;
                }

            }
            if (deleteTask != null)
            {
                tasks.Remove(deleteTask);
                Console.WriteLine("Задачата е изтрита.");
            }
            else
                Console.WriteLine("Няма задача с такова ID");

        }

        private static void CompleteTodo()
        {
            Console.Clear();
            Console.WriteLine("=====  Маркирай задача като завършена =======");
            foreach (TodoItem todoItem in tasks)
            {
                Console.WriteLine($"{todoItem.Id}. {todoItem.Title}");
            }
            Console.Write("Избери Id: ");
            int id = int.Parse(Console.ReadLine());
            TodoItem completedTask = null;

            foreach (TodoItem todoItem in tasks)
            {
                if (todoItem.Id == id)
                {
                    completedTask = todoItem;
                    break;
                }

            }
            if (completedTask != null)
            {
                completedTask.IsCompleted = true;
                Console.WriteLine("Задачата е завършена.");
            }
            else
                Console.WriteLine("Няма задача с такова ID");

        }

        private static void ListAllTodos()
        {
            Console.Clear();
            Console.WriteLine("===== Всички задачи  =======");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма въведени задачи");
            }
            else
            {

                foreach (TodoItem todoItem in tasks)
                {
                    string status = "";
                    if (todoItem.IsCompleted) status = "Завършена";
                    else status = "Незавършена";

                    Console.WriteLine($"{todoItem.Id}. {todoItem.Title}" +
                        $"\n {todoItem.Description}" +
                        $"\n {todoItem.DueDate:d}" +
                        $"\n Статус: {status}");
                }
            }
        }

        private static void AddTodo()
        {
            Console.Clear();
            Console.WriteLine("=====  Добавяне на задача =======");
            Console.Write("Заглавие:");
            string title = Console.ReadLine();

            Console.Write("Описание:");
            string description = Console.ReadLine();

            Console.Write("Краен срок:");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            TodoItem todoItem = new TodoItem(nextId, title, description, dueDate);
            tasks.Add(todoItem);
            nextId++;
            Console.WriteLine("Задачата е добавена.");
        }
    }
}

