using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSimulation
{
    class Line //Перегоны от одной станции к другой //Edge
    {
        public Station From { get; set; } //От куда 
        public Station To { get; set; }   //Куда
        public double Time { get; set; }  //Время, потраченное на проезд от одной станции к другой (минуты)
        public Station ConnectedStation { get; }    //Связная станция

        //public bool select;
        //public int numNode;     //содержит номер вершины, на которую показывает ребро

        public Line()
        {
            From = null;
            To = null;
            Time = 0;
        }

        public Line(Station from, Station to, double time)
        {
            From = from;
            To = to;
            Time = time;
        }

        public override string ToString()
        {
            return $"({From}; {To}; {Time} min)";
        }

    }
}
