using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
namespace ConsoleApp12
{
    interface ISpeed
    {
        void Speed();
    }
    interface IFly
    {
        void Fly();
    }
    public class Aviation:ISpeed,IFly
    {
        public int maxh;
        public string airplane;
        public int places;
        public int speed { get; set; }
        public Aviation (int maxh, string airplane, int places)
        {
            this.airplane = airplane;
            this.maxh = maxh;
            this.places = places;
        }
        public void ToConsole(string str)
        {
            Console.WriteLine("This is " + str + " was loaded from file.");          
        } 
        public void Fly()
        {
            Console.WriteLine("The Fly max is " + maxh);
        }
        public void Speed()
        {
            Console.WriteLine("The Speed is " + speed);
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Aviation aviation = (Aviation)obj;
            return (this.places == aviation.places);
        }
    }

    public static class Reflection
    {
        public static void WriteToFile(string FileName)
        {
            Type type = Type.GetType(FileName);
            using
                (StreamWriter sw = new StreamWriter("ClassInfo.txt"))
            {
                sw.WriteLine("Info about class " + FileName);
                sw.WriteLine();
                foreach (MemberInfo memberInfo in type.GetMembers())
                    sw.WriteLine("[ "+memberInfo.DeclaringType+" "+memberInfo.ToString()+" ]");
            }
        }

        public static MethodInfo[] GetMethodInfos(string MethodName)
        {
            return Type.GetType(MethodName).GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }
        public static FieldInfo[] GetFieldInfops(string FieldName)
        {
            return Type.GetType(FieldName).GetFields();
        }
        public static PropertyInfo[] GetPropertyInfos(string PropertyName)
        {
            return Type.GetType(PropertyName).GetProperties();
        }
        public static Type[] GetInterfaceMappings(string InterfaceName)
        {
            return Type.GetType(InterfaceName).GetInterfaces();
        }

        public static void RandomMethod(string name, string type)
        {
            foreach (MethodInfo method in Type.GetType(name).GetMethods())
            {
                if (method.ReturnType == Type.GetType(type))
                    Console.WriteLine(method);
            }
        }

        public static void InsaneMethod(Aviation obj, string mth)
        {
            FileStream file2 = new FileStream("InsaneMethod.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2);
            object[] Arro = { reader.ReadLine() };
            Type t = typeof(Aviation);
            MethodInfo metod = t.GetMethod(mth);
            object mval = metod.Invoke(obj, Arro);
            Console.WriteLine(mval);
        }
    }

    class Program
    {
      
        static void Main(string[] args)
        {
            Reflection.WriteToFile("ConsoleApp12.Aviation");
            Console.WriteLine("____Methods Info________");
            foreach (MethodInfo methodInfo in Reflection.GetMethodInfos("ConsoleApp12.Aviation")) 
            Console.WriteLine("[ "+methodInfo.ToString()+" ]");

            Console.WriteLine();
            Console.WriteLine("____Fields Info_________");
            foreach (FieldInfo fieldInfo in Reflection.GetFieldInfops("ConsoleApp12.Aviation"))
                Console.WriteLine("[ " + fieldInfo.ToString() + " ]");

            Console.WriteLine();
            Console.WriteLine("____Properties Info________");
            foreach (PropertyInfo property in Reflection.GetPropertyInfos("ConsoleApp12.Aviation"))
                Console.WriteLine("[ " + property.ToString() + " ]");

            Console.WriteLine();
            Console.WriteLine("____Interfaces Info_______");
            foreach (Type interfaces in Reflection.GetInterfaceMappings("ConsoleApp12.Aviation"))
                Console.WriteLine("[ " + interfaces.ToString() + " ]");

            Console.WriteLine();
            Console.WriteLine("___________Uniqie Methods_________");
            Reflection.RandomMethod("ConsoleApp12.Aviation", "System.Boolean");
            Aviation av = new Aviation(12000,"Boeing",400);
               
            Console.WriteLine();
            Console.WriteLine("_____Method with params by reading from file____");
            Reflection.InsaneMethod(av, "ToConsole");

        }  
    }
}
