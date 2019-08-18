using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGNES.Agglomerative_Nesting;
using Graph = System.Windows.Forms.DataVisualization.Charting;

namespace AGNES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AGNESClass obj = new AGNESClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] names = new string[] { "Липецкая", "Тульская", "Тамбовская", "Воронежская", "Белгородская", "Брянская" };
            double[] x = new double[] { 11.5, 20.1, 34.2, 22.1, 13.4, 29.4 };
            double[] y = new double[] { 6.9, 11.1, 21.3, 20.5, 9.7, 18.2 };
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            chart1.Titles.Add("Data");
            for (int i = 0; i < names.Length; i++)
            {
                chart1.Series.Add(names[i]);
                chart1.Series[names[i]].ChartType = Graph.SeriesChartType.Point;
                chart1.Series[names[i]].MarkerSize = 10;
                chart1.Series[names[i]].Points.AddXY(x[i], y[i]);
            }
            AGNESClass.Count();
        }
    }
}
