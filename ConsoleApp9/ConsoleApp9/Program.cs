using System;
using System.Linq;
namespace ConsoleApp9
{
    class Game
    {
        public void Print() => Console.WriteLine(name + " - attack is " + attack + " | health is " + hp);

        public string name;
        public int attack;
        public int hp;
        public Game(string _name, int attack, int hp)
        {
            name = _name;
            this.attack = attack;
            this.hp = hp;
        }
    }
    class Game1
    {
        public delegate void EventHandler(string str);
        public delegate void Del(int str);
        public event EventHandler Attack;
        public event EventHandler Health;
        public event Del Hero;
        public void All(int str, Game[] heroes)
        {
            int sum = 0;
            int hel = 0;
            int count = 0;
            for (int i = 0; i < heroes.Length; i++)
            {
                sum += heroes[i].attack;
                hel += heroes[i].hp;
                count++;
            }
            Console.WriteLine("Common attack of " + count + " heroes - " + sum);
            Console.WriteLine("Common health of " + count + " heroes - " + hel);
            Hero(count);
        }

        public void AttackGo(string str, Game obj)
        {
            if (obj.attack < 310)
            {
                obj.attack += 100;
                Attack(str);
                Console.WriteLine("The attack of " + obj.name + " was changed into " + obj.attack);
            }
        }
        public void HealthGo(string str, Game obj)
        {
            if (obj.hp < 200)
            {
                obj.hp += 10;
            }
            else
                obj.hp -= 20;
            Health(str);
            Console.WriteLine("The hp of " + obj.name + " was changed into " + obj.hp);
        }
        public static void Add(string s1)
        {
            s1 = new string((from c in s1 where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c) select c).ToArray());
            Console.WriteLine(s1);
        }

    }
    public delegate void Action<T>(T obj);
    class Program
    {
        static void Operation(string x1, string x2, Action<string, string> op) => op(x1, x2);


        static void Concat(string x1, string x2)
        {
            string s3 = String.Concat(x2,x1);
            Console.WriteLine(s3);           
        }

        static void Case(string x1, string x2)
        {
            x1 = x1.ToUpper();
            x2 = x2.ToUpper();
            Console.WriteLine(x1);
            Console.WriteLine(x2);      
        }
        static void Subst(string x1,string x2)
        {
            x1 = x1.Insert(5, "THIRD");
            x2 = x2.Insert(0, "LAST JOB");
            Console.WriteLine(x1);
            Console.WriteLine(x2);
        }
        static void Main(string[] args)
        {
           
            Game1 game1 = new Game1();
            Game1 game2 = new Game1();
            Game knight = new Game("Knight", 350, 90);
            Game magician = new Game("Magician", 250, 140);
            Game archer = new Game("Archer", 300, 130);
            Game orksbane = new Game("Orksbane", 370, 200);
            Game[] heroes = new Game[4];
            heroes[0] = knight;
            heroes[1] = magician;
            heroes[2] = archer;
            heroes[3] = orksbane;
            int x = heroes.Length;
            knight.Print();
            magician.Print();
            archer.Print();
            orksbane.Print();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("+All stats method");
            game1.Hero += str => Console.WriteLine();
            game1.All(x, heroes);


            game1.Attack += str => Console.Write("");
            game1.Health += str => Console.Write("");
            Console.WriteLine("+Attack method :");
            game1.AttackGo("", knight);
            game1.AttackGo("", magician);
            game1.AttackGo("", archer);
            game1.AttackGo("", orksbane);

            Console.WriteLine();
            Console.WriteLine("+HP method :");
            game1.HealthGo("", knight);
            game1.HealthGo("", magician);
            game1.HealthGo("", archer);
            game1.HealthGo("", orksbane);
            game1.Attack += str => Console.Write("");

            Console.WriteLine("_____________________________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("New stats:");
            knight.Print();
            magician.Print();
            archer.Print();
            orksbane.Print();
            Console.WriteLine("_____________________________________________");
            Console.WriteLine();
            Console.WriteLine("+All stats method");
            game2.Hero += str => Console.WriteLine();
            game2.All(x, heroes);


            Console.ForegroundColor = ConsoleColor.White;
            Action<string, string> op;
            op = Concat;
            Console.WriteLine("         Concat:");
            Operation("first second", "next time", op);
            op = Case;
            Console.WriteLine("         Upper Case:");
            Operation("first second", "next time", op);
            op = Subst;
            Console.WriteLine("         Insert:");
            Operation("first second", "next time", op);

        }
    }
}
    

