﻿using System;
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

namespace GeoLib.WindowsHost
{
    using System.ServiceModel;
    using System.Threading;

    using GeoLib.Services;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost hostGeoManager = null;

        public MainWindow()
        {
            InitializeComponent();

            BtnStart.IsEnabled = true;
            BtnStop.IsEnabled = false;

            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId;
        }

        private void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            hostGeoManager = new ServiceHost(typeof(GeoManager));
            hostGeoManager.Open();

            BtnStart.IsEnabled = false;
            BtnStop.IsEnabled = true;
        }

        private void BtnStop_OnClick(object sender, RoutedEventArgs e)
        {
            hostGeoManager.Close();

            BtnStart.IsEnabled = true;
            BtnStop.IsEnabled = false;
        }
    }
}
