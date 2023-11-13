using System;
using LiveCharts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace WPF_Digital_Screen_Demo.Models
{
    public class MainViewModel
    {
        public SeriesCollection StateSeries { get; set; }

        public List<CompareItemModel> WorkerCompareList { get; set; }

        public MainViewModel()
        {
            #region 环状图数据初始化
            StateSeries = new SeriesCollection();
            StateSeries.Add(new PieSeries()
            {
                Title = "一等品",
                Values = new ChartValues<double>(new double[] { 0.533}),
                Fill = new SolidColorBrush(Color.FromArgb(255,43,182,254))
            }) ;

            StateSeries.Add(new PieSeries()
            {
                Title = "二等品",
                Values = new ChartValues<double>(new double[] { 0.2 }),
                Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 254))
            });

            StateSeries.Add(new PieSeries()
            {
                Title = "三等品",
                Values = new ChartValues<double>(new double[] { 0.167 }),
                Fill = new SolidColorBrush(Color.FromArgb(255, 0, 254, 0))
            });

            StateSeries.Add(new PieSeries()
            {
                Title = "不良品",
                Values = new ChartValues<double>(new double[] { 0.1 }),
                Fill = new SolidColorBrush(Color.FromArgb(255, 254, 0, 0))               
            });

            #endregion

            #region 人员绩效初始化
            string Empolys = new string[] { "张三", "李四", "王五", "侯六", "苟七" };
            WorkerCompareList = new List<CompareItemModel>();
            #endregion
        }
    }
}
