﻿using System;
using System.Windows;
using System.Windows.Navigation;

namespace IfBoxTester
{
    /// <summary>
    /// Config.xaml の相互作用ロジック
    /// </summary>
    public partial class Conf
    {
        private NavigationService naviMente;
        private NavigationService naviOperator;
        private NavigationService naviTheme;
        Uri uriMentePage    = new Uri("Page/Config/Mente.xaml", UriKind.Relative);
        Uri uriOperatorPage = new Uri("Page/Config/EditOpeList.xaml", UriKind.Relative);
        Uri uriThemePage    = new Uri("Page/Config/Theme.xaml", UriKind.Relative);

        public Conf()
        {
            InitializeComponent();
            naviMente    = FrameMente.NavigationService;
            naviOperator = FrameOperator.NavigationService;
            naviTheme    = FrameTheme.NavigationService;

            FrameMente.NavigationUIVisibility    = NavigationUIVisibility.Hidden;
            FrameOperator.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameTheme.NavigationUIVisibility    = NavigationUIVisibility.Hidden;

            TabMenu.SelectedIndex = 0;

            // オブジェクト作成に必要なコードをこの下に挿入します。
        }

        private void TabMente_Loaded(object sender, RoutedEventArgs e)
        {
            naviMente.Navigate(uriMentePage);
        }

        private void TabOperator_Loaded(object sender, RoutedEventArgs e)
        {
            naviOperator.Navigate(uriOperatorPage);
        }

        private void TabTheme_Loaded(object sender, RoutedEventArgs e)
        {
            naviTheme.Navigate(uriThemePage);
        }


    }
}
