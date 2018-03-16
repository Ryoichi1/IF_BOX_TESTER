using System.Windows;
using Microsoft.Practices.Prism.Mvvm;
using System.Linq;

namespace IfBoxTester
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class ErrInfoTestIo
    {
        public class vm : BindableBase
        {
            private Visibility _VisCN2_1_2 = Visibility.Hidden;
            public Visibility VisCN2_1_2 { get { return _VisCN2_1_2; } set { SetProperty(ref _VisCN2_1_2, value); } }

            private Visibility _VisCN2_3_4 = Visibility.Hidden;
            public Visibility VisCN2_3_4 { get { return _VisCN2_3_4; } set { SetProperty(ref _VisCN2_3_4, value); } }

            private Visibility _VisCN2_5_6 = Visibility.Hidden;
            public Visibility VisCN2_5_6 { get { return _VisCN2_5_6; } set { SetProperty(ref _VisCN2_5_6, value); } }

            private Visibility _VisCN2_7_8 = Visibility.Hidden;
            public Visibility VisCN2_7_8 { get { return _VisCN2_7_8; } set { SetProperty(ref _VisCN2_7_8, value); } }

            private Visibility _VisCN2_9_10 = Visibility.Hidden;
            public Visibility VisCN2_9_10 { get { return _VisCN2_9_10; } set { SetProperty(ref _VisCN2_9_10, value); } }

            private Visibility _VisCN2_11_12 = Visibility.Hidden;
            public Visibility VisCN2_11_12 { get { return _VisCN2_11_12; } set { SetProperty(ref _VisCN2_11_12, value); } }

            private Visibility _VisCN2_15 = Visibility.Hidden;
            public Visibility VisCN2_15 { get { return _VisCN2_15; } set { SetProperty(ref _VisCN2_15, value); } }


            private Visibility _VisCN4_1_2 = Visibility.Hidden;
            public Visibility VisCN4_1_2 { get { return _VisCN4_1_2; } set { SetProperty(ref _VisCN4_1_2, value); } }

            private Visibility _VisCN4_3_4 = Visibility.Hidden;
            public Visibility VisCN4_3_4 { get { return _VisCN4_3_4; } set { SetProperty(ref _VisCN4_3_4, value); } }

            private Visibility _VisCN4_5_6 = Visibility.Hidden;
            public Visibility VisCN4_5_6 { get { return _VisCN4_5_6; } set { SetProperty(ref _VisCN4_5_6, value); } }

            private Visibility _VisCN4_7_8 = Visibility.Hidden;
            public Visibility VisCN4_7_8 { get { return _VisCN4_7_8; } set { SetProperty(ref _VisCN4_7_8, value); } }

            private Visibility _VisCN4_9_10 = Visibility.Hidden;
            public Visibility VisCN4_9_10 { get { return _VisCN4_9_10; } set { SetProperty(ref _VisCN4_9_10, value); } }

            private Visibility _VisCN4_11_12 = Visibility.Hidden;
            public Visibility VisCN4_11_12 { get { return _VisCN4_11_12; } set { SetProperty(ref _VisCN4_11_12, value); } }

            private Visibility _VisCN5_1_2 = Visibility.Hidden;
            public Visibility VisCN5_1_2 { get { return _VisCN5_1_2; } set { SetProperty(ref _VisCN5_1_2, value); } }

            private Visibility _VisCN5_3_4 = Visibility.Hidden;
            public Visibility VisCN5_3_4 { get { return _VisCN5_3_4; } set { SetProperty(ref _VisCN5_3_4, value); } }

            private Visibility _VisCN6_1_2 = Visibility.Hidden;
            public Visibility VisCN6_1_2 { get { return _VisCN6_1_2; } set { SetProperty(ref _VisCN6_1_2, value); } }

            private Visibility _VisCN6_3_4 = Visibility.Hidden;
            public Visibility VisCN6_3_4 { get { return _VisCN6_3_4; } set { SetProperty(ref _VisCN6_3_4, value); } }

            private Visibility _VisCN6_5_6 = Visibility.Hidden;
            public Visibility VisCN6_5_6 { get { return _VisCN6_5_6; } set { SetProperty(ref _VisCN6_5_6, value); } }

            private Visibility _VisCN6_7_8 = Visibility.Hidden;
            public Visibility VisCN6_7_8 { get { return _VisCN6_7_8; } set { SetProperty(ref _VisCN6_7_8, value); } }



            private Visibility _VisCN8 = Visibility.Hidden;
            public Visibility VisCN8 { get { return _VisCN8; } set { SetProperty(ref _VisCN8, value); } }

            private Visibility _VisCN9_1 = Visibility.Hidden;
            public Visibility VisCN9_1 { get { return _VisCN9_1; } set { SetProperty(ref _VisCN9_1, value); } }

            private Visibility _VisCN9_2 = Visibility.Hidden;
            public Visibility VisCN9_2 { get { return _VisCN9_2; } set { SetProperty(ref _VisCN9_2, value); } }

            private Visibility _VisCN9_3 = Visibility.Hidden;
            public Visibility VisCN9_3 { get { return _VisCN9_3; } set { SetProperty(ref _VisCN9_3, value); } }

            private Visibility _VisCN9_4 = Visibility.Hidden;
            public Visibility VisCN9_4 { get { return _VisCN9_4; } set { SetProperty(ref _VisCN9_4, value); } }

            private Visibility _VisCN9_5 = Visibility.Hidden;
            public Visibility VisCN9_5 { get { return _VisCN9_5; } set { SetProperty(ref _VisCN9_5, value); } }

            private Visibility _VisCN9_6_7 = Visibility.Hidden;
            public Visibility VisCN9_6_7 { get { return _VisCN9_6_7; } set { SetProperty(ref _VisCN9_6_7, value); } }

            private Visibility _VisCN9_8_9 = Visibility.Hidden;
            public Visibility VisCN9_8_9 { get { return _VisCN9_8_9; } set { SetProperty(ref _VisCN9_8_9, value); } }



            private Visibility _VisJP1 = Visibility.Hidden;
            public Visibility VisJP1 { get { return _VisJP1; } set { SetProperty(ref _VisJP1, value); } }


            /////////////////////////////////////////////
            private Visibility _VisRY1A = Visibility.Hidden;
            public Visibility VisRY1A { get { return _VisRY1A; } set { SetProperty(ref _VisRY1A, value); } }

            private Visibility _VisRY1B = Visibility.Hidden;
            public Visibility VisRY1B { get { return _VisRY1B; } set { SetProperty(ref _VisRY1B, value); } }

            private Visibility _VisRY2x = Visibility.Hidden;
            public Visibility VisRY2x { get { return _VisRY2x; } set { SetProperty(ref _VisRY2x, value); } }

            private Visibility _VisRY3x = Visibility.Hidden;
            public Visibility VisRY3x { get { return _VisRY3x; } set { SetProperty(ref _VisRY3x, value); } }

            private Visibility _VisRY4x = Visibility.Hidden;
            public Visibility VisRY4x { get { return _VisRY4x; } set { SetProperty(ref _VisRY4x, value); } }

            private Visibility _VisRY5 = Visibility.Hidden;
            public Visibility VisRY5 { get { return _VisRY5; } set { SetProperty(ref _VisRY5, value); } }

            private Visibility _VisRY6 = Visibility.Hidden;
            public Visibility VisRY6 { get { return _VisRY6; } set { SetProperty(ref _VisRY6, value); } }

            private Visibility _VisRY7 = Visibility.Hidden;
            public Visibility VisRY7 { get { return _VisRY7; } set { SetProperty(ref _VisRY7, value); } }

            private Visibility _VisRY8 = Visibility.Hidden;
            public Visibility VisRY8 { get { return _VisRY8; } set { SetProperty(ref _VisRY8, value); } }

            private Visibility _VisRY9 = Visibility.Hidden;
            public Visibility VisRY9 { get { return _VisRY9; } set { SetProperty(ref _VisRY9, value); } }

            private Visibility _VisRY10 = Visibility.Hidden;
            public Visibility VisRY10 { get { return _VisRY10; } set { SetProperty(ref _VisRY10, value); } }

            private Visibility _VisRY11 = Visibility.Hidden;
            public Visibility VisRY11 { get { return _VisRY11; } set { SetProperty(ref _VisRY11, value); } }

        }

        private vm viewmodel;

        public ErrInfoTestIo()
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
            if (TestIO.ListSpecs == null) return;
            var NgItem = TestIO.ListSpecs.FirstOrDefault(l => !l.TotalResult);

            switch (NgItem.name)
            {
                case TestIO.TEST_CASE.RY1A:
                    viewmodel.VisRY1A = Visibility.Visible;
                    viewmodel.VisJP1 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY1B:
                    viewmodel.VisRY1B = Visibility.Visible;
                    viewmodel.VisCN2_1_2 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY2A_D:
                    viewmodel.VisRY2x = Visibility.Visible;
                    viewmodel.VisCN4_3_4 = Visibility.Visible;
                    viewmodel.VisCN4_7_8 = Visibility.Visible;
                    viewmodel.VisCN5_1_2 = Visibility.Visible;
                    viewmodel.VisCN6_3_4 = Visibility.Visible;
                    viewmodel.VisCN9_1 = Visibility.Visible;
                    viewmodel.VisCN9_5 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY3A_C:
                    viewmodel.VisRY3x = Visibility.Visible;
                    viewmodel.VisCN5_3_4 = Visibility.Visible;
                    viewmodel.VisCN6_7_8 = Visibility.Visible;
                    viewmodel.VisCN9_3 = Visibility.Visible;
                    viewmodel.VisCN9_5 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY4A_C:
                    viewmodel.VisRY4x = Visibility.Visible;
                    viewmodel.VisCN6_5_6 = Visibility.Visible;
                    viewmodel.VisCN9_4 = Visibility.Visible;
                    viewmodel.VisCN9_5 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY5:
                    viewmodel.VisRY5 = Visibility.Visible;
                    viewmodel.VisCN4_9_10 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY7:
                    viewmodel.VisRY1A = Visibility.Visible;
                    viewmodel.VisRY7 = Visibility.Visible;
                    viewmodel.VisRY8 = Visibility.Visible;
                    viewmodel.VisCN2_1_2 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY11:
                    viewmodel.VisRY11 = Visibility.Visible;
                    viewmodel.VisCN2_1_2 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY6_8:
                    viewmodel.VisRY6 = Visibility.Visible;
                    viewmodel.VisRY8 = Visibility.Visible;
                    viewmodel.VisCN9_2 = Visibility.Visible;
                    viewmodel.VisCN9_5 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY2_3_4_9:
                    viewmodel.VisRY2x = Visibility.Visible;
                    viewmodel.VisRY3x = Visibility.Visible;
                    viewmodel.VisRY4x = Visibility.Visible;
                    viewmodel.VisRY9 = Visibility.Visible;
                    viewmodel.VisCN4_3_4 = Visibility.Visible;
                    viewmodel.VisCN4_5_6 = Visibility.Visible;
                    viewmodel.VisCN4_7_8 = Visibility.Visible;
                    viewmodel.VisCN5_1_2 = Visibility.Visible;
                    viewmodel.VisCN5_3_4 = Visibility.Visible;
                    viewmodel.VisCN6_3_4 = Visibility.Visible;
                    viewmodel.VisCN6_5_6 = Visibility.Visible;
                    viewmodel.VisCN6_7_8 = Visibility.Visible;
                    viewmodel.VisCN8 = Visibility.Visible;
                    viewmodel.VisCN9_1 = Visibility.Visible;
                    viewmodel.VisCN9_3 = Visibility.Visible;
                    viewmodel.VisCN9_4 = Visibility.Visible;
                    viewmodel.VisCN9_5 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY3_4:
                    viewmodel.VisRY3x = Visibility.Visible;
                    viewmodel.VisRY4x = Visibility.Visible;
                    viewmodel.VisCN4_5_6 = Visibility.Visible;
                    viewmodel.VisCN4_7_8 = Visibility.Visible;
                    viewmodel.VisCN5_3_4 = Visibility.Visible;
                    viewmodel.VisCN6_5_6 = Visibility.Visible;
                    viewmodel.VisCN6_7_8 = Visibility.Visible;
                    viewmodel.VisCN9_3 = Visibility.Visible;
                    viewmodel.VisCN9_4 = Visibility.Visible;
                    viewmodel.VisCN9_5 = Visibility.Visible;
                    break;
                case TestIO.TEST_CASE.RY1B_2:
                    viewmodel.VisRY1B = Visibility.Visible;
                    viewmodel.VisRY2x = Visibility.Visible;
                    viewmodel.VisCN2_1_2 = Visibility.Visible;
                    viewmodel.VisCN4_3_4 = Visibility.Visible;
                    viewmodel.VisCN4_7_8 = Visibility.Visible;
                    viewmodel.VisCN4_11_12 = Visibility.Visible;
                    viewmodel.VisCN5_1_2 = Visibility.Visible;
                    viewmodel.VisCN6_3_4 = Visibility.Visible;
                    viewmodel.VisCN9_1 = Visibility.Visible;
                    viewmodel.VisCN9_5 = Visibility.Visible;
                    break;
            }
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            State.VmMainWindow.TabIndex = 0;

        }

    }
}
