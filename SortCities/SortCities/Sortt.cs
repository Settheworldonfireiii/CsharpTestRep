using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCities
{
    public class Sortt
    {   
        //сложность алгоритма в худшем случае(когда первый в изначальном списке элемент - последний перелёт)-O(n^2)
        //в лучшем случае (когда все элементы, кроме небольшого количества, итак упорядочены в порядке перелётов) - O(n)
        //в среднем ближе к O(n^2)
        public static List<Tuple<String, String>> SortCitiesFunct(List<Tuple<String, String>> inilist)
        {
            foreach (Tuple<String, String> tpl in inilist)
            {
                if ((tpl.Item1 == null)|| (tpl.Item2 == null)||(tpl.Item1 == "")||(tpl.Item2 == "")) {
                    throw new EmptyField("one or more of the fields is empty");
                }
            }
            var mylst = new List<Tuple<String, String>>();
            //добавляем в отсортированный список два первых элемента, далее будем добавлять по одному элементу
            //чтобы не пришлось в цикле каждый раз проверять, не является ли данная итерация первой
            FirstInInit(inilist, mylst);
            SortAfterInitFirst(inilist, mylst);

            //достраиваем те элементы, которые идут до первого элемента изначального, несортированного списка
            SortBeforeInitFirst(inilist, mylst);
            return mylst;
         }




        //добавляем в отсортированный список два первых элемента, потому что далее будем добавлять по одному элементу
        public static void FirstInInit(List<Tuple<String, String>> inilist, List<Tuple<String, String>> mylst)
        {
            for (int k = 1; k < inilist.Count; k++)
            {
                Tuple<String, String> tpl;
                tpl = inilist[k];
                if (inilist[0].Item2.Equals(tpl.Item1, StringComparison.InvariantCultureIgnoreCase))
                {
                    mylst.Add(inilist[0]);
                    mylst.Add(tpl);
                    inilist.RemoveAt(0);
                    k--;
                    inilist.RemoveAt(k);
                    break;

                }
            }
        }


        //вначале располагаем в нужном порядке те элементы, которые будут следовать после элемента,
        //который был первым в изначальном, несортированном списке
        public static void SortAfterInitFirst(List<Tuple<String, String>> inilist, List<Tuple<String, String>> mylst)
        {
            for (int i = 0; i < mylst.Count; i++)
            {
                Tuple<String, String> tpl = mylst[i];
                for (int k = 0; k < inilist.Count; k++)
                {
                    Tuple<String, String> tpl_inner = inilist[k];
                    if (tpl.Item2.Equals(tpl_inner.Item1, StringComparison.InvariantCultureIgnoreCase))
                    {
                        mylst.Add(tpl_inner);
                        inilist.RemoveAt(k);
                        break;
                    }
                }
            }
        }


        //достраиваем те элементы, которые идут до первого элемента изначального, несортированного списка
        public static void SortBeforeInitFirst(List<Tuple<String, String>> inilist, List<Tuple<String, String>> mylst)
        {
            while (inilist.Count != 0)
            {
                Tuple<String, String> tpl = mylst[0];
                for (int k = 0; k < inilist.Count; k++)
                {

                    Tuple<String, String> tpl_inner = inilist[k];
                    if (tpl.Item1.Equals(tpl_inner.Item2, StringComparison.InvariantCultureIgnoreCase))
                    {
                        mylst.Insert(0, tpl_inner);
                        inilist.RemoveAt(k);
                        break;
                    }

                }
            }

        }
        //вывод
        public static void outPut(List<Tuple<String, String>> mylst)
        {
            foreach (Tuple<String, String> tpl in mylst)
            {
                Console.WriteLine(tpl.Item1 + ' ' + tpl.Item2);
            }
        }



    }
    //исключение в случае пустого или нулевого ввода
    public class EmptyField : Exception
    {
        public EmptyField():base() { }
        public EmptyField(string message): base(message) { }
    } 
}





