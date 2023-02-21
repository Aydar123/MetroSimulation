using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            LineMetro vetka1 = new LineMetro("Кольцевая");
            LineMetro vetka2 = new LineMetro("Восточная");
            LineMetro vetka3 = new LineMetro("Западная");

            MetroMap metroMap = new MetroMap();
            Station k1 = new Station("KAI-1", vetka1, TypeStation.StandartStation);
            Station k2 = new Station("КАI-2", vetka1, TypeStation.StandartStation);
            Station k3 = new Station("KAI-3", vetka1, TypeStation.StandartStation);
            Station k4 = new Station("KAI-4", vetka1, TypeStation.TransfetStations);
            Station k5 = new Station("KAI-5", vetka2, TypeStation.EndStations);
            Station k6 = new Station("KAI-6", vetka2, TypeStation.TransfetStations);
            Station k7 = new Station("KAI-7", vetka2, TypeStation.StandartStation);
            Station k8 = new Station("KAI-8", vetka2, TypeStation.EndStations);
            Station k9 = new Station("KAI-9", vetka3, TypeStation.EndStations);
            Station k10 = new Station("KAI-10", vetka3, TypeStation.TransfetStations);
            Station k11 = new Station("KAI-11", vetka3, TypeStation.StandartStation);
            Station k12 = new Station("KAI-12", vetka3, TypeStation.EndStations);

            metroMap.AddStation(k1);
            metroMap.AddStation(k2);
            metroMap.AddStation(k3);
            metroMap.AddStation(k4);
            metroMap.AddStation(k5);
            metroMap.AddStation(k6);
            metroMap.AddStation(k7);
            metroMap.AddStation(k8);
            metroMap.AddStation(k9);
            metroMap.AddStation(k10);
            metroMap.AddStation(k11);
            metroMap.AddStation(k12);

            metroMap.AddLine(k1, k2, 60);       //Добавить перегоны \ ориентированный граф 
            metroMap.AddLine(k2, k3, 45);
            metroMap.AddLine(k3, k4, 5);
            metroMap.AddLine(k4, k1, 20);

            metroMap.AddLine(k5, k6, 90);
            metroMap.AddLine(k6, k5, 90);
            metroMap.AddLine(k6, k4, 5);
            metroMap.AddLine(k4, k6, 5);
            metroMap.AddLine(k6, k7, 50);
            metroMap.AddLine(k7, k6, 50);
            metroMap.AddLine(k7, k8, 30);
            metroMap.AddLine(k8, k7, 30);

            metroMap.AddLine(k9, k10, 25);
            metroMap.AddLine(k10, k9, 25);
            metroMap.AddLine(k10, k2, 5);
            metroMap.AddLine(k2, k10, 5);
            metroMap.AddLine(k10, k11, 55);
            metroMap.AddLine(k11, k10, 55);
            metroMap.AddLine(k11, k12, 15);
            metroMap.AddLine(k12, k11, 30);

            /*
            metroMap.BFS(k1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTest BFS --- Start");
            Console.ResetColor();
            foreach (Station v in metroMap.AllStations)
            {
               // metroMap.PrintPath(k1, v);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Test BFS --- End\n");
            Console.ResetColor();
            */
            
            metroMap.AddLineMetro(vetka1);
            metroMap.AddLineMetro(vetka2);
            metroMap.AddLineMetro(vetka3);

            vetka1.AddStation(k1);
            vetka1.AddStation(k2);
            vetka1.AddStation(k3);
            vetka1.AddStation(k4);

            vetka1.AddLine(k1, k2, 60);
            vetka1.AddLine(k2, k3, 45);
            vetka1.AddLine(k3, k4, 5);
            vetka1.AddLine(k4, k1, 20);

            //Console.WriteLine("{0}", vetka1);

            vetka2.AddStation(k5);
            vetka2.AddStation(k6);
            vetka2.AddStation(k7);
            vetka2.AddStation(k8);

            vetka2.AddLine(k5, k6, 90);
            vetka2.AddLine(k6, k5, 90);
            vetka2.AddLine(k6, k4, 5);
            vetka2.AddLine(k4, k6, 5);
            vetka2.AddLine(k6, k7, 50);
            vetka2.AddLine(k7, k6, 50);
            vetka2.AddLine(k7, k8, 30);
            vetka2.AddLine(k8, k7, 30);
           
            //Console.WriteLine("{0}", vetka2);

            vetka3.AddStation(k9);
            vetka3.AddStation(k10);
            vetka3.AddStation(k11);
            vetka3.AddStation(k12);

            vetka3.AddLine(k9, k10, 25);
            vetka3.AddLine(k10, k9, 25);
            vetka3.AddLine(k10, k2, 5);
            vetka3.AddLine(k2, k10, 5);
            vetka3.AddLine(k10, k11, 55);
            vetka3.AddLine(k11, k10, 55);
            vetka3.AddLine(k11, k12, 15);
            vetka3.AddLine(k12, k11, 30);

            //Console.WriteLine("{0}", vetka3);

            Console.WriteLine("Добро пожаловать в Metro Simulation!");
            Console.WriteLine("----------------------------------------------------------------------------------");
            //Ввод начальной и конечной станции:
            Station start = k9;
            Station finish = k8;

            metroMap.BFS(start);
            LineMetro vv = finish.Vetka;
            metroMap.PrintPath(start, finish, vv);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("Итого ваше время пути составит: {0} минут\n", finish.distance);

            Console.ReadKey();

            Console.WriteLine("\nВся информация о метро!");
            metroMap.View();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Итого:");
            Console.ResetColor();
            Console.WriteLine("Общее количество веток: {0}", metroMap.MetroLineCount);
            Console.WriteLine("Общее количество станций: {0}", metroMap.StationsCount);
            Console.WriteLine("Общее количество перегонов: {0}", metroMap.LinesCount);

            Console.WriteLine("\n Информация о ветке метро:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Название {0}", vetka1);
            Console.ResetColor();
            Console.WriteLine("Общее количесво станций в ней составяет: {0}\nОбщее количество пергонов в ней составляет: {1}", vetka1.StationsCountLM, vetka1.LinesCountLM);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Название {0}", vetka2);
            Console.ResetColor();
            Console.WriteLine("Общее количесво станций в ней составяет: {0}\nОбщее количество пергонов в ней составляет: {1}", vetka2.StationsCountLM, vetka2.LinesCountLM);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Название {0}", vetka3);
            Console.ResetColor();
            Console.WriteLine("Общее количесво станций в ней составяет: {0}\nОбщее количество пергонов в ней составляет: {1}", vetka3.StationsCountLM, vetka3.LinesCountLM);



            Console.ReadKey();
        }
    }
}
