using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp5
{
   // СОздать иеархию классов Транспорт > Авиация > Грузовой, Пассажирский, Военный > Ty134, Boeing
    public interface IInter
    {
        void What();
    }

    public interface IInterface
    {
        void Print();
    }
    abstract class Transport:IInterface
    {
        public string airplane;
        public abstract void Print(); 
        public Transport (string air)
        {
            airplane = air;
        }
    }
    class Aviation:Transport
    {
       public override void Print()
        {
            Console.WriteLine("Aviation types are: ");
        }
        public int maxh { get; set; }
        public Aviation( string air,int maxh):base(air)
        {
            this.airplane = air;
            this.maxh = maxh;
        }       
    }
    
    class Cargo:Aviation,IInter
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
        public Cargo(string air, int maxh ,string cargo, int price):base(air,maxh)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.cargo = cargo;
            this.price = price;
        }
        public override string ToString()
        {
            return (  "Airplane - " + airplane + " | max height is " + maxh + " | cargo is " + cargo + " | price " + price) ;
        }
    }
    class Passenger:Aviation
    {
        public int amount;
        public Passenger(string air, int maxh, int amount):base(air,maxh)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.amount = amount;
        }
        public override string ToString()
        {
            return ( "Airplane - " + airplane + " | max height is " + maxh + " | amount of people "+amount);
        }
    }
    class Military:Aviation
    {
        public float speed;
        public Military(string air, int maxh, float speed):base(air,maxh)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.speed = speed;
        }
        public override string ToString()
        {
            return (  "Airplane - " + airplane + " | max height is " + maxh + " | speed is avg "+speed+"\nMilitary classified as follows");
        }
        virtual public void Guns()
        {
            Console.WriteLine("Miliraty airplane has some guns");
        }
    }
    class Ty134:Military,IInterface
    {
        public override void Print()
        {
            if(speed>300f && maxh>12000)
            {
                Console.WriteLine("Ty134 has speed>300f and maxh>12000");
            }
        }
        public string guns;
        public Ty134(string air,int maxh,float speed,string guns):base(air,maxh,speed)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.speed = speed;
            this.guns = guns;
        }
        public override string ToString()
        {
            return (  "Airplane - " + airplane + " | max height is " + maxh + " | speed is "+speed+" | guns are "+guns);
        }
        public override void Guns()
        {
            if(guns=="AWP" || guns=="Nuclear bomb")
            {
                Console.WriteLine("Ty134 is better than Boeing");
            }
        }
    }
    class Boeing :Military
    {
        public string guns;
        public Boeing(string air, int maxh, float speed, string guns) : base(air, maxh, speed)
        {
            this.airplane = air;
            this.maxh = maxh;
            this.speed = speed;
            this.guns = guns;
        }
    public  override string ToString()
    {
        return ( "Airplane - " + airplane + " | max height is " + maxh + " | speed is " + speed + " | guns are " + guns);
    }
    public override void Guns()
    {
        if (speed>500f)
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
    class Program
    {
        static void Main(string[] args)
        {
            Aviation av = new Aviation("Aiplanes", 12000);
            av.Print();
            Cargo c = new Cargo("Cargo ", 10000, "cars", 78000);
            Passenger p = new Passenger("Passenger ", 8000, 450);
            Cargo c1 = new Cargo("Cargo ", 5000, "dairy products", 615);
            Passenger p1 = new Passenger("Passenger ", 4000, 220);
            Military m = new Military("Military ", 19000, 380f);
            Ty134 t = new Ty134("Ty134 ", 13000, 390f, "Nuclear bomb");
            Military b = new Boeing("Boeing", 16000, 510f, "Insane rockets");
            Console.WriteLine(c.ToString());
            Console.WriteLine(c1.ToString());
            Console.WriteLine(p.ToString());        
            Console.WriteLine(p1.ToString());
            Console.WriteLine(m.ToString());
            Console.WriteLine(t.ToString());
            Console.WriteLine(b.ToString());
            m.Guns();
            t.Guns();
            b.Guns();
            Console.WriteLine();
            Console.WriteLine(p is Passenger);
            Console.WriteLine(av is Cargo);
            Console.WriteLine(b as Aviation);
            Printer pr = new Printer();
            List<Object> mas = new List<Object>();
           
            mas.Add(c1);
            mas.Add(p1);
            mas.Add(m);
            mas.Add(t);
            mas.Add(b);
            Console.WriteLine(pr.IAmPrinting(t));
            Console.WriteLine(pr.IAmPrinting(c1));
            Console.WriteLine(pr.IAmPrinting(m));
            Console.WriteLine(pr.IAmPrinting(b));
            Console.WriteLine(pr.IAmPrinting(p));
        }
    }
}
