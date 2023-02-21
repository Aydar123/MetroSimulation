using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSimulation
{
    class LineMetro //Ветка метро
    {
        public string NameLineMetro { get; set; }   //Название ветки метро

        public List<Station> stationsInThisLineMetro = new List<Station>(); //Список станций в данной ветке метро
        public List<Line> linesInThisLineMetro = new List<Line>(); //Список прегонов в данной ветке метро

        //Количество станций и перегонов В ДАННОЙ ветке метро
        public int StationsCountLM { get { return stationsInThisLineMetro.Count; } }
        public int LinesCountLM { get { return linesInThisLineMetro.Count; } }
        
        public LineMetro()
        {
            NameLineMetro = "no name";
        }

        public LineMetro(string name)
        {
            NameLineMetro = name;
        }

        public bool AddStation(Station st)  //Добавить имеющуюся станцию в конкретную ветку метро
        {
            if (stationsInThisLineMetro.Contains(st)) return false;
            stationsInThisLineMetro.Add(st);
            return true;
        }

        public bool AddLine(Station from, Station to, double time)  //Добавить перегон в конкретню ветку метро
        {
            Line edge = new Line(from, to, time);
            if (linesInThisLineMetro.Contains(edge)) return false;
            linesInThisLineMetro.Add(edge);
            from.adjlines.Add(edge);
            return true;
        }

        public override string ToString()
        {
            return string.Format("Линия:({0})", NameLineMetro);
        }

        /*
        public override string ToString()
        {
            return string.Format("Line metro: ({0} | Count stations in this line: {1} | Count lines in this line: {2})", NameLineMetro, StationsCountLM, LinesCountLM);
        }
        */

    }
}
