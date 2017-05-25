using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        class road
        {
            public int city1;
            public int city2;
            public double distance;

            public road(int city1, int city2, double distance)
            {
                this.city1 = city1;
                this.city2 = city2;
                this.distance = distance;
            }
        }

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

        static void Main(string[] args)
        {            
            Console.WriteLine("Enter number of cities:");
            String s = Console.ReadLine();
            int number = int.Parse(s);

            Point[] Cities = new Point[number];
            double[,] w = new double[number, number];

            for (int i = 0; i < number; i++)
                for (int j = 0; j < number; j++)
                    w[i, j] = Double.PositiveInfinity;

            Console.WriteLine("Enter your choise:\n1. Generate Cities\n2. Enter Cities");
            char choise = Convert.ToChar(Console.ReadLine());
            switch (choise)
            {
                case '1':
                    GenerateCities();
                    break;
                case '2':
                    EnterCities();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }

            Console.WriteLine("Enter number of roads:");
            String s3 = Console.ReadLine();
            int m = int.Parse(s3);

            int m1 = (number * (number - 1) / 2);

            road[] roads = new road[m1];
            HashSet<road> AllRoads = new HashSet<road>();
            road[] tree = new road[m1];

            Intialize();
            if (m > 0)
            {
                Console.WriteLine("Enter your choise:\n1. Generate Roads\n2. Enter Roads");
                char choise1 = Convert.ToChar(Console.ReadLine());
                switch (choise1)
                {
                    case '1':
                        GenerateRoads();
                        break;
                    case '2':
                        EnterRoads();
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
            bool[] visit = new bool[number];
            int s4 = 0;

            PrimAlgorithm();

            Output();



            double GetDistance(Point point1, Point point2)
            {
                return Math.Sqrt(Math.Pow((point1.GetX() - point2.GetX()), 2) + Math.Pow((point1.GetY() - point2.GetY()), 2));
            }

            void Output()
            {
                for (int i = 0; i < s4; i++)
                {
                    Console.WriteLine("\nRoad №" + (i + 1) + ":");
                    Console.WriteLine("City №" + tree[i].city1 + ":\nx: " + Cities[tree[i].city1 - 1].GetX() + "\ny: " + Cities[tree[i].city1 - 1].GetY());
                    Console.WriteLine("City №" + tree[i].city2 + ":\nx: " + Cities[tree[i].city2 - 1].GetX() + "\ny: " + Cities[tree[i].city2 - 1].GetY());
                    Console.WriteLine("Distance:" + tree[i].distance);
                }
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }

            void GenerateCities()
            {
                Random random = new Random();
                for (int i = 0; i < number; i++)
                {
                    double x = random.Next(-100, 100);
                    double y = random.Next(-100, 100);

                    Cities[i] = new Point(x, y);
                }
            }

            void EnterCities()
            {
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("City №" + (i + 1) + "\nEnter x: ");
                    String s1 = Console.ReadLine();
                    double x = double.Parse(s1);

                    Console.WriteLine("Enter y: ");
                    String s2 = Console.ReadLine();
                    double y = double.Parse(s2);

                    Cities[i] = new Point(x, y);
                }
            }

            void Intialize()
            {
                int index = 0;
                for (int i = 0; i < number; i++)
                    for (int j = 0; j < number; j++)
                    {
                        if (i < j)
                        {
                            roads[index++] = new road(i, j, GetDistance(Cities[i], Cities[j]));
                            w[i, j] = GetDistance(Cities[i], Cities[j]);
                            w[j, i] = w[i, j];
                        }
                    }
            }

            void GenerateRoads()
            {
                Random random = new Random();
                for (int i = 0; i < m; i++)
                {
                    bool flag = true;
                    while (flag)
                    {
                        int x = random.Next(0, number - 1);
                        int y = random.Next(0, number - 1);

                        if (AllRoads.Add(new road(x, y, 0)))
                        {
                            roads[i] = new road(x - 1, y - 1, 0);
                            w[x, y] = 0;
                            w[y, x] = 0;
                            flag = false;
                        }
                    }
                }
            }

            void EnterRoads()
            {
                for (int i = 0; i < m; i++)
                {
                    Console.WriteLine("Road №" + (i + 1) + "\nEnter City №1: ");
                    String s1 = Console.ReadLine();
                    int x = int.Parse(s1);

                    Console.WriteLine("Enter City №2: ");
                    String s2 = Console.ReadLine();
                    int y = int.Parse(s2);

                    roads[i] = new road(x - 1, y - 1, 0);

                    w[x - 1, y - 1] = 0;
                    w[y - 1, x - 1] = 0;
                }
            }

            void PrimAlgorithm()
            {
                for (int i = 0; i < number; i++)
                {
                    visit[i] = false;
                }

                bool e = true;
                double road = Double.PositiveInfinity;
                int v1 = -1;
                for (int i = 0; i < m1; i++)
                {
                    if (road > roads[i].distance)
                    {
                        road = roads[i].distance;
                        v1 = roads[i].city1;
                    }
                }
                visit[v1] = true;
                while (e)
                {
                    e = false;
                    bool e1 = false;
                    if (!e1)
                    {
                        int city1 = -1;
                        int city2 = -1;
                        double road1 = Double.PositiveInfinity;
                        for (int i = 0; i < number; i++)
                        {
                            for (int j = 0; j < number; j++)
                            {
                                if ((visit[i] == true) && (visit[j] == false) && (w[i, j] < road1))
                                {
                                    city1 = i;
                                    city2 = j;
                                    road1 = w[i, j];
                                }
                            }

                        }
                        if ((city1 != -1) && (city2 != -1))
                        {
                            e1 = true;
                            visit[city2] = true;
                            tree[s4++] = new road(city1 + 1, city2 + 1, road1);
                        }
                    }
                    for (int i = 0; i < number; i++)
                        if (visit[i] == false) e = true;
                }
            }
        }
    }
}
