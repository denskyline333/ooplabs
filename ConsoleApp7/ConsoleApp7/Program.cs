using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace ConsoleApp7
{
    public interface IInter
    {
        void What();
    }
    public interface IInterface
    {
        void Print();
    }
    abstract class Transport : IInterface
    {
        public string airplane;
        public abstract void Print();
        public Transport(string air)
        {
            airplane = air;
        }
    }

    class Aviation : Transport, IComparable
    {
        public int maxh { get; set; }
        public int CompareTo(object obj)
        {
            Aviation aviation = (Aviation)obj;
            if (this.maxh > aviation.maxh) return 1;
            if (this.maxh < aviation.maxh) return -1;
            return 0;
        }
        public override void Print()
        {
            Console.WriteLine("Aviation types are: ");
        }

        public int capacity;
        public Aviation(string air, int maxh, int capacity) : base(air)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.capacity = capacity;
        }
        public Aviation(string a) : base(a) { }
    }

    class Cargo : Aviation, IInter
    {
        public void What()
        {
            if (maxh > 9000)
            {
                Console.WriteLine("This airplane is good");
            }
        }
        public string cargo;
        public int price;
        public Cargo(string air, int maxh, string cargo, int price, int capacity) : base(air, maxh, capacity)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.cargo = cargo;
            this.price = price;
            this.capacity = capacity;
        }
        public override string ToString()
        {
            return ("Airplane - " + airplane + " | max height is " + maxh + " | capacity is - " + capacity);
        }
    }
    class Passenger : Aviation
    {
        public int amount;
        public Passenger(string air, int maxh, int amount, int capacity) : base(air, maxh, capacity)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.capacity = capacity;
            this.amount = amount;
        }
        public override string ToString()
        {
            return ("Airplane - " + airplane + " | max height is " + maxh + " | capacity is - " + capacity);
        }
    }
    class Military : Aviation
    {
        public Military(string a) : base(a) { }
        public float speed;
        public Military(string air, int maxh, float speed, int capacity) : base(air, maxh, capacity)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.speed = speed;
            this.capacity = capacity;
        }
        public override string ToString()
        {
            return ("Airplane - " + airplane + " | max height is " + maxh + " | speed is " + speed + " | capacity is - " + capacity);
        }
        virtual public void Guns()
        {
            Console.WriteLine("Miliraty airplane has some guns");
        }
    }
    partial class Ty134 : Military, IInterface
    {
        public override void Print()
        {
            if (speed > 300f && maxh > 12000)
            {
                Console.WriteLine("Ty134 has speed>300f and maxh>12000");
            }
        }
        public string guns;
        public Ty134(string air, int maxh, float speed, string guns, int capacity) : base(air, maxh, speed, capacity)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.speed = speed;
            this.guns = guns;
            this.capacity = capacity;
            if (speed < 0)
            {
                throw new MyException("Скорость не может быть < 0 ");
            }
        }
        #region code
        public override string ToString()
        {
            return ("Airplane - " + airplane + " | max height is " + maxh + " | speed is " + speed + " | guns are " + guns);
        }
        public override void Guns()
        {
            if (guns == "AWP" || guns == "Nuclear bomb")
            {
                Console.WriteLine("Ty134 is better than Boeing");
            }
        }

    }
    class Boeing : Military
    {
        public string guns;
        public Boeing(string air, int maxh, float speed, string guns, int capacity) : base(air, maxh, speed, capacity)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.speed = speed;
            this.guns = guns;
            this.capacity = capacity;
            if(speed < 0)
            {
                throw new ArgumentException("Скорость не может быть < 0");
            }
        }
        public override string ToString()
        {
            return ("Airplane - " + airplane + " | max height is " + maxh + " | speed is " + speed + " | guns are " + guns);
        }
        public override void Guns()
        {
            if (speed > 500f)
            {
                Console.WriteLine("Boeing faster than Ty134");
            }
        }
    }
    public class Point : Object
    {
        public string Name { get; set; }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            Point t = (Point)obj;
            return (Name == t.Name);
        }
        public override int GetHashCode()
        {
            int hash = 69;
            return base.GetHashCode() / hash;
        }
    }
    sealed class Printer
    {
        public string IAmPrinting(Transport obj)
        {
            Type perem = obj.GetType();
            return perem.ToString();
        }
    }

    internal partial class A
    {
        public void Method1()
        {
            Console.WriteLine("A1");
        }
    }
    #endregion 

    public class MyException : Exception
    {
        public MyException(string message ):base(message)
        {
        }       
    }
    public class FirstException : MyException
    {
        public FirstException(string message):base(message)
        {
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
           
            try
            {
                Aviation av = new Aviation("Aiplanes", 12000, 500);
                Aviation c = new Cargo("Cargo ", 10000, "cars", 78000, 100);
                Aviation p = new Passenger("Passenger ", 8000, 450, 480);
                Aviation m = new Military("Military ", 19000, 415f, 20);
                Aviation t = new Ty134("Ty134 ", 13000, 380f, "Nuclear bomb", 17);
                Aviation b = new Boeing("Boeing", 16000, 510f, "Insane rockets", 15);            
                Aviation b2 = new Boeing("Boeing", 13000, -400f, "awp", 23);          
                Console.WriteLine(c.ToString());
                Console.WriteLine(p.ToString());
                Console.WriteLine(m.ToString());
                Console.WriteLine(t.ToString());
                Console.WriteLine(b.ToString());
                Console.WriteLine();
                Console.WriteLine("Работа с struct:");
                Water water = new Water("aqua", 100);
                water.Show();
                Console.WriteLine();
                Console.WriteLine("Работа с enum:");
                First.MathOp(18, 6, First.Operation.substract);
                First.Table(First.Days.Wednesday);
                A a = new A();
                // a.Method1();
                //  a.Method2();
                Console.WriteLine();
                AviationCompany acom = new AviationCompany(c, p, m);
                Controller acompany = new Controller(acom);
                Console.WriteLine("Средняя вместимость самолетов - " + acompany.AVGcapacity());
                AviationCompany ac = new AviationCompany(m, b, t);
                Controller acomp = new Controller(ac);
                Console.WriteLine("Поиск самолетов по скорости >385 and <600");
                acomp.Speed();
                Console.WriteLine();
                Console.WriteLine("Сортировка по дальности полета");
                Aviation[] aviations = new Aviation[] { c, p, b, t, m };
                Array.Sort(aviations);

                foreach (Aviation x in aviations)
                {
                    Console.WriteLine("Airplane - " + x.airplane + "с высотой " + x.maxh);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
            }

            try
                {
                    int a = 0;
                    int b = 44 / a;
                    int c = b;
                    throw new DivideByZeroException();
                }
                catch (DivideByZeroException ep)
                {
                    Console.WriteLine("Ошибка " + ep.Message);
                    Console.WriteLine(ep.TargetSite);
                    Console.WriteLine("Место ошибки: " + ep.StackTrace);   
                }

                string str = "";
                Console.WriteLine("Введите число: ");
                try
                {
                    int str2 = Convert.ToInt32(Console.ReadLine());
                    str = "Вы ввели число" + str2;
                }
                catch (FormatException er) 
                {
                    Console.WriteLine("Ошибка " + er.Message);
                
                }


                int[] mas = new int[3];
                try
                {
                    mas[1] = 1;
                    mas[5] = 4;
                }
                catch (IndexOutOfRangeException er)
                {
                    Console.WriteLine("Ошибка индекса: " + er.Message);
                }
                finally
                {
                    Console.WriteLine("Проверьте корректность массива!");
                }
                Console.WriteLine();

                FileStream file = null;
                try
                {
                    file = new FileStream("D:log.txt", FileMode.Open);
                    StreamReader sread = new StreamReader(file);
                    string line;
                    line = sread.ReadLine();
                    Console.WriteLine(line);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("Ошибка " + e.FileName + e.Message);
                }
                Console.WriteLine();
                int[] aa = null;
                Debug.Assert(aa != null, "Values array cannot be null");

            }
    }
}

