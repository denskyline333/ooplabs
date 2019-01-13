namespace OOPLab14
{
    public partial class Program
    {

        [System.Runtime.Serialization.DataContract] /// <summary>
        [System.Serializable]                       /// абстрактный класс SmartCreature
                                                   /// </summary>


        public class SmartCreature
        {
            [System.Runtime.Serialization.DataMember]  /// <summary>
                                                       /// имя существа
                                                       /// </summary>

            public string CreatureName { get; set; }    /// <summary>
            [System.Runtime.Serialization.DataMember]   /// планета существа
                                                        /// </summary>


            public string OriginPlanet { get; set; } /// <summary>
                                                     /// раса существа
                                                     /// </summary>
            [System.Runtime.Serialization.DataMember]
           
            public string Race { get; set; }  /// <summary>
                                              /// стандартный конструктор без параметров
                                              /// </summary>


            public SmartCreature() { }

        }

    }
}
