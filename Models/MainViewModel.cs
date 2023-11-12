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
        public MainViewModel()
        {
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
        }
    }
}
