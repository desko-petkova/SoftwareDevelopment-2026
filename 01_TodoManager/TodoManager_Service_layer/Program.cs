namespace TodoManager_Service_layer
{
    internal class Program
    {
        static TodoService service = new TodoService();
      

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
                        case "3": { CompleteTodo(); break; }
                        case "4": { DeleteTodo(); break; }
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

            service.Delete(id);

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

            service.Complete(id);

            // var todo = new TodoItem(34, "sfa", "sfafaa", new DateTime(2026, 11, 26));
            //// var todos = service.GetAll();
            // todos.Add(todo);

            Console.WriteLine("Задачата е завършена.");


        }

        private static void ListAllTodos()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("===== Всички задачи  =======");

            var todos = service.GetAll();

            if (todos.Count == 0)
            {
                Console.WriteLine("Няма въведени задачи");
            }
            else
            {
                foreach (TodoItem todoItem in todos)
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

            service.Add(title, description, dueDate);

            Console.WriteLine("Задачата е добавена.");

        }
    }
}

