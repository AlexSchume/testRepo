using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGNES.Agglomerative_Nesting
{
    class MinInfo
    {
        public int i;
        public int j;
        public double value;
        public MinInfo(int i, int j, double value)
        {
            this.i = i;
            this.j = j;
            this.value = value;
        }
        public override string ToString()
        {
            return "Минимальное расстояние: " + value + " (" + i + "," + j + ")";
        }
    }
    class DistanceMatrix
    {
        double[,] matrix;
        public DistanceMatrix(int size)
        {
            matrix = new double[size, size];
        }
        public double[,] Matrix
        {
            get { return matrix; }
        }
        public void SetMatrix(double val, int i, int j)
        {
            matrix[i, j] = val;
        }
        public void SetMatrix(double[] x, double[] y)
        {
            for (int i = 0; i < x.Length - 1; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    if (i < j) matrix[i, j] = Math.Sqrt((x[j] - x[i]) * (x[j] - x[i]) + (y[j] - y[i]) * (y[j] - y[i]));
                    //Console.Write(R[i, j] + "  ");
                }
                //Console.WriteLine();
            }
        }
        public MinInfo SearchMin() {
            double min = double.MaxValue;
            int iX = 0, iY = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                    if (matrix[i, j] < min) { min = matrix[i, j]; iX = i; iY = j; }
            //Console.WriteLine("{0} ({1}, {2}) ", min, iX, iY);
            return new MinInfo(iX, iY, min);
        }
        /// <summary>
        /// Вычисление расстояния между ближайшими соседями
        /// </summary>
        /// <param name="dps">Расстояние от первого объединяемого кластера до имеющегося</param>
        /// <param name="dqs">Расстояние от второго объединяемого кластера до имеющегося</param>
        /// <returns>Расстояние</returns>
        static public double distanceClosestNeighbors(double dps, double dqs)
        {
            return 0.5 * dps + 0.5 * dqs - 0.5 * Math.Abs(dps - dqs);
        }
        /// <summary>
        /// Вычисление расстояния между самыми удалёнными соседями
        /// </summary>
        /// <param name="dps">Расстояние от первого объединяемого кластера до имеющегося</param>
        /// <param name="dqs">Расстояние от второго объединяемого кластера до имеющегося</param>
        /// <returns>Расстояние</returns>
        static public double distanceMostDistantNeighbors(double dps, double dqs)
        {
            return 0.5 * dps + 0.5 * dqs + 0.5 * Math.Abs(dps - dqs);
        }
        /// <summary>
        /// Вычисление расстояния между кластерами по методу медиан
        /// </summary>
        /// <param name="dps">Расстояние от первого объединяемого кластера до имеющегося</param>
        /// <param name="dqs">Расстояние от второго объединяемого кластера до имеющегося</param>
        /// <param name="dpq">Расстояние между объединяемыми кластерами</param>
        /// <returns>Расстояние</returns>
        static public double distanceMediansMethod(double dps, double dqs, double dpq)
        {
            return 0.5 * dps + 0.5 * dqs - 0.25 * dpq;
        }
        /// <summary>
        /// Вычисление среднего расстояния между кластерами
        /// </summary>
        /// <param name="dps"></param>
        /// <param name="dqs"></param>
        /// <returns>Расстояние</returns>
        static public double distanceMean(double dps, double dqs)
        {
            return 0.5 * dps + 0.5 * dqs;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    
                    res += Math.Round(matrix[i, j], 1).ToString() + "\t";
                }
                res += "\r\n";
            }
            return res;
        }
    }
}
