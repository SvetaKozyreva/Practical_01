
using Practical_01;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using System.Xml;

namespace Practical_01
{
    class Cars
    {
        public static List<Shop> CarsList = new List<Shop>();
        public static void Add(Shop s)
        {
            CarsList.Add(s);
        }
        public static void Show()
        {
            foreach (Shop i in CarsList)
            {
                i.PrintToConsole();
            }
        }
    }
    class Shop
    {
        public string Id { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public int Price { get; private set; }
        public Shop(string id, string model, int year, int price)
        {
            Id = id;
            Model = model;
            Year = year;
            Price = price;
        }
        public void PrintToConsole()
        {
            Console.WriteLine($"Автосалон: {Id}");
            Console.WriteLine($" Марка: {Model}");
            Console.WriteLine($"Рік: {Year}");
            Console.WriteLine($" Ціна: {Price}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\svtko\OneDrive\Робочий стіл\Лаби\ООП2\Practical_01\Practical_01\XMLFile1.xml");
            foreach (XmlNode node in xml.DocumentElement)
            {
                string id = node.Attributes[0].InnerText;
                string model = node["model"].InnerText;
                int year = Int32.Parse(node["year"].InnerText);
                int price = Int32.Parse(node["price"].InnerText);
                Cars.Add(new Shop(id, model, year, price));
            }
            Cars.Show();
        }
    }
}
