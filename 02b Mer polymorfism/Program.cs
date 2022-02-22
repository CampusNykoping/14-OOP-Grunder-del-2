/*
 * Kodexempel från Microsoft, https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
 * 
*/
using System;

namespace _02b_Mer_polymorfism
{
    public class Shape
    {
        public const double PI = Math.PI;
        protected double x, y;  // Sidor
        public Shape()
        {

        }
        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual double Area()
        {
            return x * y;
        }
    }

    public class Circle : Shape
    {
        public Circle(double r) : base(r, 0)
        {

        }
        public override double Area()
        {
            return PI * x * x;
        }
    }
    class Sphere : Shape
    {
        public Sphere(double r) : base(r, 0)
        {

        }
        public override double Area()
        {
            return 4 * PI * x * x;
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(double h, double w) : base(h, w)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double r = 3.0, h = 5.0;
            
            Shape c = new Circle(r);
            Shape s = new Sphere(r);
            Shape re = new Rectangle(r, h);

            // Räkna ut och visa areorna
            Console.WriteLine("Cirkelns area    = {0:F2}", c.Area());
            Console.WriteLine("Sfärens area     = {0:F2}", s.Area());
            Console.WriteLine("Rektangelns area = {0:F2}", re.Area());


            Console.ReadKey();
        }
    }
}
