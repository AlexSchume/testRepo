using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGNES.Agglomerative_Nesting
{
    class AGNESClass
    {
        public AGNESClass() { }
        static public void Count()
        {
            double[] x = new double[] { 11.5, 20.1, 34.2, 22.1, 13.4, 29.4};
            double[] y = new double[] { 6.9,  11.1, 21.3, 20.5, 9.7, 18.2 };
            double[,] R = new double[x.Length, x.Length];
            /*for (int i = 0; i < x.Length - 1; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    if (i < j) R[i, j] = Math.Sqrt((x[j] - x[i]) * (x[j] - x[i]) + (y[j] - y[i]) * (y[j] - y[i]));
                    Console.Write(R[i, j] + "  ");
                }
                Console.WriteLine();
            }*/
            DistanceMatrix[] mas = new DistanceMatrix[x.Length - 1];
            mas[0] = new DistanceMatrix(x.Length);
            mas[0].SetMatrix(x, y); // рассчитываем матрицу расстояний
            string[] clusters = new string[x.Length];
            for (int i = 0; i < clusters.Length; i++)
            {
                clusters[i] = (i + 1).ToString();
            }
            foreach (var item in clusters)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            Console.WriteLine(mas[0]);
            MinInfo info = mas[0].SearchMin(); // ищем минимальный элемент и его координаты в матрице
            Console.WriteLine(info);
            double[] neww = new double[x.Length];
            int step = 1;
            mas[1] = new DistanceMatrix(x.Length - step);
            for (int i = 0; i < x.Length - step; i++)
            {
                for (int j = 0; j < x.Length - step; j++)
                {
                    if (i != info.i - 1 && j != info.j - 1) mas[1].SetMatrix(mas[0].Matrix[i + step, j + step], i, j);
                    if (j == info.j - 1 && j > i && i != info.i - 1)
                    {
                        Console.WriteLine("i={0}, j={1}", i, j);
                        double dps = mas[0].Matrix[info.i, i + 1]; // должно быть 0, 1
                        double dqs = mas[0].Matrix[i + 1, info.j]; // 1, 4
                        Console.WriteLine(dps + " " + dqs);
                        mas[1].SetMatrix(DistanceMatrix.distanceClosestNeighbors(dps, dqs), i, j);
                    }
                }
            }

            Console.WriteLine(mas[1]);

            step++;
            info = mas[1].SearchMin(); // ищем минимальный элемент и его координаты в матрице
            Console.WriteLine(info);
            mas[2] = new DistanceMatrix(x.Length - step);
            for (int i = 0; i < x.Length - step; i++)
            {
                for (int j = 0; j < x.Length - step; j++)
                {
                    if (i != info.i - 1 && j != info.j - 1) mas[2].SetMatrix(mas[1].Matrix[i + 1, j + 1], i, j);
                    if (j == info.j - 1 && j > i && i != info.i - 1)
                    {
                        Console.WriteLine("i={0}, j={1}", i, j);
                        double dps = mas[1].Matrix[info.i, i + 1]; // должно быть 0, 1
                        double dqs = mas[1].Matrix[i + 1, info.j]; // 1, 4
                        Console.WriteLine(dps + " " + dqs);
                        mas[2].SetMatrix(DistanceMatrix.distanceClosestNeighbors(dps, dqs), i, j);
                    }
                }
            }
            Console.WriteLine(mas[2]);
            /*double min = double.MaxValue;
            int iX = 0, iY = 0;
            for (int i = 0; i < x.Length; i++)
                for (int j = i + 1; j < x.Length; j++)
                    if (R[i,j] < min) { min = R[i, j]; iX = i; iY = j; }
            Console.WriteLine("{0} ({1}, {2}) ", min, iX, iY);
            Console.WriteLine((from double item in R select item).Min());*/
        }
    }
}
