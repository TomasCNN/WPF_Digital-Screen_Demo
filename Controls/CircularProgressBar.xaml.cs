using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Digital_Screen_Demo.Controls
{
    /// <summary>
    /// CircularProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        public Brush BackColor
        {
            get { return (Brush)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(Brush), typeof(CircularProgressBar), new PropertyMetadata(Brushes.LightGray));


        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(0.0));

        public string Title { get; set; }

        //public int Title
        //{
        //    get { return (int)GetValue(TitleProperty); }
        //    set { SetValue(TitleProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty TitleProperty =
        //    DependencyProperty.Register("Title", typeof(int), typeof(CircularProgressBar), new PropertyMetadata(0));

        public CircularProgressBar()
        {
            InitializeComponent();
        }
    }
}
