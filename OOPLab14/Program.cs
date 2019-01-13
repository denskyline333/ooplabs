using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab14
{

    public partial class Program
    {

        static void Main(string[] args)
        {

            
            Human binhuman = new Human("bin", "bin", "bin");// экземпляр Human для бинарной сериализации/десериализации
            Human soaphuman = new Human("soap", "soap", "soap");// экземпляр Human для soap сериализации/десериализации
            Human jsonhuman = new Human("json", "json", "json");// экземпляр Human для json сериализации/десериализации
            Human xmlhuman = new Human("xml", "xml", "xml"); // экземпляр Human для xml сериализации/десериализации

            Serializer.BinarySerialization(binhuman); // демонстрация бинарной сериализации/десериализации, people.dat
            Serializer.BinaryDeserialization();

            Serializer.SoapSerialization(soaphuman); // демонстрация soap сериализации/десериализации, people.soap
            Serializer.SoapDeserialization();                                              
            
            Serializer.JSONSerialization(jsonhuman);// демонстрация json сериализации/десериализации, people.json
            Serializer.JSONDeserialization(jsonhuman);

            Serializer.XMLSerialization(xmlhuman);  // демонстрация xml сериализации/десериализации, people.xml
            Serializer.XMLDeserialization(xmlhuman);

        }

    }

}
