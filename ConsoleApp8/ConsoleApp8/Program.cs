using System;
using System.Collections.Generic;


namespace ConsoleApp4
{
    public interface IInter<T>
    {
        void add(T obj);
        void print();
        void del(T obj);
    }
    public class Ctype<T> : List<T>, IInter<T> where T : IComparable
    {
        public void add (T obj)
        {
            Add(obj);
        }
        public void del(T obj)
        {
                Remove(obj);      
        }
        public void print()
        {
            foreach(T x in this)
            {
                Console.WriteLine(x);
            }
        }
        public static Ctype<T> operator +(Ctype<T> a, Ctype<T> b)
        {
            Ctype<T> c = new Ctype<T>();
            foreach (T item in a) c.Add(item);
            foreach (T item in b) c.Add(item);
            return c;
        }
    }

    abstract class Aviation:IComparable
    {
        public abstract void Method();
        public string name;
        private int maxh;
        public int CompareTo(object obj)
        {
            return 1;
        }
        
        public int Maxh
        {
            get
            {
                return maxh;
            }
            set
            {
                if (value < 4000)
                    value += 3000;
                else
                    value = maxh;
            }                
        }


        public Aviation(string name,int maxh)
        {
            this.name = name;
            this.maxh = maxh;
        }
    }
    class Passenger : Aviation,IComparable
    {
        public int amount;
        public Passenger(string name,int maxh,int amount):base(name,maxh)
        {
            this.name = name;
            this.amount = amount;
            this.Maxh = maxh;
        }
        public override string ToString()
        {
            return ($"Airplane is {name} with max height {Maxh} and amount of people {amount}.");
        }
        public override void Method()
        {
            if(amount<200 || amount >800)
            {
                Console.WriteLine("Is not a passenget type");
            }
            throw new NotImplementedException();
        }
    }
    class Cargo : Aviation
    {
        public int weight;
        public Cargo(string name,int maxh,int weight):base(name,maxh)
        {
            this.name = name;
            this.Maxh = maxh;
            this.weight = weight;
        }
        public override string ToString()
        {
            return  ($"Airplane is {name} with max height {Maxh} and weight of cargo {weight} tonn" );
        }
        public override void Method()
        {
            if(Maxh>10000)
            {
                Console.WriteLine("Is not a cargo type");
            }
        }
    }
    class Military : Aviation
    {
        public int speed;
        public Military(string name, int maxh, int speed) : base(name, maxh)
        {
            this.name = name;
            this.Maxh = maxh;
            this.speed = speed;
        }
       
        public override string ToString()
        {
            return ($"Airplane is {name} with max height {Maxh} and speed {speed}m/s");
        }
        public override void Method()
        {
            if(speed < 400)
            {               
                Console.WriteLine("Is not a military type");
            }
            
        }
    }
    public class MyException : Exception
    {
        public MyException(string message):base(message)
        {

        }
    }
  




    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            Console.WriteLine("Классы в качестве параметра обобщенного типа:\n");           
            Ctype<Aviation> a1 = new Ctype<Aviation>();
            Cargo cargo = new Cargo("Cargo ", 7000, 6);
            Military military = new Military("Military", 14000, 510);
            Passenger passenger = new Passenger("Passenger", 10000,550);
            a1.Add(cargo);
            a1.Add(military);
            a1.Add(passenger);
            a1.print();
            Console.WriteLine();
            Ctype<int> next = new Ctype<int>();
            Console.WriteLine("Обобщенный тип int:");
            next.Add(1);
            next.Add(3);
            next.Add(5);
            next.Add(7);
            next.del(7);          
            next.print();
            Console.WriteLine("Обобщенный тип double");
            Ctype<double> d1 = new Ctype<double>();
            d1.Add(24.434);
            d1.Add(543.32);
            d1.Add(53.543322f);
            d1.print();
                Ctype<int> a = new Ctype<int>();
                Ctype<int> b = new Ctype<int>();
                Ctype<int> c = new Ctype<int>();
                Console.WriteLine();
                Console.WriteLine("Перегрузка оператора + для обобщенных типов:");
                a.add(1);
                b.add(4);
                c = a + b;
                c.print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
            finally
            {
                Console.WriteLine("The end");
            }
         




        }
    }
}
