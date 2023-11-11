using System;
using System.Collections;
namespace CompositeExample

//Composite is a structural design pattern that lets you compose objects into tree structures
//and then work with these structures as if they were individual objects.
{
    class MainApp
    {
        static void Main()
        {
            //Create a tree structure
            //Старший офіцерський склад ЗСУ
            Component officer1 = new Composite("Полковник");
            officer1.Add(new Leaf("Підполковник"));
            officer1.Add(new Leaf("Майор|"));

            //Молодщий офіцерський склад ЗСУ
            Component officer2 = new Composite("Капітан");
            officer2.Add(new Leaf("Старший лейтенант"));
            officer2.Add(new Leaf("Лейтенант"));
            officer2.Add(new Leaf("Молодший лейтенант|"));

            officer1.Add(officer2);

            //Add and remove a leaf
            Leaf leaf = new Leaf("Бригадний генерал");
            officer1.Add(leaf);
            officer1.Remove(leaf);
            //Recursively display tree
            officer1.Display(1);

            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
    // "Composite"
    class Composite : Component
    {
        private ArrayList children = new ArrayList();
        public Composite(string name)
            : base(name)
        {

        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);

            // Recursively display child nodes
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    // "Leaf"
    class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        {

        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }

    }
}