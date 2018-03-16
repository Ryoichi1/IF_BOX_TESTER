﻿using System.Windows;
using Microsoft.Practices.Prism.Mvvm;
using System.Linq;

namespace IfBoxTester
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class ErrInfoTestConnector
    {
        public class vm : BindableBase
        {
            private Visibility _VisCN1 = Visibility.Hidden;
            public Visibility VisCN1 { get { return _VisCN1; } set { SetProperty(ref _VisCN1, value); } }

            private Visibility _VisCN2 = Visibility.Hidden;
            public Visibility VisCN2 { get { return _VisCN2; } set { SetProperty(ref _VisCN2, value); } }

            private Visibility _VisCN3 = Visibility.Hidden;
            public Visibility VisCN3 { get { return _VisCN3; } set { SetProperty(ref _VisCN3, value); } }

            private Visibility _VisCN4 = Visibility.Hidden;
            public Visibility VisCN4 { get { return _VisCN4; } set { SetProperty(ref _VisCN4, value); } }

            private Visibility _VisCN5 = Visibility.Hidden;
            public Visibility VisCN5 { get { return _VisCN5; } set { SetProperty(ref _VisCN5, value); } }

            private Visibility _VisCN6 = Visibility.Hidden;
            public Visibility VisCN6 { get { return _VisCN6; } set { SetProperty(ref _VisCN6, value); } }

            private Visibility _VisCN7 = Visibility.Hidden;
            public Visibility VisCN7 { get { return _VisCN7; } set { SetProperty(ref _VisCN7, value); } }

            private Visibility _VisCN8 = Visibility.Hidden;
            public Visibility VisCN8 { get { return _VisCN8; } set { SetProperty(ref _VisCN8, value); } }

            private Visibility _VisCN9 = Visibility.Hidden;
            public Visibility VisCN9 { get { return _VisCN9; } set { SetProperty(ref _VisCN9, value); } }

            private Visibility _VisCN10 = Visibility.Hidden;
            public Visibility VisCN10 { get { return _VisCN10; } set { SetProperty(ref _VisCN10, value); } }

            private Visibility _VisCN11 = Visibility.Hidden;
            public Visibility VisCN11 { get { return _VisCN11; } set { SetProperty(ref _VisCN11, value); } }


            private string _NgList;
            public string NgList { get { return _NgList; } set { SetProperty(ref _NgList, value); } }

        }

        private vm viewmodel;

        public ErrInfoTestConnector()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewmodel = new vm();
            this.DataContext = viewmodel;
            SetErrInfo();
        }
        private void SetErrInfo()
        {
            if (TestConnector.ListCnSpecs == null) return;
            var NgList = TestConnector.ListCnSpecs.Where(cn => !cn.result);

            foreach (var cn in NgList)
            {
                switch (cn.name)
                {
                    case TestConnector.NAME.CN1:
                        viewmodel.VisCN1 = Visibility.Visible;
                        viewmodel.NgList += "CN1\r\n";
                        break;
                    case TestConnector.NAME.CN2:
                        viewmodel.VisCN2 = Visibility.Visible;
                        viewmodel.NgList += "CN2\r\n";
                        break;
                    case TestConnector.NAME.CN3:
                        viewmodel.VisCN3 = Visibility.Visible;
                        viewmodel.NgList += "CN3\r\n";
                        break;
                    case TestConnector.NAME.CN4:
                        viewmodel.VisCN4 = Visibility.Visible;
                        viewmodel.NgList += "CN4\r\n";
                        break;
                    case TestConnector.NAME.CN5:
                        viewmodel.VisCN5 = Visibility.Visible;
                        viewmodel.NgList += "CN5\r\n";
                        break;
                    case TestConnector.NAME.CN6:
                        viewmodel.VisCN6 = Visibility.Visible;
                        viewmodel.NgList += "CN6\r\n";
                        break;
                    case TestConnector.NAME.CN7:
                        viewmodel.VisCN7 = Visibility.Visible;
                        viewmodel.NgList += "CN7\r\n";
                        break;
                    case TestConnector.NAME.CN8:
                        viewmodel.VisCN8 = Visibility.Visible;
                        viewmodel.NgList += "CN8\r\n";
                        break;
                    case TestConnector.NAME.CN9:
                        viewmodel.VisCN9 = Visibility.Visible;
                        viewmodel.NgList += "CN9\r\n";
                        break;
                    case TestConnector.NAME.CN10:
                        viewmodel.VisCN10 = Visibility.Visible;
                        viewmodel.NgList += "CN10\r\n";
                        break;
                    case TestConnector.NAME.CN11:
                        viewmodel.VisCN11 = Visibility.Visible;
                        viewmodel.NgList += "CN11\r\n";
                        break;
                }
            }
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            State.VmMainWindow.TabIndex = 0;
            
        }

    }
}
