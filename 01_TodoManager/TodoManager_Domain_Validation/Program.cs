namespace TodoManager_Domain_Validation
{
    internal class Program
    {
        private static List<TodoItem> tasks = new List<TodoItem>();
        private static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
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
                try
                {
                    switch (choice)
                    {
                        case "1":{AddTodo(); Console.ReadLine();break;}
                        case "2":{ListAllTodos(); Console.ReadLine();break;}
                        case "3":{CompleteTodo(); Console.ReadLine();break;}
                        case "4":{DeleteTodo(); Console.ReadLine();break;}
                        case "x":{Console.WriteLine("Край на програмата");Console.ReadLine();return;}
                        default:{Console.WriteLine("Невалиден избор.");break;}
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        private static void DeleteTodo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Изтрий задача =======");

            foreach (TodoItem todoItem in tasks)
            {
                Console.WriteLine($"{todoItem.Id}. {todoItem.Title}");
            }
            Console.Write("Избери Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }
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
            Console.WriteLine();
            Console.WriteLine("=====  Маркирай задача като завършена =======");
            foreach (TodoItem todoItem in tasks)
            {
                Console.WriteLine($"{todoItem.Id}. {todoItem.Title}");
            }

            Console.Write("Избери Id: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }
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
                try
                {
                    completedTask.Completed();
                    Console.WriteLine("Задачата е завършена.");
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
            else
                Console.WriteLine("Няма задача с такова ID");

        }

        private static void ListAllTodos()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("===== Всички задачи  =======");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма въведени задачи");
            }
            else
            {
                foreach (TodoItem todoItem in tasks)
                {
                    Console.WriteLine($"{todoItem}");
                }
            }
        }

        private static void AddTodo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Добавяне на задача =======");

            Console.Write("Заглавие:");
            string title = Console.ReadLine();

            Console.Write("Описание:");
            string description = Console.ReadLine();

            Console.Write("Краен срок:");
            DateTime dueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Невалидна дата.Въведи отово!");
                Console.Write("Краен срок: ");
            }

            TodoItem todoItem = new TodoItem(nextId, title, description, dueDate);
            tasks.Add(todoItem);
            nextId++;
            Console.WriteLine("Задачата е добавена.");

        }
    }
}
