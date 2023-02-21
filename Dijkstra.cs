using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSimulation
{
    class Dijkstra
    {
        public MetroMap metro;

        public List<Station> infoAboutSt;    //информация о станциях

        public Dijkstra(MetroMap m)
        {
            this.metro = m;
        }

        public void InitInfo()  //Инициализация информации
        {
            infoAboutSt = new List<Station>();
            foreach (var s in metro.AllStations)
            {
                infoAboutSt.Add(new Station(s));
            }
        }

        public Station GetStationInfo(Station st)   //Получить информацию о станции
        {
            foreach (var i in infoAboutSt)
            {
                if (i.stInfo.Equals(st))
                {
                    return i;
                }
            }
            return null;
        }

        public Station FindNotVisitedStationWithMinSum()    //Поиск непосещенной станции с минимальным значением суммы (дистанции)
        {
            var minValue = int.MaxValue;
            Station minVertexInfo = null;
            
            foreach (var i in infoAboutSt)
            {
                if (i.notVisited && i.distance < minValue)
                {
                    minVertexInfo = i;
                    minValue = (int)i.distance;
                }
            }
            return minVertexInfo;
        }

        //public string FindShortestPath(Station startName, Station finishName)   //Поиск кратчайшего пути по названиям станций
        //{
        //    return FindShortestPath(metro.FindStation(startName), metro.FindStation(finishName));
        //}

        public string FindShortestPath(Station startVertex, Station finishVertex)   //Поиск кратчайшего пути (Алг Дейкстры)
        {
            InitInfo();
            var first = GetStationInfo(startVertex);
            first.distance = 0;
            while (true)
            {
                var current = FindNotVisitedStationWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startVertex, finishVertex);
        }

        public void SetSumToNextVertex(Station info)   //Вычисление сумарного времени для линий(веток метро) для следующей станции
        {
            info.notVisited = false;        //info - Информация о текущей станции
            foreach (var e in metro.AllLines)
            {
                var nextInfo = GetStationInfo(e.ConnectedStation);
                var sum = info.distance + e.Time;
                if (sum < nextInfo.distance)
                {
                    nextInfo.distance = sum;
                    nextInfo.prevStation = info.stInfo;
                }
            }
        }

        public string GetPath(Station startVertex, Station endVertex)   //Получить путь
        {
            var path = endVertex.ToString();
            while (startVertex != endVertex)
            {
                endVertex = GetStationInfo(endVertex).prevStation;
                path = endVertex.ToString() + path;
            }
            return path;
        }

    }
}
