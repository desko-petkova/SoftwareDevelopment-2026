namespace ExamProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Добавяне на клуб");
                Console.WriteLine("2. Показване на всички клубове");
                Console.WriteLine("3. Изтриване на клуб по Id");
                Console.WriteLine("4. Филтриране по дата");
                Console.WriteLine("0. Изход");
                Console.Write("Избор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        ShowAll();
                        break;
                    case "3":
                        Delete();
                        break;
                    case "4":
                        FilterByDate();
                        break;
                    case "0":
                    case null:
                        return;
                }
            }
        }

        static void Add()
        {
            Console.Write("Въведи име: ");
            string name = Console.ReadLine();
            Console.Write("Въведи ден: ");
            DateOnly day;
            while (!DateOnly.TryParse(Console.ReadLine(), out day))
            {
                Console.Write("Невалиден формат. Опитай пак: ");
            }


            Console.WriteLine("Клубът е добавен.");
        }

        static void ShowAll()
        {
            Console.WriteLine("Предстои реализиране на показването.");
        }

        static void Delete()
        {
            Console.WriteLine("Предстои реализиране на изтриването.");
        }

        static void FilterByDate()
        {
            DateOnly dateOnly = new DateOnly();
            Console.Write("Избеви ден:");
            while (!DateOnly.TryParse(Console.ReadLine(), out dateOnly))
            {
                Console.WriteLine("Невалиден ден. Опитай пак: ");
            }

            Console.WriteLine("Предстои реализиране на филтрирането.");
        }
    }

}
