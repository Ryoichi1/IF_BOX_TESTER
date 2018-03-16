using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Threading.Thread;
using static IfBoxTester.General;

namespace IfBoxTester
{
    public static class TestIO
    {
        public const bool _1 = true;
        public const bool _0 = false;

        public enum TEST_CASE
        {
            RY1A,
            RY1B,
            RY2A_D,
            RY3A_C,
            RY4A_C,
            RY5,
            RY7,
            RY11,
            RY6_8,
            RY2_3_4_9,
            RY3_4,
            RY1B_2,
        }

        public static List<PortSpec> ListSpecs;

        public class PortSpec
        {
            public TEST_CASE name;
            public (bool exp, bool Out) Cn2_1;
            public (bool exp, bool Out) Cn4_3;
            public (bool exp, bool Out) Cn4_5;
            public (bool exp, bool Out) Cn4_7;
            public (bool exp, bool Out) Cn4_9;
            public (bool exp, bool Out) Cn4_11;
            public (bool exp, bool Out) Cn5_1;
            public (bool exp, bool Out) Cn5_3;
            public (bool exp, bool Out) Cn6_3;
            public (bool exp, bool Out) Cn6_5;
            public (bool exp, bool Out) Cn6_7;
            public (bool exp, bool Out) Cn8_1;
            public (bool exp, bool Out) Cn9_1;
            public (bool exp, bool Out) Cn9_2;
            public (bool exp, bool Out) Cn9_3;
            public (bool exp, bool Out) Cn9_4;
            public (bool exp, bool Out) V1;
            public (bool exp, bool Out) V2;
            public bool TotalResult;
        }

        private static void ResetViewModelOut()
        {
            State.VmTestResults.ColCn2_1Exp = OffBrush;

            State.VmTestResults.ColCn4_3Exp = OffBrush;
            State.VmTestResults.ColCn4_5Exp = OffBrush;
            State.VmTestResults.ColCn4_7Exp = OffBrush;
            State.VmTestResults.ColCn4_9Exp = OffBrush;
            State.VmTestResults.ColCn4_11Exp = OffBrush;

            State.VmTestResults.ColCn5_1Exp = OffBrush;
            State.VmTestResults.ColCn5_3Exp = OffBrush;

            State.VmTestResults.ColCn6_3Exp = OffBrush;
            State.VmTestResults.ColCn6_5Exp = OffBrush;
            State.VmTestResults.ColCn6_7Exp = OffBrush;

            State.VmTestResults.ColCn8_1Exp = OffBrush;

            State.VmTestResults.ColCn9_1Exp = OffBrush;
            State.VmTestResults.ColCn9_2Exp = OffBrush;
            State.VmTestResults.ColCn9_3Exp = OffBrush;
            State.VmTestResults.ColCn9_4Exp = OffBrush;

            State.VmTestResults.ColV1Exp = OffBrush;
            State.VmTestResults.ColV2Exp = OffBrush;

            State.VmTestResults.ColCn2_1 = OffBrush;

            State.VmTestResults.ColCn4_3 = OffBrush;
            State.VmTestResults.ColCn4_5 = OffBrush;
            State.VmTestResults.ColCn4_7 = OffBrush;
            State.VmTestResults.ColCn4_9 = OffBrush;
            State.VmTestResults.ColCn4_11 = OffBrush;

            State.VmTestResults.ColCn5_1 = OffBrush;
            State.VmTestResults.ColCn5_3 = OffBrush;

            State.VmTestResults.ColCn6_3 = OffBrush;
            State.VmTestResults.ColCn6_5 = OffBrush;
            State.VmTestResults.ColCn6_7 = OffBrush;

            State.VmTestResults.ColCn8_1 = OffBrush;

            State.VmTestResults.ColCn9_1 = OffBrush;
            State.VmTestResults.ColCn9_2 = OffBrush;
            State.VmTestResults.ColCn9_3 = OffBrush;
            State.VmTestResults.ColCn9_4 = OffBrush;

            State.VmTestResults.ColV1 = OffBrush;
            State.VmTestResults.ColV2 = OffBrush;
        }

