using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;
using static System.Threading.Thread;

namespace IfBoxTester
{


    public static class General
    {

        //インスタンス変数の宣言
        public static SoundPlayer player = null;
        public static SoundPlayer soundPass = null;
        public static SoundPlayer soundPassLong = null;
        public static SoundPlayer soundFail = null;
        public static SoundPlayer soundAlarm = null;
        public static SoundPlayer soundSuccess = null;
        public static SoundPlayer soundNotice = null;
        public static SoundPlayer soundCutin = null;


        public static SolidColorBrush DialogOnBrush = new SolidColorBrush();
        public static SolidColorBrush OnBrush = new SolidColorBrush();
        public static SolidColorBrush OffBrush = new SolidColorBrush();
        public static SolidColorBrush NgBrush = new SolidColorBrush();


        static General()
        {
            //オーディオリソースを取り出す
            General.soundPass = new SoundPlayer(@"Resources\Wav\Pass.wav");
            General.soundPassLong = new SoundPlayer(@"Resources\Wav\VictoryLong.wav");
            General.soundFail = new SoundPlayer(@"Resources\Wav\Fail.wav");
            General.soundAlarm = new SoundPlayer(@"Resources\Wav\Alarm.wav");
            General.soundSuccess = new SoundPlayer(@"Resources\Wav\Success.wav");
            General.soundNotice = new SoundPlayer(@"Resources\Wav\Notice.wav");
            General.soundCutin = new SoundPlayer(@"Resources\Wav\CutIn.wav");

            //カラーテンプレートいろいろ
            OffBrush.Color = Colors.Transparent;

            DialogOnBrush.Color = Colors.DodgerBlue;
            DialogOnBrush.Opacity = 0.6;

            OnBrush.Color = Colors.DodgerBlue;
            OnBrush.Opacity = 0.4;

            NgBrush.Color = Colors.HotPink;
            NgBrush.Opacity = 0.4;
        }

        public static void Show()
        {
            var T = 0.3;
            var t = 0.005;

            State.Setting.OpacityTheme = State.VmMainWindow.ThemeOpacity;
            //10msec刻みでT秒で元のOpacityに戻す
            int times = (int)(T / t);

            State.VmMainWindow.ThemeOpacity = 0;
            Task.Run(() =>
            {
                while (true)
                {

                    State.VmMainWindow.ThemeOpacity += State.Setting.OpacityTheme / (double)times;
                    Thread.Sleep((int)(t * 1000));
                    if (State.VmMainWindow.ThemeOpacity >= State.Setting.OpacityTheme) return;

                }
            });
        }

        public static void SetRadius(bool sw)
        {
            var T = 0.45;//アニメーションが完了するまでの時間（秒）
            var t = 0.005;//（秒）

            //5msec刻みでT秒で元のOpacityに戻す
            int times = (int)(T / t);


            Task.Run(() =>
            {
                if (sw)
                {
                    while (true)
                    {
                        State.VmMainWindow.ThemeBlurEffectRadius += 25 / (double)times;
                        Thread.Sleep((int)(t * 1000));
                        if (State.VmMainWindow.ThemeBlurEffectRadius >= 25) return;

                    }
                }
                else
                {
                    var CurrentRadius = State.VmMainWindow.ThemeBlurEffectRadius;
                    while (true)
                    {
                        CurrentRadius -= 25 / (double)times;
                        if (CurrentRadius > 0)
                        {
                            State.VmMainWindow.ThemeBlurEffectRadius = CurrentRadius;
                        }
                        else
                        {
                            State.VmMainWindow.ThemeBlurEffectRadius = 0;
                            return;
                        }
                        Thread.Sleep((int)(t * 1000));
                    }
                }

            });
        }


        private static List<string> MakePassTestData()//TODO:
        {
            var ListData = new List<string>
            {
                "AssemblyVer " + State.AssemblyInfo,
                "TestSpecVer " + State.TestSpec.TestSpecVer,
                System.DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH:mm:ss"),
                State.VmMainWindow.Operator,
                //TODO:
                //保存するデータを追加する


            };

            return ListData;
        }

