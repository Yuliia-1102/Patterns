using System;

//"Factory Method" — шаблон проектування, який використовується для створення об'єкта,
//не специфікуючи точний клас об'єкта, який буде створено. Це досягається шляхом визначення інтерфейсу
//для створення об'єкта. Шаблон дозволяє підкласам змінювати тип створюваних об'єктів.
namespace FactoryMethodExample
{
    public abstract class Creator
    {
        public abstract Sweets CreateSweets(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Sweets CreateSweets(int type)
        {
            switch (type)
            {
                case 1: return new ChocolateBar(2, 60.99, "white chocolate bars with nuts");
                case 2: return new StrawberryCake(3, 120.38, "big", "A jar of sprinkles");
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Sweets
    {
        public int number;
        public double price;
        public Sweets(int n, double p) { number = n; price = p; }

        public abstract void Info();
    }

    //конкретні продукти з різною реалізацією
    public class ChocolateBar : Sweets
    {
        public string description;
        public ChocolateBar(int n, double p, string d) : base(n, p)
        {
            description = d;
        }

        public override void Info()
        {
            Console.WriteLine($"{number} {description} have been made with total price of {price} USD.");
        }

    }

    public class StrawberryCake : Sweets
    {
        private string size;
        private string gift;
        public StrawberryCake(int n, double p, string s, string g) : base(n, p)
        {
            size = s;
            gift = g;
        }

        public override void Info()
        {
            Console.WriteLine($"{number} {size} strawberry cakes have been made with total price of {price} USD. {gift} goes as a gift.");
        }

    }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 2; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var candy = creator.CreateSweets(i);
                candy.Info();
            }
            Console.ReadKey();
        }
    }
}