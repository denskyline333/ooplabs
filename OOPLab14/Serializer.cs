using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;


namespace OOPLab14
{

    /*
     * при xml сериализации/десиализации необходимы 3 условия:
     *          1) класс должен иметь стандартный конструктор без параметров
     *          2) сериализоваться будут только открытые члены, другие будут игнорироваться
     *          3) классы не могут быть abstract и т.д.
    */

    partial class Program
    {

        /// <summary>
        /// класс сериализатор, содержащий методы для всех видов сериализации/десериализации
        /// </summary>
        public static class Serializer
        {

            /// <summary>
            /// бинарная сериализация
            /// </summary>
            /// <param name="obj"></param>
            public static void BinarySerialization(object obj)
            {

                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {

                    bf.Serialize(fs, obj);

                    Console.WriteLine($"бинарная сериализация: объект {obj.ToString()} был сериализован");

                }

            }
            /// <summary>
            /// бинарная десериализация
            /// </summary>
            public static void BinaryDeserialization()
            {

                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {

                    Human newhuman = (Human)bf.Deserialize(fs);

                    Console.WriteLine($"бинарная десериализация: объект {newhuman.ToString()} был десериализован\n");

                }

            }

            /// <summary>
            /// soap сериализация
            /// </summary>
            /// <param name="obj"></param>
            public static void SoapSerialization(object obj)
            {

                SoapFormatter sf = new SoapFormatter();

                using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
                {

                    sf.Serialize(fs, obj);

                    Console.WriteLine($"soap сериализация: объект {obj.ToString()} был сериализован");

                }

            }
            /// <summary>
            /// soap десериализация
            /// </summary>
            public static void SoapDeserialization()
            {

                SoapFormatter sf = new SoapFormatter();

                using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
                {

                    Human newhuman = (Human)sf.Deserialize(fs);

                    Console.WriteLine($"soap денсериализация: объект {newhuman.ToString()} был десериализован\n");

                }

            }

            /// <summary>
            /// json сериализация
            /// </summary>
            /// <param name="obj"></param>
            public static void JSONSerialization(object obj)
            {

                DataContractJsonSerializer jf = new DataContractJsonSerializer(obj.GetType());

                using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
                {

                    jf.WriteObject(fs, obj);

                    Console.WriteLine($"json сериализация: объект {obj.ToString()} был сериализован");

                }

            }
            /// <summary>
            /// json десериализация
            /// </summary>
            public static void JSONDeserialization(object obj)
            {

                DataContractJsonSerializer jf = new DataContractJsonSerializer(obj.GetType());

                using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
                {

                    Human newhuman = (Human)jf.ReadObject(fs);

                    Console.WriteLine($"json десериализация: объект {newhuman.ToString()} был десериализован\n");

                }

            }

            /// <summary>
            /// xml сериализация
            /// </summary>
            /// <param name="obj"></param>
            public static void XMLSerialization(object obj)
            {

                XmlSerializer xs = new XmlSerializer(obj.GetType());

                using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                {

                    xs.Serialize(fs, obj);

                    Console.WriteLine($"xml сериализация: объект {obj.ToString()} был сериализован");

                }

            }
            /// <summary>
            /// xml десериализация
            /// </summary>
            /// <param name="obj"></param>
            public static void XMLDeserialization(object obj)
            {

                XmlSerializer xs = new XmlSerializer(obj.GetType());

                using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                {

                    Human newhuman = (Human)xs.Deserialize(fs);

                    Console.WriteLine($"xml десериализация: объект {newhuman.ToString()} был десериализован\n");

                }

            }

        }

    }

}
