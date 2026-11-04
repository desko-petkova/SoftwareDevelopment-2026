namespace StudentRegistration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало на програмата");
            try
            {
                Console.Write("Въведете число: ");
                int number = int.Parse(Console.ReadLine());

                Console.WriteLine($"Въведохте: {number}");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Грешка! Трябва да въведете число.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Край на програмата");

            }

        }
    }
}
