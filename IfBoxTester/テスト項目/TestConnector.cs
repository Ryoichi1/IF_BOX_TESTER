using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using static System.Threading.Thread;

namespace IfBoxTester
{
    public static class TestConnector
    {
        public enum NAME { CN1, CN2, CN3, CN4, CN5, CN6, CN7, CN8, CN9, CN10, CN11 }//スイッチプローブで逆検知

        public class CnSpec
        {
            public NAME name;
            public bool result;
        }

        public static List<CnSpec> ListCnSpecs;

        private static void InitList()
        {
            ListCnSpecs = new List<CnSpec>();
            foreach (var n in Enum.GetValues(typeof(NAME)))
            {
                ListCnSpecs.Add(new CnSpec { name = (NAME)n });
            }
        }

        public static async Task<bool> CheckCn()
        {
            var result = false;
            try
            {
                return result = await Task<bool>.Run(() =>
                {
                    InitList();
                    ListCnSpecs.ForEach(l =>
                    {
                        switch (l.name)
                        {
                            case NAME.CN1:
                                General.ReadGeneralInput(General.INPUT_NAME.CN1);
                                break;
                            case NAME.CN2:
                                General.ReadGeneralInput(General.INPUT_NAME.CN2);
                                break;
                            case NAME.CN3:
                                General.ReadGeneralInput(General.INPUT_NAME.CN3);
                                break;
                            case NAME.CN4:
                                General.ReadGeneralInput(General.INPUT_NAME.CN4);
                                break;
                            case NAME.CN5:
                                General.ReadGeneralInput(General.INPUT_NAME.CN5);
                                break;
                            case NAME.CN6:
                                General.ReadGeneralInput(General.INPUT_NAME.CN6);
                                break;
                            case NAME.CN7:
                                General.ReadGeneralInput(General.INPUT_NAME.CN7);
                                break;
                            case NAME.CN8:
                                General.ReadGeneralInput(General.INPUT_NAME.CN8);
                                break;
                            case NAME.CN9:
                                General.ReadGeneralInput(General.INPUT_NAME.CN9);
                                break;
                            case NAME.CN10://未実装であることの確認
                                General.ReadGeneralInput(General.INPUT_NAME.CN10);
                                break;
                            case NAME.CN11:
                                General.ReadGeneralInput(General.INPUT_NAME.CN11);
                                break;
                        }
                        //正常に実装されていればスイッチプローブがOnするので"L"が返ってきます
                        if (LPC1768.SendData("R,P27"))
                            l.result = LPC1768.RecieveData == (l.name == NAME.CN10 ? "H" : "L");
                        else
                            l.result = false;
                    });

                    return ListCnSpecs.All(l => l.result);
                });
            }
            finally
            {
                if (!result)
                {
                    State.uriOtherInfoPage = new Uri("Page/ErrInfo/ErrInfoTestConnector.xaml", UriKind.Relative);
                    State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Visible;
                }
            }
        }

    }
}
