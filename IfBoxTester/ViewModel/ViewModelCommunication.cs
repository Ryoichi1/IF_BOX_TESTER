using Microsoft.Practices.Prism.Mvvm;

namespace IfBoxTester
{

    public class ViewModelCommunication : BindableBase
    {
        //LPC1768
        private string _TX;
        public string TX
        {
            get { return _TX; }
            set { SetProperty(ref _TX, value); }
        }

        private string _RX;
        public string RX
        {
            get { return _RX; }
            set { SetProperty(ref _RX, value); }
        }


    }
}
