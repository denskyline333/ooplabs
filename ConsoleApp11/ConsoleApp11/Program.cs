using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp11
{
    class Book
    {
        public string name;
        public int year;
        public double price;
        public string author;
        public int pages;

        public Book(string name, string author, int year, double price, int pages)
        {
            this.name = name;
            this.author = author;
            this.year = year;
            this.price = price;
            this.pages = pages;
        }

    }
    class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
    class Number
    {
        public int Num { get; set; }
        public string Position { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] month = new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            int n = 8;
            IEnumerable<string> m = from mon in month
                                    where mon.Length == n
                                    select mon;
            Console.WriteLine("Month with " + n + " letters:");
            foreach (string s1 in m)
                Console.Write(s1 + ", ");

            Console.WriteLine();
            Console.WriteLine();
            IEnumerable<string> m1 = from mon in month
                                     where mon == "June" || mon == "July" || mon == "August"
                                     select mon;
            Console.WriteLine("Summer months:");
            foreach (string s1 in m1)
                Console.Write(s1 + ", ");

            Console.WriteLine();
            Console.WriteLine();
            IEnumerable<string> m2 = month.OrderBy(x1 => x1);
            Console.WriteLine("Months in order by alphabet:");
            foreach (string s1 in m2)
                Console.Write(s1 + ", ");

            Console.WriteLine();
            Console.WriteLine();
            IEnumerable<string> m3 = from mon in month
                                     where mon.Contains("u") && mon.Length > 4
                                     select mon;
            Console.WriteLine("Months with \"U\" and lenght > 4");
            foreach (string s1 in m3)
                Console.Write(s1 + ", ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Book beast = new Book("Beast", "Lermontov", 2004, 4.4, 170);
            Book home = new Book("Home", "Pushkin", 2007, 5.8, 400);
            Book scream = new Book("Scream", "Tolstoi", 2010, 3.7, 245);
            Book native = new Book("Native", "Lermontov", 2013, 7.7, 690);
            int x = beast.pages;
            int y = home.pages;
            int z = scream.pages;
            int u = native.pages;
            int[] max = new int[4] { x, y, z, u };
            int maxpages = max.Max();
            int minpages = max.Min();

            List<Book> books = new List<Book>();
            books.Add(beast);
            books.Add(home);
            books.Add(scream);
            books.Add(native);
            Console.WriteLine();
            Console.WriteLine();

            IEnumerable<Book> b1 = books.Where(p => p.author == "Lermontov");
            Console.WriteLine("Books of Lermontov:");
            foreach (Book s1 in b1)
                Console.Write(s1.name + ", ");

            Console.WriteLine();
            Console.WriteLine();
            IEnumerable<Book> b2 = books.Where(p => p.year > 2005);
            Console.WriteLine("The books after 2005 year:");
            foreach (Book s1 in b2)
                Console.Write("[ Author: " + s1.author + ", Bookname: " + s1.name + ", Year: " + s1.year + " ]\n");


            IEnumerable<Book> b3 = from book in books
                                   where book.pages == minpages
                                   select book;

            Console.WriteLine();
            Console.WriteLine("A book with min pages:");
            foreach (Book s1 in b3)
                Console.Write("[ Author: " + s1.author + ", Bookname: " + s1.name + ", Pages: " + s1.pages + " ]\n");

            Console.WriteLine();
            Console.WriteLine();
            IEnumerable<Book> b4 = from book in books
                                   orderby book.price
                                   select book;
            Console.WriteLine("All books order by price:");
            foreach (Book s1 in b4)
                Console.Write("[ Author: " + s1.author + ", Bookname: " + s1.name + ", Price: " + s1.price + " ]\n");

            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("_____________________________________________________________________________-");
            Console.WriteLine("My request:");
            var world = new[] {
             new { country = "Belarus", plation = 10, bay = false, type = "Presedental" },
             new { country = "Spain", plation = 16, bay = true, type = "Monarchy" },
             new { country = "Kanada", plation = 35, bay = true, type = "Monarchy" },
             new { country = "Russia", plation = 130, bay= true, type= "Presidental"},
             new { country = "China", plation = 1140,bay = true,type= "Presidental"}
            };
            var req = from query in world
                      where query.plation > 12 && query.bay == true
                      where query.type.Equals("Monarchy")
                      orderby query.country
                      select query;
            foreach (var s1 in req)
                Console.Write("{ "+s1.country+" with population " + s1.plation +" is a "+s1.type+" country }\n");

            Console.ForegroundColor = ConsoleColor.White;
            List<Number> numbers = new List<Number>()
            {
                new Number { Num = 10 , Position="Attacker" },
                new Number { Num = 9 , Position="Main Attacker"},
                new Number { Num = 8 , Position = "MidDefender"}
            };
            List<Player> players = new List<Player>()
            {
                new Player { Name="Messi", Position="Attacker"},
                new Player { Name="Benzema", Position="Main Attacker"},
                new Player { Name = "Kroos", Position = "MidDefender" },
            };
            var result = from p in players
                         join n1 in numbers on p.Position equals n1.Position
                         select new
                         {
                             Name= p.Name,
                             Num = n1.Num,
                             Position= n1.Position
                         };
            Console.WriteLine();
            Console.WriteLine("Join players and their numbers:");
            foreach (var v in result)
                Console.Write("[ {0} with number {1} is a {2}", v.Name, v.Num, v.Position+" ]\n");

        } }
    }

