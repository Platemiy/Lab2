using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract class Figure
    {
        public virtual double CalcArea() { return 0; }
        public string Type
        {
            get
            {
                return _Type;
            }
            protected set
            {
                _Type = value;
            }
        }
        string _Type;
        public override string ToString()
        {
            return Type + " площадью " + this.CalcArea().ToString();
        }
    }
    class Rect : Figure, IPrint
    {
        private double _Width;
        public double Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }
        private double _Height;
        public double Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }
        public override double CalcArea()
        {
            return Width * Height;
        }
        public Rect(double w, double h)
        {
            Width = w;
            Height = h;
            this.Type = "Прямоугольник";
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Square : Rect, IPrint
    {
        public Square(double a) : base(a, a) { this.Type = "Квадрат"; }
    }
    class Circle : Figure, IPrint
    {
        private double _Radius;
        public double Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
            }
        }
        public Circle(double r)
        {
            this.Radius = r;
            this.Type = "Круг";
        }
        public override double CalcArea()
        {
            return Radius * Radius * Math.PI;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }
    interface IPrint
    {
        void Print();
    }
    class Program
    {
        static void Main()
        {
            Rect rect = new Rect(5, 4);
            Square square = new Square(5);
            Circle circle = new Circle(5);
            rect.Print();
            square.Print();
            circle.Print();
            rect = square;
            rect.Print();
        }
    }
}