        private static void InitList()
        {
            ListSpecs = new List<PortSpec>();
            foreach (var n in Enum.GetValues(typeof(TEST_CASE)))
            {
                ListSpecs.Add(new PortSpec { name = (TEST_CASE)n });
            }
        }

        /// <summary>
        /// 引数true 5V出力  false: 0V出力
        /// </summary>
        /// <param name="sw"></param>
        private static bool SetOutput(TEST_CASE name, bool sw)
        {
            try
            {
                switch (name)
                {
                    case TEST_CASE.RY1A:
                        return DriveRY1A(sw);
                    case TEST_CASE.RY1B:
                        return DriveRY1B(sw);
                    case TEST_CASE.RY2A_D:
                        return DriveRY2(sw);
                    case TEST_CASE.RY3A_C:
                        return DriveRY3(sw);
                    case TEST_CASE.RY4A_C:
                        return DriveRY4(sw);
                    case TEST_CASE.RY5:
                        return DriveRY5(sw);
                    case TEST_CASE.RY7:
                        return DriveRY1A(sw) && DriveRY8(sw);
                    case TEST_CASE.RY11:
                        return DriveRY11(sw);
                    case TEST_CASE.RY6_8:
                        return DriveRY6(sw) && DriveRY8(sw);
                    case TEST_CASE.RY2_3_4_9:
                        return DriveRY2(sw) && DriveRY3(sw) && DriveRY4(sw) && DriveRY9(sw);
                    case TEST_CASE.RY3_4:
                        return DriveRY3(sw) && DriveRY4(sw);
                    case TEST_CASE.RY1B_2:
                        return DriveRY1B(sw) && DriveRY2(sw);
                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                Sleep(200);
            }
        }

        /// <summary>
        /// 引数onName：H出力を指定したポート名  expAllOff: すべての出力ポートがL指定のときtrueを渡す
        /// </summary>
        /// <param name="exp"></param>
        private static void FetchData(TEST_CASE onName, bool expAllOff = false)
        {
            //すべてのリレー出力を取り込む

            ListSpecs.Find(l => l.name == onName).Cn2_1.Out = (ReadGeneralInput(INPUT_NAME.CN2_1));
            ListSpecs.Find(l => l.name == onName).Cn4_3.Out = (ReadGeneralInput(INPUT_NAME.CN4_3));
            ListSpecs.Find(l => l.name == onName).Cn4_5.Out = (ReadGeneralInput(INPUT_NAME.CN4_5));
            ListSpecs.Find(l => l.name == onName).Cn4_7.Out = (ReadGeneralInput(INPUT_NAME.CN4_7));
            ListSpecs.Find(l => l.name == onName).Cn4_9.Out = (ReadGeneralInput(INPUT_NAME.CN4_9));
            ListSpecs.Find(l => l.name == onName).Cn4_11.Out = (ReadGeneralInput(INPUT_NAME.CN4_11));

            ListSpecs.Find(l => l.name == onName).Cn5_1.Out = (ReadGeneralInput(INPUT_NAME.CN5_1));
            ListSpecs.Find(l => l.name == onName).Cn5_3.Out = (ReadGeneralInput(INPUT_NAME.CN5_3));

            ListSpecs.Find(l => l.name == onName).Cn6_3.Out = (ReadGeneralInput(INPUT_NAME.CN6_3));
            ListSpecs.Find(l => l.name == onName).Cn6_5.Out = (ReadGeneralInput(INPUT_NAME.CN6_5));
            ListSpecs.Find(l => l.name == onName).Cn6_7.Out = (ReadGeneralInput(INPUT_NAME.CN6_7));

            ListSpecs.Find(l => l.name == onName).Cn8_1.Out = (ReadGeneralInput(INPUT_NAME.CN8_1));

            ListSpecs.Find(l => l.name == onName).Cn9_1.Out = (ReadGeneralInput(INPUT_NAME.CN9_1));
            ListSpecs.Find(l => l.name == onName).Cn9_2.Out = (ReadGeneralInput(INPUT_NAME.CN9_2));
            ListSpecs.Find(l => l.name == onName).Cn9_3.Out = (ReadGeneralInput(INPUT_NAME.CN9_3));
            ListSpecs.Find(l => l.name == onName).Cn9_4.Out = (ReadGeneralInput(INPUT_NAME.CN9_4));

            ListSpecs.Find(l => l.name == onName).V1.Out = (ReadV1State());
            ListSpecs.Find(l => l.name == onName).V2.Out = (ReadV2State());


            //期待値の設定
            if (expAllOff)
            {
                ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;//ここだけNC接点なので論理が逆
                ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;//ここだけNC接点なので論理が逆
                ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                ListSpecs.Find(l => l.name == onName).V2.exp = _0;
            }
            else
            {
                switch (onName)
                {
                    case TEST_CASE.RY1A:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY1B:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY2A_D:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY3A_C:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY4A_C:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY5:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY7:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _1;
                        break;
                    case TEST_CASE.RY11:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY6_8:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY2_3_4_9:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY3_4:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                    case TEST_CASE.RY1B_2:
                        ListSpecs.Find(l => l.name == onName).Cn2_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_7.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn4_9.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn4_11.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn5_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn5_3.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn6_5.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn6_7.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn8_1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_1.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_2.exp = _0;
                        ListSpecs.Find(l => l.name == onName).Cn9_3.exp = _1;
                        ListSpecs.Find(l => l.name == onName).Cn9_4.exp = _1;
                        ListSpecs.Find(l => l.name == onName).V1.exp = _0;
                        ListSpecs.Find(l => l.name == onName).V2.exp = _0;
                        break;
                }

            }


            //ビューモデルの更新
            //期待値の設定
            State.VmTestResults.ColCn2_1Exp = ListSpecs.Find(l => l.name == onName).Cn2_1.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_3Exp = ListSpecs.Find(l => l.name == onName).Cn4_3.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_5Exp = ListSpecs.Find(l => l.name == onName).Cn4_5.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_7Exp = ListSpecs.Find(l => l.name == onName).Cn4_7.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_9Exp = ListSpecs.Find(l => l.name == onName).Cn4_9.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_11Exp = ListSpecs.Find(l => l.name == onName).Cn4_11.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn5_1Exp = ListSpecs.Find(l => l.name == onName).Cn5_1.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn5_3Exp = ListSpecs.Find(l => l.name == onName).Cn5_3.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn6_3Exp = ListSpecs.Find(l => l.name == onName).Cn6_3.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn6_5Exp = ListSpecs.Find(l => l.name == onName).Cn6_5.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn6_7Exp = ListSpecs.Find(l => l.name == onName).Cn6_7.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn8_1Exp = ListSpecs.Find(l => l.name == onName).Cn8_1.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_1Exp = ListSpecs.Find(l => l.name == onName).Cn9_1.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_2Exp = ListSpecs.Find(l => l.name == onName).Cn9_2.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_3Exp = ListSpecs.Find(l => l.name == onName).Cn9_3.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_4Exp = ListSpecs.Find(l => l.name == onName).Cn9_4.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColV1Exp = ListSpecs.Find(l => l.name == onName).V1.exp ? OnBrush : OffBrush;
            State.VmTestResults.ColV2Exp = ListSpecs.Find(l => l.name == onName).V2.exp ? OnBrush : OffBrush;


            //取り込み値の設定
            State.VmTestResults.ColCn2_1 = ListSpecs.Find(l => l.name == onName).Cn2_1.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_3 = ListSpecs.Find(l => l.name == onName).Cn4_3.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_5 = ListSpecs.Find(l => l.name == onName).Cn4_5.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_7 = ListSpecs.Find(l => l.name == onName).Cn4_7.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_9 = ListSpecs.Find(l => l.name == onName).Cn4_9.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn4_11 = ListSpecs.Find(l => l.name == onName).Cn4_11.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn5_1 = ListSpecs.Find(l => l.name == onName).Cn5_1.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn5_3 = ListSpecs.Find(l => l.name == onName).Cn5_3.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn6_3 = ListSpecs.Find(l => l.name == onName).Cn6_3.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn6_5 = ListSpecs.Find(l => l.name == onName).Cn6_5.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn6_7 = ListSpecs.Find(l => l.name == onName).Cn6_7.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn8_1 = ListSpecs.Find(l => l.name == onName).Cn8_1.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_1 = ListSpecs.Find(l => l.name == onName).Cn9_1.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_2 = ListSpecs.Find(l => l.name == onName).Cn9_2.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_3 = ListSpecs.Find(l => l.name == onName).Cn9_3.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColCn9_4 = ListSpecs.Find(l => l.name == onName).Cn9_4.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColV1 = ListSpecs.Find(l => l.name == onName).V1.Out ? OnBrush : OffBrush;
            State.VmTestResults.ColV2 = ListSpecs.Find(l => l.name == onName).V2.Out ? OnBrush : OffBrush;

        }

        private static bool AnalysisData(TEST_CASE onName)
        {
            //すべてのリレー出力を取り込む

            var Lists = ListSpecs.Find(l => l.name == onName);
            if (Lists.Cn2_1.exp != Lists.Cn2_1.Out) return false;
            if (Lists.Cn4_3.exp != Lists.Cn4_3.Out) return false;
            if (Lists.Cn4_5.exp != Lists.Cn4_5.Out) return false;
            if (Lists.Cn4_7.exp != Lists.Cn4_7.Out) return false;
            if (Lists.Cn4_9.exp != Lists.Cn4_9.Out) return false;
            if (Lists.Cn4_11.exp != Lists.Cn4_11.Out) return false;
            if (Lists.Cn5_1.exp != Lists.Cn5_1.Out) return false;
            if (Lists.Cn5_3.exp != Lists.Cn5_3.Out) return false;
            if (Lists.Cn6_3.exp != Lists.Cn6_3.Out) return false;
            if (Lists.Cn6_5.exp != Lists.Cn6_5.Out) return false;
            if (Lists.Cn6_7.exp != Lists.Cn6_7.Out) return false;
            if (Lists.Cn8_1.exp != Lists.Cn8_1.Out) return false;
            if (Lists.Cn9_1.exp != Lists.Cn9_1.Out) return false;
            if (Lists.Cn9_2.exp != Lists.Cn9_2.Out) return false;
            if (Lists.Cn9_3.exp != Lists.Cn9_3.Out) return false;
            if (Lists.Cn9_4.exp != Lists.Cn9_4.Out) return false;
            if (Lists.V1.exp != Lists.V1.Out) return false;
            if (Lists.V2.exp != Lists.V2.Out) return false;
            return Lists.TotalResult = true;
        }

        public static async Task<bool> CheckIo()
        {
            var result = false;

            try
            {
                return result = await Task<bool>.Run(() =>
                {
                    bool resultOn = false;

                    InitList();//テストスペック毎回初期化
                    Flags.AddDecision = false;

                    try
                    {
                        ResetViewModelOut();

                        return ListSpecs.All(L =>
                        {
                            resultOn = false;

                            if (Flags.ClickStopButton) return false;

                            //テストログの更新
                            State.VmTestStatus.TestLog += "\r\n" + L.name.ToString() + " ONチェック";

                            //ONチェック
                            SetOutput(L.name, true);
                            FetchData(L.name);

                            resultOn = AnalysisData(L.name);


                            if (L.name == TEST_CASE.RY7)
                            {
                                DriveRY1A(false);
                                Sleep(2000);//RY10OFFまでに少し時間がかかる
                                DriveRY8(false);
                            }
                            else
                            {
                                //ONしたリレーをOFFする
                                SetOutput(L.name, false);
                            }


                            if (resultOn)
                            {
                                //テストログの更新
                                State.VmTestStatus.TestLog += "---PASS";
                                return true;
                            }
                            else
                            {
                                //テストログの更新
                                State.VmTestStatus.TestLog += "---FAIL";
                                return false;
                            }

                        });

                    }
                    catch
                    {
                        return false;
                    }
                });

            }
            finally
            {
                State.VmTestStatus.TestLog += "\r\n";
                ResetIo();

                if (!result)
                {
                    //TODO: 
                    State.uriOtherInfoPage = new Uri("Page/ErrInfo/ErrInfoTestIo.xaml", UriKind.Relative);
                    State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Visible;
                }
            }

        }





    }
}
