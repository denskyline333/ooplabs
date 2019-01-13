namespace OOPLab14
{

    public partial class Program
    {

        [System.Runtime.Serialization.DataContract]
        [System.Serializable]
        /// <summary>
        /// класс человек
        /// </summary>
        public class Human : SmartCreature
        {

            /// <summary>
            /// переопределение метода ToString
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {

                return $"{this.GetType()} {CreatureName} {OriginPlanet} {Race}";

            }

            /// <summary>
            /// конструктор объекта класса Human без параметров
            /// </summary>
            public Human()
            {

                CreatureName = "Unknown.";
                OriginPlanet = "Unknown.";
                Race = "Unknown.";

            }

            /// <summary>
            /// конструктор объекта класса Human с параметрами
            /// </summary>
            /// <param name="_CreatureName"></param>
            /// <param name="_OriginPlanet"></param>
            /// <param name="_Race"></param>
            public Human(string _CreatureName, string _OriginPlanet, string _Race)
            {

                CreatureName = _CreatureName;
                OriginPlanet = _OriginPlanet;
                Race = _Race;

            }

        }

    }

}
