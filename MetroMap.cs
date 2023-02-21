using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSimulation
{
    class MetroMap  //Graph
    {
        public List<Station> AllStations = new List<Station>(); //Список всех станций 
        public List<Line> AllLines = new List<Line>();          //Список всех перегонов
        public List<LineMetro> AllLinesMetro = new List<LineMetro>(); //Список всех веток метро

        //Количество станций, перегонов и веток ВО ВСЕМ метро 
        public int StationsCount { get { return AllStations.Count; } }
        public int LinesCount { get { return AllLines.Count; } }
        public int MetroLineCount { get { return AllLinesMetro.Count; } }

        public bool AddStation(Station st)  //Добавить новую станцию
        {
            if (AllStations.Contains(st)) return false;
            AllStations.Add(st);
            return true;
        }

        public bool AddLine(Station from, Station to, double time)  //Добавить новую ветку метро
        {
            Line edge = new Line(from, to, time);
            if (AllLines.Contains(edge)) return false;
            AllLines.Add(edge);
            from.adjlines.Add(edge);
            return true;
        }

        public bool AddLineMetro(LineMetro vetka)  //Добавить новую ветку
        {
            if (AllLinesMetro.Contains(vetka)) return false;
            AllLinesMetro.Add(vetka);
            return true;
        }

        public Station FindStation(Station nameStation)   //Поиск нужной станции
        {
            foreach (var listSt in AllStations)
            {
                if (listSt.NameStation.Equals(nameStation))
                {
                    return listSt;
                }
            }
            return null;
        }

        public void BFS(Station startStation)     //Поиск в ширину (обход станций)
        {
            //v - вершина; u - вершина смежная с v;
            //инициализация
            foreach (Station vertex in AllStations)
            {
                vertex.distance = double.MaxValue; //(бесконечность)
                vertex.prevStation = null;         //предшественник
                vertex.sign = StationSign.NotVisited;
            }

            //Console.WriteLine("\nВершины в порядке обхода");
            startStation.sign = StationSign.AtTheStation;
            startStation.distance = 0;
            startStation.prevStation = null;
            Queue<Station> Q = new Queue<Station>();
            Q.Enqueue(startStation);             //Добавить в конец очереди
            //Console.WriteLine("{0}", startStation);

            while (Q.Count > 0)
            {
                Station u = Q.Dequeue();     //Удаляет элемент из начала очереди и возвращает его

                foreach (Line ee in u.adjlines)
                {
                    Station v = ee.To;
                    if (v.sign == StationSign.NotVisited)
                    {
                        v.sign = StationSign.AtTheStation;
                        v.distance = u.distance + ee.Time;
                        v.prevStation = u;
                        //Console.WriteLine("PREV {0}", v.prevStation);
                        Q.Enqueue(v);
                        //Console.WriteLine("{0}", ee);
                    }

                }
                u.sign = StationSign.Visited;

            }

        }

        //Печатает кратчайшие пути из стартовой станции до нужной станции
        public void PrintPath(Station startStation, Station station, LineMetro vet)
        {
            LineMetro u = station.Vetka; 
            //if (station.typeS == TypeStation.StandartStation)  
            //else u = vet; 
            if (startStation == station) Console.WriteLine("Вы сели на {0}", startStation);
            else if (station.prevStation == null) Console.WriteLine("Пути из {0} в {1} нет", startStation, station);
            
            else PrintPath(startStation, station.prevStation, u); 
            {
                if (station.typeS == TypeStation.EndStations && station != startStation ) Console.WriteLine("Путь: Конечная {0}", station);
                else Console.WriteLine("Путь: {0} - {1} минут", station, station.distance);
                
                if (u != vet) Console.WriteLine("Вам нужно пересесть на {0} на {1} -> ", station, vet);
            }

        }

        public void View()  //Показать на экране всю информацию о метро
        {
           foreach (Station v in AllStations)
           {
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.WriteLine(" {0}", v);
               Console.ResetColor();
               foreach (Line e in v.adjlines)
               {
                   Console.WriteLine("Line {0}", e);
               }
           }
        }

    }
}
