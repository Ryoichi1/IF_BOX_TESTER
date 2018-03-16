using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using static System.Threading.Thread;
using static IfBoxTester.General;

namespace IfBoxTester
{
    public static class TestSoldering
    {
        public enum NAME { CN3, CN11_1, CN11_2, CN2_13, }
        
        public class SolderingSpec
        {
            public NAME name;
            public bool result;
        }

        public static List<SolderingSpec> ListSpecs;

        private static void InitList()
        {
            ListSpecs = new List<SolderingSpec>();
            foreach (var n in Enum.GetValues(typeof(NAME)))
            {
                ListSpecs.Add(new SolderingSpec { name = (NAME)n });
            }
        }


        public static async Task<bool> CheckSoldering()
        {
            var result = false;

            try
            {
                return result = await Task<bool>.Run(() =>
                {

                    InitList();
                    ListSpecs.ForEach(l =>
                    {
                        switch (l.name)
                        {
                            case NAME.CN3:
                                l.result = ReadGeneralInput(General.INPUT_NAME.CN3OUT);
                                break;
                            case NAME.CN11_1:
                                DriveRY11(true);//事前に製品のRY11をONさせる
                                Sleep(400);
                                l.result = ReadGeneralInput(General.INPUT_NAME.CN11_1);
                                DriveRY11(false);//確認後、製品のRY11をOFFさせる
                                break;
                            case NAME.CN11_2:
                                l.result = ReadGeneralInput(General.INPUT_NAME.CN11_2);
                                break;
                            case NAME.CN2_13:
                                l.result = ReadGeneralInput(General.INPUT_NAME.CN2_13);
                                break;
                        }

                    });
                    return ListSpecs.All(l => l.result);

                });
            }
            catch
            {
                Flags.ThrowException = true;
                return result = false;
            }
            finally
            {
                if (!result)
                {
                    //TODO: 
                    State.uriOtherInfoPage = new Uri("Page/ErrInfo/ErrInfoTestSoldering.xaml", UriKind.Relative);
                    State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Visible;
                }
            }
        }


    }
}
