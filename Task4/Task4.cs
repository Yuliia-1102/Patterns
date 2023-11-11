//Написати реалізацію для класу “Ялинка”, який можна за необхідності декорувати ялинковими прикрасами (поля) та
//або гірляндами (метод, що відповідає за те, що “Ялинка” може світитися).Використати шаблон Decorator.


//Цей код є прикладом реалізації шаблону проектування "Декоратор" (Decorator Pattern).
//Шаблон "Декоратор" використовується для динамічного додавання нової функціональності до об'єктів без зміни їхньої структури.
//Це досягається шляхом створення класу декоратора, який "обгортає" оригінальний об'єкт і надає додаткову поведінку.
using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ChristmasTree and two Decorators
            ChristmasTree tree = new ChristmasTree(5);

            TreeDecorations d1 = new TreeDecorations("red", "yellow", "green");
            Garland d2 = new Garland(3);

            // Link decorators
            d1.SetComponent(tree);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }

    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ChristmasTree"
    class ChristmasTree : Component 
    {
        private int height;
        public ChristmasTree(int h) { height = h; }

        public override void Operation()
        {
            Console.WriteLine($"Christmas tree is {height} meters tall.");
        }

    }

    // "Decorator"
    abstract class Decorator : Component 
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "TreeDecorations"
    class TreeDecorations : Decorator
    {
        private string ball1, ball2, ball3;
        public TreeDecorations (string a, string b, string c)
        {
            ball1 = a;
            ball2 = b;
            ball3 = c;
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine($"It has been decorated by {ball1}, {ball2} and {ball3} balls.");
        }
    }

    // "Garland" 
    class Garland : Decorator
    {
        private int garland;
        public Garland(int g) { garland = g; }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine($"It has been decorated by {garland} garlands.");
            TreeIsLighting();
        }

        void TreeIsLighting()
        {
            Console.Write("Christmas tree has been lightened up.");
        }
    }
}