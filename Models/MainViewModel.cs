using System;
using LiveCharts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using System.Windows.Media;
using LiveCharts.Defaults;
using System.Threading;
using System.Net.Sockets;
using WPF_Digital_Screen_Demo.Base;

namespace WPF_Digital_Screen_Demo.Models
{
    public class MainViewModel: NotifyBase
    {
        public SeriesCollection StateSeries { get; set; }

        public ChartValues<ObservableValue>YeildValue1 { get; set; }

        public ChartValues<ObservableValue> YeildValue2 { get; set; }

        public List<CompareItemModel> WorkerCompareList { get; set; }

        public List<CompareItemModel> QualityList { get; set; }

        public List<string>Alarms { get; set; }

        //public string CurrentYeild { get; set; } = "100860";

        private string _currentYeild;

        public string CurrentYeild
        {
            get { return _currentYeild; }
            set { SetProperty(ref _currentYeild, value); }
        }

        public int FinishRate { get; set; } = 80;

        public List<BadItemModel> BadScatter {get; set;}

        Random random = new Random();

        CancellationTokenSource cts = new CancellationTokenSource();

        Task task = null;

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

            #region 不良分布初始化
            BadScatter = new List<BadItemModel>();
            string[] BadNames = new string[] { "缺角A","缺角B","缺角C","缺角D","缺角E","缺角F","缺角G","缺角H" };
            for(int i = 0;i < BadNames.Length;i++)
            {
                BadScatter.Add(new BadItemModel() { Title = BadNames[i], Size = 180 - 20 * i, Value = 0.9 - 0.1 * i });
            }
            #endregion

            #region 质量控制
            string[] quality = new string[] { "机床-1", "机床-2", "机床-3", "机床-4", "机床-5", 
                "机床-6", "机床-7", "机床-8", "机床-9", "机床-10" };
            QualityList = new List<CompareItemModel>();
            foreach (var q in quality)
            {
                QualityList.Add(new CompareItemModel()
                {
                    Name = q,
                    PlanValue = random.Next(0, 150),
                    FinishedValue = random.Next(101, 200)
                });
            }
            #endregion

            #region Modbus实时通讯初始化
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 502);
            Modbus.Device.ModbusIpMaster master = Modbus.Device.ModbusIpMaster.CreateIp(tcpClient);
            task = Task.Run(() =>
            { 
                while (!cts.IsCancellationRequested) 
                {
                    // await Task.Delay(1000);
                    // 获取现场的数据
                    ushort[] values = master.ReadHoldingRegisters(1, 0, 1); 
                    CurrentYeild = values[0].ToString("000000");
                }
            },cts.Token);
        }

        public void Dispose()
        {
            cts.Cancel();
            Task.WaitAny(task);
        }
        #endregion

    }
}
