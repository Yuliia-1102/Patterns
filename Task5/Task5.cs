using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Prototype is a creational design pattern that lets you copy
//existing objects without making your code dependent on their classes.
namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IFigure figure = new Rectangle(10, 20);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(15);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Triangle(16, 20, 10);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.Read();
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} і шириною {1}", height, width);
        }
    }

    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return new Circle(this.radius);
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", radius);
        }
    }

    class Triangle : IFigure
    {
        int side1, side2, side3;
        public Triangle(int a, int b, int c)
        {
            side1 = a;
            side2 = b;
            side3 = c;
        }

        public IFigure Clone()
        {
            return new Triangle(this.side1, this.side2, this.side3);
        }

        public void GetInfo()
        {
            Console.WriteLine("Трикутник зі сторонами {0}, {1}, {2}", side1, side2, side3);
        }
    }
}
