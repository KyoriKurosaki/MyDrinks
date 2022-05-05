using System;
namespace MyDrinks.View
{
    internal class MyConsole
    {
        private Controller.RecordController records;
        public MyConsole(string path)
        {
            try
            {
                records = new Controller.RecordController(path);
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Start()
        {
            PrintMenu();
            while (true)
            {
                try
                {
                    switch (GetStringConsole("Введите команду -").ToLower())
                    {
                        case "/help": PrintMenu(); break;
                        case "/get": GetDrink(); break;
                        case "/add": AddDrink(); break;
                        case "/exit": return;
                        default:
                            Console.WriteLine("Неизвестная команда!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void AddDrink()
        {
            string NameOfDrink = GetStringConsole("Введите название напитка");
            string TypeOfDrink = GetStringConsole("Укажите тип напитка : (к примеру: прохладительные, алкогольные, соки, газированные или тонизирующие напитки) ");
            records.add(NameOfDrink, TypeOfDrink);
            Console.WriteLine("Напиток добавлен :)");
            GetDrink();
        }
        private void GetDrink()
        {
            if(records.Records.Count == 0)
            {
                Console.WriteLine("Добавленные напитки отсутствуют!");
                return;
            }
            foreach (var item in records.Records)
            {
                Console.WriteLine(item);
            }
        }
        private void PrintMenu()
        {
            Console.WriteLine("/help - список команд");
            Console.WriteLine("/get - получить список напитков");
            Console.WriteLine("/add - добавить новый напиток");
            Console.WriteLine("/exit - выход из программы");
        }
        private string GetStringConsole(string v)
        {
            Console.WriteLine(v);
            var s = Console.ReadLine();
            if(string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Некорректный ввод!");
                return GetStringConsole(v);
            }
            return s.TrimStart().TrimEnd();
        }
    }
}
