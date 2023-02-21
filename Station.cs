using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSimulation
{
    public enum StationSign //Признак станции
    {
        NotVisited = 1, // Не посещена
        AtTheStation,   // На станции
        Visited         // Посещена
    }

    public enum TypeStation //Тип станции
    {
        EndStations = 1,    //Конечная станция
        StandartStation,    //Обычная станция
        TransfetStations    //Пересадочная станция
    }

    class Station   //Vertex
    {
        public string NameStation { get; set; }  //Название станции
        public Station prevStation; //Предыдущая станция, от которой пришли
        public StationSign sign;    //Признак станции
        public double distance;     //Суммарное расстояние
        public TypeStation typeS;   //Тип станции
        public LineMetro Vetka;     //Ветка метро
        public List<Line> adjlines; //Список веток метро, выходящих из данной станции

        //public bool notVisited;       // признак "станция не посещена" 
        //public int NumVisit;        // № посещения
        //public int Dist;            // минимальное расстояние
        //public Station transferStation; //1 0

        public Station()    //Пустой конструктор
        {
            NameStation = "No name";
            prevStation = null;
            Vetka = null;
            sign = StationSign.NotVisited;
            distance = double.MaxValue;
            typeS = TypeStation.StandartStation;
            adjlines = new List<Line>();
        }

        public Station(string nameStation, LineMetro vetka, TypeStation type)  //Конструктор
        {
            NameStation = nameStation;
            prevStation = null;
            Vetka = vetka;
            sign = StationSign.Visited;
            distance = double.MaxValue;
            typeS = type;
            adjlines = new List<Line>();
        }

        public int CountLinesStation { get { return adjlines.Count; } } //Кол-во веток, идущих от станции

        public override string ToString()
        {
            return string.Format("Station:({0}) - {1}", NameStation, Vetka);
        }



    }
}
