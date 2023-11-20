using System;
using LiveCharts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using System.Windows.Media;
using LiveCharts.Defaults;

namespace WPF_Digital_Screen_Demo.Models
{
    public class MainViewModel
    {
        public SeriesCollection StateSeries { get; set; }

        public ChartValues<ObservableValue>YeildValue1 { get; set; }

        public ChartValues<ObservableValue> YeildValue2 { get; set; }

        public List<CompareItemModel> WorkerCompareList { get; set; }

        public List<string>Alarms { get; set; }

        public string CurrentYeild { get; set; } = "100860";

        public int FinishRate { get; set; } = 80;

        Random random = new Random();

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
            string[] Empolys = new string[] { "张三", "李四", "王五", "侯六", "苟七" };
            WorkerCompareList = new List<CompareItemModel>();
            foreach (var e in Empolys)
            {
                WorkerCompareList.Add(new CompareItemModel()
                {
                    Name = e,
                    PlanValue = random.Next(0, 150),
                    FinishedValue=random.Next(101, 200)
                }); 
            }
            #endregion

            #region 报警信息初始化
            Alarms = new List<string>();
            Alarms.Add("【H338->厂务冷却水入水温度[℃]】 34 -> 10:00");
            Alarms.Add("【H338->厂务冷却水入水温度[℃]】 34 -> 10:00");
            Alarms.Add("【H338->厂务冷却水入水温度[℃]】 34 -> 10:00");
            Alarms.Add("【H338->厂务冷却水入水温度[℃]】 34 -> 10:00");
            Alarms.Add("【H338->厂务冷却水入水温度[℃]】 34 -> 10:00");
            Alarms.Add("【H338->厂务冷却水入水温度[℃]】 34 -> 10:00");
            #endregion

            #region 统计图数据初始化
            YeildValue1 = new ChartValues<ObservableValue>();
            YeildValue2 = new ChartValues<ObservableValue>();
            for(int i = 0; i < Empolys.Length; i++) 
            {
                YeildValue1.Add(new ObservableValue(random.Next(20, 380)));
                YeildValue2.Add(new ObservableValue(random.Next(20, 300)));
            }
            #endregion

        }
    }
}
