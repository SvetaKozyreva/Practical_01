using System.Xml;

namespace Practical_V4
{
    class Dogs
    {
        public static List<Dog> DogsList = new List<Dog>();
        public static void Add(Dog d)
        {
            DogsList.Add(d);
        }
        public static void Show()
        {
            foreach (Dog i in DogsList)
            {
                i.PrintToConsole();
            }
        }
    }
    class Dog
    {
        public string Name{ get; private set; }
        public int Weight { get; private set; }
        public string Color { get; private set; }
        public Dog(string name, int weight, string color)
        {
            Name = name;
            Weight = weight;
            Color = color;
        }
        public void PrintToConsole()
        {
            Console.WriteLine($"Ім'я песика: {Name}");
            Console.WriteLine($" Вага: {Weight}");
            Console.WriteLine($" Колір: {Color}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\svtko\OneDrive\Робочий стіл\Лаби\ООП2\Practical_01\Practical_V\XMLFile1.xml");
            foreach (XmlNode node in xml.DocumentElement)
            {
                string name = node["dogName"].InnerText;
                string color = node["dogColor"].InnerText;
                int weight = Int32.Parse(node["dogWeight"].InnerText);
                Dogs.Add(new Dog(name, weight, color));
            }
            Dogs.Show();
        }
    }
}
