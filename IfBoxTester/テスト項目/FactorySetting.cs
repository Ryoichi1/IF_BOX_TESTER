using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static IfBoxTester.General;

namespace IfBoxTester
{
    public static class FactorySetting
    {

        public static async Task<bool> Check()
        {
            var result = false;
            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {

                        General.PlaySound(General.soundNotice);
                        State.VmTestStatus.Message = "プレスを開けて、JP1 1-2に短絡ソケットを挿入してください";
                        State.VmMainWindow.FlyoutSrc = Constants.PathJp1_12Short;
                        State.VmMainWindow.Flyout = true;

                        while (true)
                        {
                            if (Flags.ClickStopButton) return false;
                            if (!General.CheckPress())
                                break;
                            Thread.Sleep(250);
                        }

                        while (true)
                        {
                            if (Flags.ClickStopButton) return false;
                            if (General.CheckPress())
                                break;
                            Thread.Sleep(250);
                        }

                        return result = ReadGeneralInput(INPUT_NAME.CN4_9);

                    }
                    catch
                    {
                        return false;
                    }
                });

            }
            finally
            {
                State.VmMainWindow.Flyout = false;
                State.VmTestStatus.Message = "";

                if (!result)
                {
                    State.VmTestStatus.Spec = "規格値 : JP1 1-2短絡";
                    State.VmTestStatus.MeasValue = "計測値 : ---";
                }
            }

        }

    }
}
