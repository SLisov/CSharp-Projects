using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNr2_Lisovskyi55106
{
    class SLSortowanie
    {
        static public ushort SLSelectSort(ref double[] T, int l)
        {
            ushort SLk;
            double SLPomocnicza = 0;
            ushort SLLicznikOperacjiDominujacych = 0;
            for (ushort i = 0; i < l; i++)
            {
                SLk = i;
                for (ushort j = (ushort)(i + 1); j < l; j++)
                {
                    SLLicznikOperacjiDominujacych++;
                    if (T[SLk] > T[j])
                    {
                        SLk = j;
                    }
                    SLPomocnicza = T[i];
                }
                T[i] = T[SLk];
                T[SLk] = SLPomocnicza;
            }
            return SLLicznikOperacjiDominujacych;
        }
        static public ushort SLInsertionSort(ref double[] T, int n)
        {
            double SLElement;
            ushort SLk;
            ushort SLLicznik = 0;
            for (ushort i = 1; i < n; i++)
            {
                SLElement = T[i];
                SLk = i;
                while ((SLk > 0) && (SLElement < T[SLk - 1]))
                {
                    SLLicznik++;
                    T[SLk] = T[SLk - 1];
                    SLk--;
                }
                SLLicznik++;
                T[SLk] = SLElement;
            }
            return SLLicznik;
        }

        public static ushort SLCombSort(ref double[] yiT, int yil)
        {
            ushort SLLicznik = 0;
            int SLgap = yil;

            bool SLswapped = true;
            while (SLgap != 1 || SLswapped == true)
            {
                SLLicznik++;
                SLgap = SLGetNextGap(SLgap);
                SLswapped = false;
                for (int i = 0; i < yil - SLgap; i++)
                {
                    if (yiT[i] > yiT[i + SLgap])
                    {
                        double ybtemp = yiT[i];
                        yiT[i] = yiT[i + SLgap];
                        yiT[i + SLgap] = ybtemp;
                        SLswapped = true;
                        SLLicznik++;
                    }
                }
            }
            return SLLicznik;
        }
        static int SLGetNextGap(int SLgap)
        {
            SLgap = (SLgap * 10) / 13;
            if (SLgap < 1)
                return 1;
            return SLgap;
        }

        public static ushort SLbogosort(ref double[] Array, int l)
        {

            double SLmax = Array[0];
            ushort SLlicznik = 0;

            for (int i = 1; i < l; i++)
            {
                SLlicznik++;
                if (SLmax < Array[i])
                    SLmax = Array[i];
            }


            for (int SLplace = 1; SLmax / SLplace > 0; SLplace *= 10)
            {
                SLlicznik++;
                SLcountingsort(Array, SLplace);
            }
            return SLlicznik++;
        }


        static void SLcountingsort(double[] SLArray, int SLplace)
        {
            double SLn = SLArray.Length;
            double[] SLoutput = new double[(int)SLn];

            int[] SLfreq = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < SLn; i++)
                SLfreq[(int)((SLArray[i] / SLplace) % 10)]++;


            for (int i = 1; i < 10; i++)
                SLfreq[i] += SLfreq[i - 1];

            for (int SLi = (int)(SLn - 1); SLi >= 0; SLi--)
            {
                SLoutput[SLfreq[(int)((SLArray[SLi] / SLplace) % 10)] - 1] = SLArray[SLi];
                SLfreq[(int)((SLArray[SLi] / SLplace) % 10)]--;
            }

            for (int i = 0; i < SLn; i++)
                SLArray[i] = SLoutput[i];
        }
    }
}
