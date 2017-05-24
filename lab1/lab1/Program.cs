using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        class Point
        {
            double x;
            double y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public Point()
            {
                x = 0;
                y = 0;
            }

            public double GetX()
            {
                return x;
            }

            public double GetY()
            {
                return y;
            }

            public void SetX(double x)
            {
                this.x = x;
            }

            public void SetY(double y)
            {
                this.y = y;
            }
        }

        double GetDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow( (point1.GetX() - point2.GetX()), 2) + Math.Pow((point1.GetY() - point2.GetY()), 2));
        }

        static void Main(string[] args)
        {
            Point a = new Point(1, 1);
            Console.WriteLine("Hello world!!!");
            Console.ReadKey();
        }
    }
}
