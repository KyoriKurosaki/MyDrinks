using System;
namespace MyDrinks.Model
{
    [Serializable]
    ///<summary>
    ///
    /// </summary>
    internal class Record
    {
        public string nameofdrink { get; set; }
        public DateTime DateRecord { get; private set; }
        public string typeofdrink { get; set; }

        public Record(string NameOfDrink, string PriceOfDrink)
        {
            nameofdrink = NameOfDrink;
            DateRecord = DateTime.Now;
            typeofdrink = PriceOfDrink;
        }
        public override string ToString()
        {
            return $"Дата добавления напитка: {DateRecord}, " + $"Название напитка: {nameofdrink}\n" +
                   $"Тип напитка: {typeofdrink}\n";
        }
    }
}

