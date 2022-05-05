using System;
namespace MyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Напитки";

            Console.WriteLine("---Мои напитки---");
            try
            {
                View.MyConsole myconsole = new View.MyConsole("drinks.bin");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Программа закончила свою работу ");
            Console.ReadLine();
        }
    }
}
