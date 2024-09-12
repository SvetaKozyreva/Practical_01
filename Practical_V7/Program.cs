using System.Drawing;
using System.Xml;

namespace Practical_V7
{
    class Breakfast
    {
        public static List<Food> BreakfastList = new List<Food>();
        public static void Add(Food f)
        {
            BreakfastList.Add(f);
        }
        public static void Show()
        {
            foreach (Food i in BreakfastList)
            {
                i.PrintToConsole();
            }
        }
    }
    class Food
    {
        public string Name { get; private set; }
        public string Price { get; private set; }
        public string Description { get; private set; }
        public int Calories { get; private set; }
        public Food(string name, string price, string description, int calories)
        {
            Name = name;
            Price = price;
            Description = description;
            Calories = calories;
        }
        public void PrintToConsole()
        {
            Console.WriteLine($"Назва: {Name}");
            Console.WriteLine($" Ціна: {Price}");
            Console.WriteLine($" Опис: {Description}");
            Console.WriteLine($" Калорії: {Calories}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\svtko\OneDrive\Робочий стіл\Лаби\ООП2\Practical_01\Practical_V7\XMLFile1.xml");
            foreach (XmlNode node in xml.DocumentElement)
            {
                string name = node["name"].InnerText;
                string price = node["price"].InnerText;
                string description = node["description"].InnerText;
                int calories = Int32.Parse(node["calories"].InnerText);
                Breakfast.Add(new Food(name, price, description, calories));
            }
            Breakfast.Show();
        }
    }
}
