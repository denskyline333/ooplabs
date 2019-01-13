using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp10
{
    class Faze:IComparable<Faze>
    {
        public string Name;
        public int Cost;
        public double Rating;
        public Faze(string name, int cost, double rating)
        {
            Name = name;
            Cost = cost;
            Rating = rating;
        }
        public int CompareTo(Faze obj)
        {
            if (this.Rating > obj.Rating) return 1;
            if (this.Rating < obj.Rating) return -1;
            else return 0;
        }

        public override string ToString()
        {
            return "Player: " + Name + ", Cost: " + Cost + "k$, Rating: " + Rating;
        }
    }
    class Student
    {
        public string name { get; set; }
        public int course { get; set; }
        public Student(string name,int course)
        {
            this.name = name;
            this.course = course;
        }
        public override string ToString()
        {
            return "("+name+", "+course+")";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("ArrayList : ");
            ArrayList array = new ArrayList();
            Random r = new Random();
            for(int i=0;i<5;i++)
            {
                array.Add(r.Next(5, 30));
            }
            array.Add("string addition");
            Student s1 = new Student("Denis", 2);
            array.Add(s1);
            array.RemoveAt(1);
            foreach(var elem in array)
            {
                Console.Write(elem + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("Count: " + array.Count);
            Console.WriteLine("Search: " + array.Contains(15));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SortedList: ");
            SortedList<string, string> keys = new SortedList<string, string>();
            keys.Add("0", "Maxim");
            keys.Add("1", "Stanislaw");
            keys.Add("2", "Nikola");
            keys.Add("3", "Emilia");
            keys.Add("4", "Gabriella");
            keys.Add("5", "Olof");
            ICollection<string> num = keys.Keys;
            foreach(string  elem in num)
            {
                Console.WriteLine("User: {1}, Key:{0}", elem, keys[elem]);
            }
            Console.WriteLine("Enter the number of elements to remove: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("Enter key:");
                keys.Remove(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("SortedList after deletes:");
            foreach(string elem in num)
            {
                Console.WriteLine("User: {1}, Key:{0}", elem, keys[elem]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Stack collection:");

            Stack<string> stack = new Stack<string>();
            stack.Push("Maxim");
            stack.Push("Stanislaw");
            stack.Push("Nikola");
            stack.Push("Emilia");
            foreach(string s in stack)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Search: " + stack.Contains("Maxim"));

            //string numm = keys.Values.ToString();
            //for (int i=0;i<keys.Count;i++)
            //{
            //    stack.Push(numm);
            //}
            //foreach(string elem in stack)
            //{
            //    Console.WriteLine(elem + ", ");
            //}
            Console.WriteLine();
            Console.WriteLine("Stack of my own class Faze:");
            Faze rain = new Faze("Rain", 200, 1.15);
            Faze niko = new Faze("Niko", 500, 1.27);
            Faze olof = new Faze("Olofm", 300, 1.18);
            Faze karrigan = new Faze("Karrigan", 100, 1.01);
            Faze guardian = new Faze("Guardian", 220, 1.10);
            Stack<Faze> faze = new Stack<Faze>();
            faze.Push(rain);
            faze.Push(niko);
            faze.Push(olof);
            faze.Push(karrigan);
            faze.Push(guardian);
            foreach (Faze f in faze)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine("Enter the number of elements to remove:");
            int del = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<del;i++)
            {
                faze.Pop();
            }
            Console.WriteLine();
            Console.WriteLine("Faze after deletes:");
            foreach (Faze f in faze)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SortedList of my own class Faze:");
            SortedList<int, Faze> fazes = new SortedList<int, Faze>();
            fazes.Add(24, niko);
            fazes.Add(10, rain);
            ICollection<int> vs = fazes.Keys;
            foreach(int elem in vs)
            {
                Console.WriteLine(fazes[elem] + " Key: " + elem);
            }
            Console.WriteLine();
            ObservableCollection<Faze> col = new ObservableCollection<Faze>();
            col.CollectionChanged += Notification;
            col.Add(niko);
            col.Add(karrigan);
            col.Remove(niko);
            void Notification(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine("Object is added to Lisk");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine("Object is deleted from List");
                        break;
                }
                
            }

        }
    }
}
