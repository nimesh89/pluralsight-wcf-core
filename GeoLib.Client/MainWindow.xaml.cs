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

namespace GeoLib.Client
{
    using System.Diagnostics;
    using System.Threading;

    using GeoLib.Proxies;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId + " | Process "
                         + Process.GetCurrentProcess().Id.ToString();
        }

        private void BtnGetInfo_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxtZipCode.Text))
            {
                return;
            }

            var proxy = new GeoClient();

            var data = proxy.GetZipInfo(this.TxtZipCode.Text);
            if (data != null)
            {
                LblCity.Content = data.City;
                LblState.Content = data.State;
            }

            proxy.Close();
        }

        private void BtnGetZipCodes_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxtState.Text))
            {
                return;
            }
        }

        private void BtnMakeCall_OnClick(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
