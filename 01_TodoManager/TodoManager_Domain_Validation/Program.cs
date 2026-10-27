namespace TodoManager_Domain_Validation
{
    internal class Program
    {
        private readonly static List<TodoItem> tasks = new List<TodoItem>();
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
                        case "1": { AddTodo(); break; }
                        case "2": { ListAllTodos(); break; }
                        case "3": { CompleteTodo();  break; }
                        case "4": { DeleteTodo();  break; }
                        case "x": { Console.WriteLine("Край на програмата"); Console.ReadLine(); return; }
                        default: { Console.WriteLine("Невалиден избор."); break; }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }

        private static void DeleteTodo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Изтрий задача =======\n");
            ListAllTodos();

            Console.Write("Избери Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }

            TodoItem deleteTask = FindById(id);

            tasks.Remove(deleteTask);
            Console.WriteLine("Задачата е изтрита.");

        }

        private static void CompleteTodo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Маркирай задача като завършена =======\n");
            ListAllTodos();

            Console.Write("Избери Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }

            TodoItem completedTask = FindById(id);
            completedTask.Completed();
            Console.WriteLine("Задачата е завършена.");


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

        static TodoItem FindById(int id)
        {
            TodoItem targetTodo = null;
            foreach (TodoItem todoItem in tasks)
            {
                if (todoItem.Id == id)
                {
                    targetTodo = todoItem;
                    break;
                }

            }
            if (targetTodo == null)
                throw new ArgumentException("Няма задача с такова ID");

            return targetTodo;
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
