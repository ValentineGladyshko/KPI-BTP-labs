using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Picture MyPicture = new Picture();
            MyPicture.Changing += ChangingListener;
            MyPicture.Add(new Rectangle(4, 3, 5));
            MyPicture.Add(new Trapezium(4, 6, 3, 4));
            MyPicture.Insert(0, new Circle(3));
            MyPicture.Add(new Rectangle(6, 5, 4) + new Rectangle(1, 2, 4));
            MyPicture.Add(new Circle(37));
            MyPicture.Delete(1);
            Console.WriteLine(MyPicture);


            try
            {
                MyPicture.Get(100);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("IndexOutOfRangeException");
            }

            try
            {
                Circle x = (Circle)MyPicture.Get(0) / 0;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DivideByZeroException");
            }

            Console.WriteLine((Circle)MyPicture.Get(0) == new Circle(1) * 3);
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        public static void ChangingListener(ChangingType change)
        {
            switch (change)
            {
                case ChangingType.Add:
                    Console.WriteLine("Added Element");
                    break;
                case ChangingType.Delete:
                    Console.WriteLine("Deleted Element");
                    break;
                case ChangingType.Set:
                    Console.WriteLine("Setted Element");
                    break;
                case ChangingType.Insert:
                    Console.WriteLine("Inserted Element");
                    break;
            }
        }
    }


    public abstract class Figure
    {
        public abstract double square();
        public abstract double perimeter();

        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }

    public class Rectangle : Figure
    {
        public Rectangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Rectangle() { }

        private double a
        {
            get;
            set;
        }

        private double b
        {
            get;
            set;
        }

        private double c
        {
            get;
            set;
        }

        public override double square()
        {
            return Math.Sqrt(((a + b + c) / 2) * (((a + b + c) / 2) - a) * (((a + b + c) / 2) - b) * (((a + b + c) / 2) - c));
        }

        public override double perimeter()
        {
            return a + b + c;
        }

        public static Rectangle operator +(Rectangle x, Rectangle y)
        {
            Rectangle tmp = new Rectangle();
            tmp.a = x.a + y.a;
            tmp.b = x.b + y.b;
            tmp.c = x.c + y.c;
            return tmp;
        }

        public static Rectangle operator -(Rectangle x, Rectangle y)
        {
            Rectangle tmp = new Rectangle();
            tmp.a = x.a - y.a;
            tmp.b = x.b - y.b;
            tmp.c = x.c - y.c;
            return tmp;
        }

        public static Rectangle operator *(Rectangle x, double y)
        {
            Rectangle tmp = new Rectangle();
            tmp.a = x.a * y;
            tmp.b = x.b * y;
            tmp.c = x.c * y;
            return tmp;
        }

        public static Rectangle operator /(Rectangle x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();
            Rectangle tmp = new Rectangle();
            tmp.a = x.a / y;
            tmp.b = x.b / y;
            tmp.c = x.c / y;
            return tmp;
        }

        public override bool Equals(object x)
        {
            Rectangle obj = (Rectangle)x;
            if (a == obj.a && b == obj.b && c == obj.c) return true;
            else return false;
        }

        public static bool operator ==(Rectangle x, Rectangle y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Rectangle x, Rectangle y)
        {
            return !Equals(x, y);
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() + 13 * b.GetHashCode() + 169 * c.GetHashCode();
        }

        public override string ToString()
        {
            return "Rectangle: (" + a.ToString() + "," +
                   b.ToString() + "," + c.ToString() + ")";
        }

    }

    public class Circle : Figure
    {

        public Circle(double r)
        {
            this.r = r;
        }

        public Circle() { }

        private double r
        {
            get;
            set;
        }

        public override double square()
        {
            return Math.PI * r * r;
        }

        public override double perimeter()
        {
            return 2 * Math.PI * r;
        }

        public static Circle operator +(Circle x, Circle y)
        {
            Circle tmp = new Circle();
            tmp.r = x.r + y.r;
            return tmp;
        }

        public static Circle operator -(Circle x, Circle y)
        {
            Circle tmp = new Circle();
            tmp.r = x.r - y.r;
            return tmp;
        }

        public static Circle operator *(Circle x, double y)
        {
            Circle tmp = new Circle();
            tmp.r = x.r * y;
            return tmp;
        }

        public static Circle operator /(Circle x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();
            Circle tmp = new Circle();
            tmp.r = x.r / y;
            return tmp;
        }

        public override bool Equals(object x)
        {
            Circle obj = (Circle)x;
            if (r == obj.r) return true;
            else return false;
        }

        public static bool operator ==(Circle x, Circle y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Circle x, Circle y)
        {
            return !Equals(x, y);
        }

        public override int GetHashCode()
        {
            return r.GetHashCode();
        }

        public override string ToString()
        {
            return "Cone: (" + r.ToString() + ")";
        }
    }

    public class Trapezium : Figure
    {
        public Trapezium(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Trapezium() { }

        private double a
        {
            get;
            set;
        }

        private double b
        {
            get;
            set;
        }

        private double c
        {
            get;
            set;
        }

        private double d
        {
            get;
            set;
        }

        public override double square()
        {
            double h = (Math.Sqrt((-a + b + c + d) * (a - b + c + d) * (a - b + c - d) * (a - b - c + d))) / (2 * Math.Abs(a - b));
            return ((a + b) / 2) * h;
        }

        public override double perimeter()
        {
            return a + b + c + d;
        }

        public static Trapezium operator +(Trapezium x, Trapezium y)
        {
            Trapezium tmp = new Trapezium();
            tmp.a = x.a + y.a;
            tmp.b = x.b + y.b;
            tmp.c = x.c + y.c;
            tmp.d = x.d + y.d;
            return tmp;
        }

        public static Trapezium operator -(Trapezium x, Trapezium y)
        {
            Trapezium tmp = new Trapezium();
            tmp.a = x.a - y.a;
            tmp.b = x.b - y.b;
            tmp.c = x.c - y.c;
            tmp.d = x.d - y.d;
            return tmp;
        }

        public static Trapezium operator *(Trapezium x, double y)
        {
            Trapezium tmp = new Trapezium();
            tmp.a = x.a * y;
            tmp.b = x.b * y;
            tmp.c = x.c * y;
            tmp.d = x.d * y;
            return tmp;
        }

        public static Trapezium operator /(Trapezium x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();
            Trapezium tmp = new Trapezium();
            tmp.a = x.a / y;
            tmp.b = x.b / y;
            tmp.c = x.c / y;
            tmp.d = x.d / y;
            return tmp;
        }

        public override bool Equals(object x)
        {
            Trapezium obj = (Trapezium)x;
            if (a == obj.a && b == obj.b && c == obj.c && d == obj.d) return true;
            else return false;
        }

        public static bool operator ==(Trapezium x, Trapezium y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Trapezium x, Trapezium y)
        {
            return !Equals(x, y);
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() + 13 * b.GetHashCode() + 169 * c.GetHashCode() + 2197 * d.GetHashCode();
        }

        public override string ToString()
        {
            return "Trapezium: (" + a.ToString() + "," + b.ToString() + "," + 
                   c.ToString() + "," + d.ToString() + ")";
        }
    }

    public enum ChangingType { Add, Insert, Delete, Set }
    public delegate void ChangeHandler(ChangingType change);

    public class Picture
    {
        public List<Figure> Elements
        {
            get;
        }

        public event ChangeHandler Changing;

        public Picture()
        {
            Elements = new List<Figure>();
        }

        public void Add(Figure element)
        {
            Elements.Add(element);
            if (Changing != null) Changing(ChangingType.Add);
        }

        public Figure Get(int index)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            return Elements[index];
        }

        public void Set(int index, Figure element)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            Elements[index] = element;
            if (Changing != null) Changing(ChangingType.Set);
        }

        public void Insert(int index, Figure element)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            Elements.Insert(index, element);
            if (Changing != null) Changing(ChangingType.Insert);
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            Elements.RemoveAt(index);
            if (Changing != null) Changing(ChangingType.Delete);
        }

        public override string ToString()
        {
            return "\nMy Picture:\n" + string.Join("\n", Elements) + "\n";
        }
    }

    public class MyExeption : Exception
    {
        MyExeption(String str) : base("MyExeption: " + str) { }
    }


}
