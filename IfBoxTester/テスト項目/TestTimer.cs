using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Threading.Thread;
using static IfBoxTester.General;

namespace IfBoxTester
{
    public static class TestTimer
    {

        public static async Task<bool> Check()
        {
            bool result = false;
            bool NoticeSound = false;
            try
            {
                return await Task<bool>.Run(() =>
                {

                    try
                    {
                        State.VmTestStatus.Message = "";
                        State.VmTestStatus.VisMessSub = System.Windows.Visibility.Visible;
                        while (true)
                        {
                            if (Flags.ClickStopButton)
                                return false;

                            LPC1768.SendData(Data: "MeasTime", Wait: 4000);
                            if (!Double.TryParse(LPC1768.RecieveData, out var timeSecond))
                                return false;

                            State.VmTestResults.V1V2Time = $"{LPC1768.RecieveData}秒";

                            if (timeSecond > State.TestSpec.V24ToV0TimeSecondMax)
                            {
                                if (!NoticeSound)
                                {
                                    General.PlaySound(General.soundNotice);
                                    NoticeSound = true;
                                }
                                State.VmTestStatus.Message = "VR1を左に回せ！";
                                State.VmTestStatus.VisAllowLeft = System.Windows.Visibility.Visible;
                                State.VmTestStatus.VisAllowRight = System.Windows.Visibility.Hidden;
                            }
                            else if (timeSecond < State.TestSpec.V24ToV0TimeSecondMin)
                            {
                                if (!NoticeSound)
                                {
                                    General.PlaySound(General.soundNotice);
                                    NoticeSound = true;
                                }
                                State.VmTestStatus.Message = "VR1を右に回せ！";
                                State.VmTestStatus.VisAllowLeft = System.Windows.Visibility.Hidden;
                                State.VmTestStatus.VisAllowRight = System.Windows.Visibility.Visible;
                            }
                            else
                            {
                                State.VmTestStatus.Message = "VR1調整OK！　   調整ドライバーを外せ";
                                State.VmTestStatus.VisAllowLeft = System.Windows.Visibility.Hidden;
                                State.VmTestStatus.VisAllowRight = System.Windows.Visibility.Hidden;
                                General.PlaySound(General.soundSuccess);
                                foreach (var i in Enumerable.Range(0, 3))
                                {
                                    Sleep(2000);
                                    LPC1768.SendData(Data: "MeasTime", Wait: 4000);
                                    if (!Double.TryParse(LPC1768.RecieveData, out var finalTimeSecond))
                                        return false;

                                    State.VmTestResults.V1V2Time = $"{LPC1768.RecieveData}秒";
                                    if (!(State.TestSpec.V24ToV0TimeSecondMin < finalTimeSecond && finalTimeSecond < State.TestSpec.V24ToV0TimeSecondMax))
                                        goto RETRY;
                                }
                                return true;
                            }

                            RETRY:
                            Sleep(2000);
                        }

                    }
                    catch
                    {
                        return false;
                    }
                });

            }
            finally
            {
                State.VmTestStatus.VisMessSub = System.Windows.Visibility.Hidden;
                ResetIo();
                State.VmTestStatus.VisAllowLeft = System.Windows.Visibility.Hidden;
                State.VmTestStatus.VisAllowRight = System.Windows.Visibility.Hidden;

                if (!result)
                {
                    State.VmTestStatus.Spec = $"規格値 : {State.TestSpec.V24ToV0TimeSecondMin} ～ {State.TestSpec.V24ToV0TimeSecondMax} 秒";
                    State.VmTestStatus.MeasValue = $"計測値 : {LPC1768.RecieveData}秒";
                }
            }

        }





    }
}
