using System;

namespace ConsoleApp3
{
    class Book
    {
        public static int counter { get; set; } = 0;
        public const bool b = false;
        public readonly float id = 14.5f;
        public string name { get; set; }
        public string author { get; set; }
        public int year { get; set; }
        public bool produce { get; set; }
        private int price;
        public int Price
        {
            set
            {
                price = value;
            }
            get
            {
                return price;
            }
        }
        public override string ToString()
        {
            return base.ToString() + " The Book " + name + " was written by " + author;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            Book b = (Book)obj;
            return (produce == b.produce);
        }
        public override int GetHashCode()
        {
            int hash = 53;
            hash = (hash * 4) + author.GetHashCode();
            return hash;
        }

        public Book(float _id)
        {
            id = _id;
        }
        static Book()
        {
            Console.WriteLine("Статический конструктор");
            Console.WriteLine();
        }
        public Book()
        {
            id = 14;
            name = "Beast";
            author = "James P.";
            year = 2013;
            price = 1000;
            produce = false;
            Print();
            counter++;
        }

        public Book(string name, string author, int year, int price, bool produce = true)
        {
            this.name = name;
            this.author = author;
            this.year = year;
            this.price = price;
            this.produce = produce;
            Print();
            counter++;
        }

        public void Print()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Year: " + year);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Produce: " + produce);
            Console.WriteLine("________________________");
        }


    }


    class Program
    {
        static void Change(ref int w, out int e)
        {
            w += 10;
            e = w * 2;
        }
        static void Main(string[] args)
        {

            Book[] kniga = new Book[4];
            kniga[0] = new Book();
            kniga[1] = new Book("Hyper", "Thomas S.", 2009, 1300);
            kniga[2] = new Book("Rain", "Thomas S.", 2004, 1150, true);
            kniga[3] = new Book("Nitro", "James P.", 2014, 1250, false);
            Console.WriteLine();
            Console.WriteLine("Введите Автора:");
            string x = Console.ReadLine();
            for (int i = 0; i < kniga.Length; i++)
            {
                if (x == kniga[i].author)
                {
                    Console.WriteLine("Список книг автора " + kniga[i].author + " - " + kniga[i].name);
                }

            }
            Console.WriteLine("Введите год: ");
            string d = Console.ReadLine();
            int d1 = Convert.ToInt32(d);
            Console.Write("Книги после " + d1 + " года - ");
            for (int i = 0; i < kniga.Length; i++)
            {
                if (d1 < kniga[i].year)
                {
                    Console.WriteLine(kniga[i].name + ", ");
                }
            }

            Console.WriteLine();

            var anonim = new { name = "Winter", author = "Olof K.", year = 2023, price = 445, produce = true };
            Console.WriteLine(anonim.GetType());
            Console.WriteLine(anonim);
            Console.WriteLine("Number of books is - " + Book.counter);
            int we;
            int wr = 13;
            Change(ref wr, out we);
            Console.WriteLine("ref wr - " + wr + " out we= " + we);
            Console.WriteLine(kniga[1].ToString());
            Book idd = new Book(29.1f);

            Console.WriteLine("Readonly changed - " + idd.id);
            Console.WriteLine("Is first equal second? " + kniga[0].Equals(kniga[3]));
            Console.WriteLine("Type of fourth " + kniga[3].GetType());
            Console.WriteLine("Hashcode of third " + kniga[2].GetHashCode());
        }

    }



}