        public static bool SaveTestData()
        {
            try
            {
                var dataList = new List<string>();
                dataList = MakePassTestData();

                var OkDataFilePath = Constants.PassDataFolderPath + State.VmMainWindow.Opecode + ".csv";

                if (!System.IO.File.Exists(OkDataFilePath))
                {
                    //既存検査データがなければ新規作成
                    File.Copy(Constants.PassDataFolderPath + "Format.csv", OkDataFilePath);
                }

                // リストデータをすべてカンマ区切りで連結する
                string stCsvData = string.Join(",", dataList);

                // appendをtrueにすると，既存のファイルに追記
                // falseにすると，ファイルを新規作成する
                var append = true;

                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(OkDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.WriteLine(stCsvData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        //**************************************************************************
        //検査データの保存　　　　
        //引数：なし
        //戻値：なし
        //**************************************************************************

        public static bool SaveNgData(List<string> dataList)
        {
            try
            {
                var NgDataFilePath = Constants.FailDataFolderPath + State.VmMainWindow.Opecode + ".csv";
                if (!File.Exists(NgDataFilePath))
                {
                    //既存検査データがなければ新規作成
                    File.Copy(Constants.FailDataFolderPath + "FormatNg.csv", NgDataFilePath);
                }

                var stArrayData = dataList.ToArray();
                // リストデータをすべてカンマ区切りで連結する
                string stCsvData = string.Join(",", stArrayData);

                // appendをtrueにすると，既存のファイルに追記
                //         falseにすると，ファイルを新規作成する
                var append = true;

                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(NgDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.WriteLine(stCsvData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///レバーが下がっていればTrueを返す 
        /// </summary>
        /// <returns></returns>
        public static bool CheckPress()//レバーが下がっていればTrueを返す
        {
            LPC1768.SendData("R,P28", setLog: false);
            return LPC1768.RecieveData == "L";
        }

        /// <summary>
        ///すべての出力ポートをLにする 
        /// </summary>
        /// <returns></returns>
        public static void ResetIo() //P7:0 P6:0 P5:1 P4:1  P3:1 P2:1 P1:1 P0:1  
        {
            //IOを初期化する処理（出力をすべてＬに落とす）
            LPC1768.SendData("ResetIo");
            Flags.PowOn = false;
        }

        public static void PowSupply(bool sw)
        {
            if (Flags.PowOn == sw) return;
            SetK1(sw);
            Flags.PowOn = sw;
        }


        //**************************************************************************
        //WAVEファイルを再生する
        //引数：なし
        //戻値：なし
        //**************************************************************************  

        //WAVEファイルを再生する（非同期で再生）
        public static void PlaySound(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.Play();
        }
        //WAVEファイルを再生する（同期で再生）
        public static void PlaySound2(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.PlaySync();

        }

        public static void PlaySoundLoop(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.PlayLooping();
        }

        //再生されているWAVEファイルを止める
        public static void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }



        public static void ResetViewModel()//TODO:
        {
            //ViewModel OK台数、NG台数、Total台数の更新
            State.VmTestStatus.OkCount = State.Setting.TodayOkCount.ToString() + "台";
            State.VmTestStatus.NgCount = State.Setting.TodayNgCount.ToString() + "台";
            State.VmTestStatus.Message = Constants.MessSet;
            State.VmMainWindow.FlyoutSrc = Constants.PathJp1_23Short;
            State.VmMainWindow.Flyout = true;


            State.VmTestStatus.DecisionVisibility = System.Windows.Visibility.Hidden;
            State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Hidden;
            State.VmTestStatus.RingVisibility = System.Windows.Visibility.Visible;

            State.VmTestStatus.VisTestSettingInfo = System.Windows.Visibility.Visible;

            State.VmTestStatus.TestTime = "00:00";
            State.VmTestStatus.進捗度 = 0;
            State.VmTestStatus.TestLog = "";

            State.VmTestStatus.FailInfo = "";
            State.VmTestStatus.Spec = "";
            State.VmTestStatus.MeasValue = "";


            //試験結果のクリア
            State.VmTestResults = new ViewModelTestResult();

            //通信ログのクリア
            //TODO:
            State.VmComm.TX = "";
            State.VmComm.RX = "";

            //他ページへの遷移を許可する
            State.VmMainWindow.EnableOtherButton = true;

            //各種フラグの初期化
            Flags.PowOn = false;
            Flags.ClickStopButton = false;
            Flags.Testing = false;


            //テーマ透過度を元に戻す
            General.SetRadius(false);

            State.VmTestStatus.RetryLabelVis = System.Windows.Visibility.Hidden;
            State.VmTestStatus.TestSettingEnable = true;
            State.VmMainWindow.OperatorEnable = true;

            //コネクタチェックでエラーになると表示されたままになるので隠す（誤動作防止！！！）
            State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Hidden;
        }


        public static void CheckAll周辺機器フラグ()
        {
            Flags.AllOk周辺機器接続 = Flags.State1768;
        }


        public static void Init周辺機器()//TODO:
        {
            Flags.Initializing周辺機器 = true;

            //LPC1768の初期化
            bool Stop1768 = false;
            Task.Run(() =>
            {
                while (true)
                {
                    if (Flags.StopInit周辺機器)
                    {
                        break;
                    }

                    Flags.State1768 = LPC1768.Init();
                    if (Flags.State1768)
                    {
                        //IOボードのリセット（出力をすべてLする）
                        ResetIo();
                        break;
                    }

                    Thread.Sleep(500);
                }
                Stop1768 = true;
            });

            Task.Run(() =>
            {
                while (true)
                {
                    CheckAll周辺機器フラグ();

                    //EPX64Sの初期化の中で、K100、K101の溶着チェックを行っているが、これがNGだとしてもInit周辺機器()は終了する
                    var IsAllStopped = Stop1768;

                    if (Flags.AllOk周辺機器接続 || IsAllStopped) break;
                    Thread.Sleep(400);

                }
                Flags.Initializing周辺機器 = false;
            });

        }

        //強制停止ボタンの設定
        public static async Task ShowStopButton(bool sw)
        {
            if (sw)
            {
                State.VmTestStatus.StopButtonEnable = true;
                await Task.Run(() =>
                {
                    foreach (var i in Enumerable.Range(1, 100))
                    {
                        State.VmTestStatus.StopButtonVis = i / 100.0;
                        Thread.Sleep(10);
                    }
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    foreach (var i in Enumerable.Range(1, 100))
                    {
                        State.VmTestStatus.StopButtonVis = (1 - (i / 100.0));
                        Thread.Sleep(10);
                    }
                });
                State.VmTestStatus.StopButtonEnable = false;
            }

        }

        public enum INPUT_NAME
        {
            /*MP1*/
            CN1, CN2, CN3, CN4, CN5, CN6, CN7, CN8,
            /*MP2*/
            CN9, CN10, CN11, CN2_1, CN2_13, CN11_1, CN11_2, CN3OUT,
            /*MP3*/
            CN4_3, CN4_5, CN4_7, CN4_9, CN4_11, CN5_1, CN5_3, CN6_3,
            /*MP4*/
            CN6_5, CN6_7, CN8_1, CN9_1, CN9_2, CN9_3, CN9_4, CN10_1,
            /*MP5*/
            CN10_2, CN10_3, CN10_4, CN10_5, CN10_6, CN10_7,
        }

        /// <summary>
        /// LPC1768への入力がLならtrueを返します
        /// </summary>
        public static bool ReadGeneralInput(INPUT_NAME name)
        {
            //すべての入力を切り離す処理
            LPC1768.SendData("W,P21,1");
            LPC1768.SendData("W,P22,1");
            LPC1768.SendData("W,P23,1");
            LPC1768.SendData("W,P24,1");
            LPC1768.SendData("W,P25,1");
            Sleep(5);

            switch (name)
            {
                case INPUT_NAME.CN1:
                case INPUT_NAME.CN9:
                case INPUT_NAME.CN4_3:
                case INPUT_NAME.CN6_5:
                case INPUT_NAME.CN10_2:
                    LPC1768.SendData("W,P18,0");//A
                    LPC1768.SendData("W,P19,0");//B
                    LPC1768.SendData("W,P20,0");//C
                    break;

                case INPUT_NAME.CN2:
                case INPUT_NAME.CN10:
                case INPUT_NAME.CN4_5:
                case INPUT_NAME.CN6_7:
                case INPUT_NAME.CN10_3:
                    LPC1768.SendData("W,P18,1");//A
                    LPC1768.SendData("W,P19,0");//B
                    LPC1768.SendData("W,P20,0");//C
                    break;

                case INPUT_NAME.CN3:
                case INPUT_NAME.CN11:
                case INPUT_NAME.CN4_7:
                case INPUT_NAME.CN8_1:
                case INPUT_NAME.CN10_4:
                    LPC1768.SendData("W,P18,0");//A
                    LPC1768.SendData("W,P19,1");//B
                    LPC1768.SendData("W,P20,0");//C
                    break;

                case INPUT_NAME.CN4:
                case INPUT_NAME.CN2_1:
                case INPUT_NAME.CN4_9:
                case INPUT_NAME.CN9_1:
                case INPUT_NAME.CN10_5:
                    LPC1768.SendData("W,P18,1");//A
                    LPC1768.SendData("W,P19,1");//B
                    LPC1768.SendData("W,P20,0");//C
                    break;

                case INPUT_NAME.CN5:
                case INPUT_NAME.CN2_13:
                case INPUT_NAME.CN4_11:
                case INPUT_NAME.CN9_2:
                case INPUT_NAME.CN10_6:
                    LPC1768.SendData("W,P18,0");//A
                    LPC1768.SendData("W,P19,0");//B
                    LPC1768.SendData("W,P20,1");//C
                    break;

                case INPUT_NAME.CN6:
                case INPUT_NAME.CN11_1:
                case INPUT_NAME.CN5_1:
                case INPUT_NAME.CN9_3:
                case INPUT_NAME.CN10_7:
                    LPC1768.SendData("W,P18,1");//A
                    LPC1768.SendData("W,P19,0");//B
                    LPC1768.SendData("W,P20,1");//C
                    break;

                case INPUT_NAME.CN7:
                case INPUT_NAME.CN11_2:
                case INPUT_NAME.CN5_3:
                case INPUT_NAME.CN9_4:
                    LPC1768.SendData("W,P18,0");//A
                    LPC1768.SendData("W,P19,1");//B
                    LPC1768.SendData("W,P20,1");//C
                    break;

                case INPUT_NAME.CN8:
                case INPUT_NAME.CN3OUT:
                case INPUT_NAME.CN6_3:
                case INPUT_NAME.CN10_1:
                    LPC1768.SendData("W,P18,1");//A
                    LPC1768.SendData("W,P19,1");//B
                    LPC1768.SendData("W,P20,1");//C
                    break;
            }
            Sleep(5);

            switch (name)
            {
                case INPUT_NAME.CN1:
                case INPUT_NAME.CN2:
                case INPUT_NAME.CN3:
                case INPUT_NAME.CN4:
                case INPUT_NAME.CN5:
                case INPUT_NAME.CN6:
                case INPUT_NAME.CN7:
                case INPUT_NAME.CN8:
                    LPC1768.SendData("W,P21,0");
                    break;

                case INPUT_NAME.CN9:
                case INPUT_NAME.CN10:
                case INPUT_NAME.CN11:
                case INPUT_NAME.CN2_1:
                case INPUT_NAME.CN2_13:
                case INPUT_NAME.CN11_1:
                case INPUT_NAME.CN11_2:
                case INPUT_NAME.CN3OUT:
                    LPC1768.SendData("W,P22,0");
                    break;

                case INPUT_NAME.CN4_3:
                case INPUT_NAME.CN4_5:
                case INPUT_NAME.CN4_7:
                case INPUT_NAME.CN4_9:
                case INPUT_NAME.CN4_11:
                case INPUT_NAME.CN5_1:
                case INPUT_NAME.CN5_3:
                case INPUT_NAME.CN6_3:
                    LPC1768.SendData("W,P23,0");
                    break;

                case INPUT_NAME.CN6_5:
                case INPUT_NAME.CN6_7:
                case INPUT_NAME.CN8_1:
                case INPUT_NAME.CN9_1:
                case INPUT_NAME.CN9_2:
                case INPUT_NAME.CN9_3:
                case INPUT_NAME.CN9_4:
                case INPUT_NAME.CN10_1:
                    LPC1768.SendData("W,P24,0");
                    break;

                case INPUT_NAME.CN10_2:
                case INPUT_NAME.CN10_3:
                case INPUT_NAME.CN10_4:
                case INPUT_NAME.CN10_5:
                case INPUT_NAME.CN10_6:
                case INPUT_NAME.CN10_7:
                    LPC1768.SendData("W,P25,0");
                    break;
            }
            Sleep(5);

            LPC1768.SendData("R,P27");
            return LPC1768.RecieveData == "L";
        }

        public static bool ReadV1State()
        {
            LPC1768.SendData("R,P29");
            return LPC1768.RecieveData == "L";
        }

        public static bool ReadV2State()
        {
            LPC1768.SendData("R,P30");
            return LPC1768.RecieveData == "L";
        }



        //試験機のリレー制御
        private static bool SetK1(bool sw)   { return LPC1768.SendData("W,P05," + (sw ? "1" : "0")); }
        private static bool SetK2(bool sw)   { return LPC1768.SendData("W,P06," + (sw ? "1" : "0")); }
        private static bool SetK3(bool sw)   { return LPC1768.SendData("W,P07," + (sw ? "1" : "0")); }
        private static bool SetK4_5(bool sw) { return LPC1768.SendData("W,P08," + (sw ? "1" : "0")); }//CN10を実装するアイテムが追加されたときに使用する
        private static bool SetRL1(bool sw)  { return LPC1768.SendData("W,P09," + (sw ? "1" : "0")); }
        private static bool SetRL2(bool sw)  { return LPC1768.SendData("W,P10," + (sw ? "1" : "0")); }
        private static bool SetRL3(bool sw)  { return LPC1768.SendData("W,P11," + (sw ? "1" : "0")); }
        private static bool SetRL4(bool sw)  { return LPC1768.SendData("W,P12," + (sw ? "1" : "0")); }
        private static bool SetRL5(bool sw)  { return LPC1768.SendData("W,P13," + (sw ? "1" : "0")); }
        private static bool SetRL6(bool sw)  { return LPC1768.SendData("W,P14," + (sw ? "1" : "0")); }
        private static bool SetRL7(bool sw)  { return LPC1768.SendData("W,P15," + (sw ? "1" : "0")); }
        private static bool SetRL8(bool sw)  { return LPC1768.SendData("W,P16," + (sw ? "1" : "0")); }
        public static async Task<bool> StampOn() { return await Task<bool>.Run(() => LPC1768.SendData("STAMP")); }

        //製品のリレー制御（上記試験機リレー制御をラップする）
        public static bool DriveRY1A(bool sw) { return SetK2(sw); }
        public static bool DriveRY8(bool sw)  { return SetK3(sw); }
        public static bool DriveRY11(bool sw) { return SetRL8(sw); }
        public static bool DriveRY1B(bool sw) { return SetRL7(sw); }
        public static bool DriveRY2(bool sw) { return SetRL1(sw); }
        public static bool DriveRY3(bool sw) { return SetRL2(sw); }
        public static bool DriveRY4(bool sw) { return SetRL3(sw); }
        public static bool DriveRY6(bool sw) { return SetRL4(sw); }
        public static bool DriveRY5(bool sw) { return SetRL5(sw); }
        public static bool DriveRY9(bool sw) { return SetRL6(sw); }




    }

}

