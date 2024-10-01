using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNr3_Lisovskyi55106
{
    public class SLGraph
    {
        private int SLVertices { get; }

        public LinkedList<int>[] SLadjancencyList { get; set; }



        public SLGraph(int stv)
        {
            SLVertices = stv;
            SLadjancencyList = new LinkedList<int>[stv];
            for (int i = 0; i < SLadjancencyList.Length; i++)
            {
                SLadjancencyList[i] = new LinkedList<int>();
            }
        }
        public void SLaddEdge(int SLstartVertex, int SLendVertex)
        {
            SLadjancencyList[SLstartVertex].AddLast(SLendVertex);
        }
        public int SLGetLength()
        {
            return SLadjancencyList.Length;
        }

        public String SLBFS(int s)
        {
            bool[] SLvisited = new bool[SLVertices];
            String str = "";
            for (int i = 0; i < SLVertices; i++)
                SLvisited[i] = false;

            LinkedList<int> SLqueue = new LinkedList<int>();

            SLvisited[s] = true;
            SLqueue.AddLast(s);

            while (SLqueue.Any())
            {
                s = SLqueue.First();
                Console.Write(s + " ");
                SLqueue.RemoveFirst();
                str += " next -> " + s;
                LinkedList<int> list = SLadjancencyList[s];

                foreach (var val in list)
                {
                    if (!SLvisited[val])
                    {
                        SLvisited[val] = true;
                        SLqueue.AddLast(val);
                    }
                }
            }
            return str;
        }
    }
}
