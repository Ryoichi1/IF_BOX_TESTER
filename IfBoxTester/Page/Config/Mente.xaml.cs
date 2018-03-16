using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static IfBoxTester.General; 

namespace IfBoxTester
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class Mente
    {
        private SolidColorBrush ButtonOnBrush = new SolidColorBrush();
        private SolidColorBrush ButtonOffBrush = new SolidColorBrush();
        private const double ButtonOpacity = 0.4;

        public Mente()
        {
            InitializeComponent();
            CanvasComm.DataContext = State.VmComm;

            ButtonOnBrush.Color = Colors.DodgerBlue;
            ButtonOffBrush.Color = Colors.Transparent;
            ButtonOnBrush.Opacity = ButtonOpacity;
            ButtonOffBrush.Opacity = ButtonOpacity;

            SetCommand();

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            buttonPow.Background = Brushes.Transparent;
            General.PowSupply(false);
        }


        bool FlagPow;
        private void buttonPow_Click(object sender, RoutedEventArgs e)
        {
            if (FlagPow)
            {
                General.PowSupply(false);
                buttonPow.Background = ButtonOffBrush;
            }
            else
            {
                General.PowSupply(true);
                buttonPow.Background = ButtonOnBrush;
            }

            FlagPow = !FlagPow;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            State.VmComm.TX = "";
            State.VmComm.RX = "";
        }


        private async void buttonStamp_Click(object sender, RoutedEventArgs e)
        {
            buttonStamp.Background = ButtonOnBrush;
            await General.StampOn();
            buttonStamp.Background = ButtonOffBrush;
        }



        private void SetCommand()
        {
            State.Command.Commands.ForEach(m =>
            {
                cbCommandMain.Items.Add(m);
            });

        }

        private void buttonSendMain_Click(object sender, RoutedEventArgs e)
        {
            if (cbCommandMain.SelectedIndex == -1) return;
            LPC1768.SendData(cbCommandMain.SelectedItem.ToString());
        }

  
    }

}
