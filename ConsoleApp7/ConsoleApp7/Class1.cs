using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp7
{
    public class First
    {
        public enum Operation
        {
            add = 1,
            substract,
            multiply,
            divide
        }
        public static void MathOp(double x, double y, Operation z)
        {
            double result = 0.0;
            switch (z)
            {
                case Operation.add:
                    result = x + y;
                    break;
                case Operation.substract:
                    result = x - y;
                    break;
                case Operation.multiply:
                    result = x * y;
                    break;
                case Operation.divide:
                    result = x / y;
                    break;
            }
            Console.WriteLine("Результат операции равен = " + result);
        }
        public enum Days
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public static void Table(Days x)
        {
            Console.WriteLine("Today is - " + (int)x + " day of week");
        }
    }
    struct Water
    {
        string color;
        int maxlitres;
        internal Water(string color, int maxl)
        {
            this.color = color;
            maxlitres = maxl;
        }
        public void Show()
        {
            Console.WriteLine("Color of water is " + color + " and max litres " + maxlitres);
        }
    }
    internal partial class A
    {
        internal void Method2()
        {
            Console.WriteLine("A2");
        }
    }

    public class AviationCompany : List<Object>
    {
        public AviationCompany(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Add(list[i]);
            }
        }
    }
    public class Controller : AviationCompany
    {
        public Controller(AviationCompany avi)
        {
            for (int i = 0; i < avi.Count; i++)
            {
                Add(avi[i]);
            }
        }

        public int AVGcapacity()
        {
            int avg = 1;
            for (int i = 0; i < Count; i++)
            {
                if (this.ElementAt(i) is Aviation)
                {
                    Aviation a = new Aviation("");
                    a = (Aviation)this.ElementAt(i);
                    avg += (a.capacity) / Count;
                }
            }
            return avg;
        }
        public void Speed()
        {
            int counter = 0;
            for (int i = 0; i < Count; i++)
            {
                if (this.ElementAt(i) is Military)
                {
                    Military mil = new Military("");
                    mil = (Military)this.ElementAt(i);
                    if (mil.speed > 385 && mil.speed < 600)
                    {
                        counter++;
                        Console.Write(counter + ")");
                        Console.WriteLine(mil.airplane + " speed is - " + mil.speed);
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ElementAt(i) is Aviation)
                {
                    Aviation a = new Aviation("");
                    a = (Aviation)this.ElementAt(i);
                    Console.WriteLine(a.ToString());
                }
            }
        }
    }
}
