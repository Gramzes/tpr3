using System;
using System.Collections.Generic;
namespace tpr3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Variant> list = new List<Variant>();
            Random rnd = new Random();
            Console.WriteLine("Цена  Процессор Камера");
            double max_price = -1;
            double max_PrTop = -1;
            double max_CamTop = -1;
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Variant(rnd.Next(14000, 90000), rnd.Next(1, 500), rnd.Next(1, 500)));
                if (max_price < list[i].Price) max_price = list[i].Price;
                if (max_PrTop < list[i].ProcTopPlace) max_PrTop = list[i].ProcTopPlace;
                if (max_CamTop < list[i].CameraTopPlace) max_CamTop = list[i].CameraTopPlace;
                Console.WriteLine(list[i].Price + "   " + list[i].ProcTopPlace + "      " + list[i].CameraTopPlace);
            }
            Console.ReadKey();
            Paretto();
            Console.WriteLine("\n \n \n");
            Console.WriteLine("Паретто");
            Console.WriteLine("Цена  Процессор Камера");
            for (int i = 0; i < 100; i++)
            {
                if (list[i].inList)
                {
                    Console.WriteLine(list[i].Price + "   " + list[i].ProcTopPlace + "      " + list[i].CameraTopPlace);
                }
                list[i].inList = true;
            }
            Console.ReadKey();
            Console.WriteLine("\n \n \n");
            Console.WriteLine("Нижние границы");
            Console.WriteLine("Максимальная цена = 40000, худшее место в топе по процессору = 300, худшее место в топе по камере = 300");
            Console.ReadKey();
            Console.WriteLine("Цена  Процессор Камера");
            for (int i = 0; i < 100; i++)
            {
                if (list[i].Price > 40000 || list[i].ProcTopPlace > 300 || list[i].CameraTopPlace > 300) list[i].inList = false;
                else Console.WriteLine(list[i].Price + "   " + list[i].ProcTopPlace + "      " + list[i].CameraTopPlace);
            }
            Console.ReadKey();
            Console.WriteLine("\n \n \n");
            Console.WriteLine("Из них по Паретто");
            Console.ReadKey();
            Console.WriteLine("Цена  Процессор Камера");
            Paretto();
            for (int i = 0; i < 100; i++)
            {
                if (list[i].inList)
                {
                    Console.WriteLine(list[i].Price + "   " + list[i].ProcTopPlace + "      " + list[i].CameraTopPlace);
                }
                list[i].inList = true;
            }
            Console.ReadKey();
            Console.WriteLine("\n \n \n");
            Console.WriteLine("Выделенный критерий - зарплата");
            Console.WriteLine("Ограничения");
            Console.WriteLine("Худшее место в топе по процессору = 300, худшее место в топе по камере = 300");
            Console.ReadKey();
            Console.WriteLine("Цена  Процессор Камера");
            int min_price = 100000;
            for (int i = 0; i < 100; i++)
            {
                if (list[i].ProcTopPlace > 300 || list[i].CameraTopPlace > 300) list[i].inList = false;
                else if (min_price > list[i].Price)
                {
                    min_price = list[i].Price;
                }
            }
            for (int i = 0; i < 100; i++)
            {
                if (list[i].Price==min_price)
                {
                    Console.WriteLine(list[i].Price + "   " + list[i].ProcTopPlace + "      " + list[i].CameraTopPlace);
                }
                list[i].inList = true;
            }
            Console.ReadKey();
            Console.WriteLine("\n \n \n");
            Console.WriteLine("Лексикографическая оптимизация");
            Console.WriteLine("Цена-Камера-Процессор");
            Console.WriteLine("Цена  Процессор Камера");
            int index = -1;
            int min = 100000;
            for (int i = 0; i < 100; i++)
            {
                if (list[i].inList && list[i].Price < min)
                {
                    if (index != -1)
                    {
                        list[index].inList = false;
                    }
                    index = i;
                }
            }
            index = -1;
            min = 100000;
            for (int i = 0; i < 100; i++)
            {
                if (list[i].inList && list[i].CameraTopPlace < min)
                {
                    if (index != -1)
                    {
                        list[index].inList = false;
                    }
                    index = i;
                }
            }
            index = -1;
            min = 100000;
            for (int i = 0; i < 100; i++)
            {
                if (list[i].inList && list[i].ProcTopPlace < min)
                {
                    if (index != -1)
                    {
                        list[index].inList = false;
                    }
                    index = i;
                }
            }
            for (int i = 0; i < 100; i++)
            {
                if (list[i].Price == min_price)
                {
                    Console.WriteLine(list[i].Price + "   " + list[i].ProcTopPlace + "      " + list[i].CameraTopPlace);
                }
                list[i].inList = true;
            }
            Console.ReadKey();
            Console.WriteLine("\n \n \n");
            Console.WriteLine("Обобщенный критерий");
            Console.WriteLine("Цена  Процессор Камера");
            index = -1;
            double max = -100;
            for (int i = 0; i < 100; i++)
            {
                double zn = -list[i].Price / max_price - list[i].CameraTopPlace / max_CamTop - list[i].ProcTopPlace / max_PrTop;
                if (zn>max)
                {
                    max = zn;
                    index = i;
                }
            }
            Console.WriteLine(list[index].Price + "   " + list[index].ProcTopPlace + "      " + list[index].CameraTopPlace);


            void Paretto()
            {
                for (int i = 0; i < 99; i++)
                {
                    if (!list[i].inList) continue;
                    for (int k = i + 1; k < 100; k++)
                    {
                        if ((list[i] > list[k] || list[i] == list[k]) && list[k].inList)
                        {
                            list[k].inList = false;
                        }
                        else if ((list[i] < list[k]) && list[k].inList)
                        {
                            list[i].inList = false;
                            break;
                        }
                    }
                }
            }
        }
    }
}
