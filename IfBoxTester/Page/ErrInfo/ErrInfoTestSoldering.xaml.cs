using System.Windows;
using Microsoft.Practices.Prism.Mvvm;
using System.Linq;

namespace IfBoxTester
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class ErrInfoTestSoldering
    {
        public class vm : BindableBase
        {
            private Visibility _VisCN1 = Visibility.Hidden;
            public Visibility VisCN1 { get { return _VisCN1; } set { SetProperty(ref _VisCN1, value); } }

            private Visibility _VisCN2_13_14 = Visibility.Hidden;
            public Visibility VisCN2_13_14 { get { return _VisCN2_13_14; } set { SetProperty(ref _VisCN2_13_14, value); } }

            private Visibility _VisCN3 = Visibility.Hidden;
            public Visibility VisCN3 { get { return _VisCN3; } set { SetProperty(ref _VisCN3, value); } }

            private Visibility _VisCN7 = Visibility.Hidden;
            public Visibility VisCN7 { get { return _VisCN7; } set { SetProperty(ref _VisCN7, value); } }

            private Visibility _VisCN11_1 = Visibility.Hidden;
            public Visibility VisCN11_1 { get { return _VisCN11_1; } set { SetProperty(ref _VisCN11_1, value); } }

            private Visibility _VisCN11_2 = Visibility.Hidden;
            public Visibility VisCN11_2 { get { return _VisCN11_2; } set { SetProperty(ref _VisCN11_2, value); } }

        }

        private vm viewmodel;

        public ErrInfoTestSoldering()
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
            if (TestSoldering.ListSpecs == null) return;
            var NgList = TestSoldering.ListSpecs.Where(cn => !cn.result);

            foreach (var cn in NgList)
            {
                switch (cn.name)
                {
                    case TestSoldering.NAME.CN3:
                        viewmodel.VisCN1 = Visibility.Visible;
                        viewmodel.VisCN3 = Visibility.Visible;
                        break;
                    case TestSoldering.NAME.CN2_13:
                        viewmodel.VisCN2_13_14 = Visibility.Visible;
                        viewmodel.VisCN7 = Visibility.Visible;
                        break;
                    case TestSoldering.NAME.CN11_1:
                        viewmodel.VisCN11_1 = Visibility.Visible;
                        break;
                    case TestSoldering.NAME.CN11_2:
                        viewmodel.VisCN11_2 = Visibility.Visible;
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
