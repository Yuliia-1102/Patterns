using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//In Abstract Factory pattern an interface is responsible for creating
//a factory of related objects without explicitly specifying their classes.
//Ця структура дозволяє абстрагувати процес створення конкретних об'єктів від клієнтського коду,
//тим самим надаючи можливість змінювати типи створюваних продуктів без зміни клієнтського коду.
namespace AbstractFactory
{
    public class AbstractFactory
    {
        // AbstractProductA
        abstract class Car
        {
            public abstract void Info();
        }

        // ConcreteProductA1
        class Ford : Car
        {
            public override void Info()
            {
                Console.WriteLine("Ford");
            }
        }

        // ConcreteProductA2
        class Toyota : Car
        {
            public override void Info()
            {
                Console.WriteLine("Toyota");
            }
        }

        // ConcreteProductA3
        class Mercedes : Car
        {
            public override void Info()
            {
                Console.WriteLine("Mercedes");
            }
        }

        // AbstractProductB
        abstract class Engine
        {
            public virtual void GetPower() { }
        }

        // ConcreteProductB1
        class FordEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Ford Engine 4.4");
            }
        }

        // ConcreteProductB2
        class ToyotaEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Toyota Engine 3.2");
            }
        }

        // ConcreteProductB3
        class MercedesEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Mercedes Engine 5.1");
            } 
        }

        // AbstractFactory
        interface ICarFactory
        {
            Car CreateCar();
            Engine CreateEngine();
        }

        // ConcreteFactory1
        class FordFactory : ICarFactory
        {
            Car ICarFactory.CreateCar()
            {
                return new Ford();
            }

            Engine ICarFactory.CreateEngine()
            {
                return new FordEngine();
            }
        }

        // ConcreteFactory2
        class ToyotaFactory : ICarFactory
        {
            Car ICarFactory.CreateCar()
            {
                return new Toyota();
            }

            Engine ICarFactory.CreateEngine()
            {
                return new ToyotaEngine();
            }
        }

        // ConcreteFactory3
        class MercedesFactory : ICarFactory
        {
            Car ICarFactory.CreateCar()
            {
                return new Mercedes();
            }

            Engine ICarFactory.CreateEngine()
            {
                return new MercedesEngine();
            }
        }

        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            Car myCar = carFactory.CreateCar();
            myCar.Info();
            Engine myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            carFactory = new FordFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            carFactory = new MercedesFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            Console.ReadKey();
        }
    }
}