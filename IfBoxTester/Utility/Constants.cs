
namespace IfBoxTester
{
    public static class Constants
    {
        //スタートボタンの表示
        public const string 開始 = "検査開始";
        public const string 停止 = "強制停止";
        public const string 確認 = "確認";

        //作業者へのメッセージ
        public const string MessOpecode = "工番を入力してください";
        public const string MessOperator = "作業者名を選択してください";
        public const string MessSet = "製品をセットしてレバーを下げてください ※JP1 2-3短絡すること！";
        public const string MessRemove = "製品を取り外してください";

        public const string PathJp1_12Short = "/IfBoxTester;component/Resources/Pic/JP1-2.jpg";
        public const string PathJp1_23Short = "/IfBoxTester;component/Resources/Pic/JP2-3.jpg";

        public const string MessWait = "検査中！　しばらくお待ちください・・・";
        public const string MessCheckConnectMachine = "周辺機器の接続を確認してください！";

        public static readonly string filePath_TestSpec        = @"C:\IfBoxTester\ConfigData\TestSpec.config";
        public static readonly string filePath_Configuration   = @"C:\IfBoxTester\ConfigData\Configuration.config";
        public static readonly string filePath_Command         = @"C:\IfBoxTester\ConfigData\Command.config";

        public static readonly string Path_Manual = @"C:\IfBoxTester\04120-68090-330.pdf";

        //検査データフォルダのパス
        public static readonly string PassDataFolderPath = @"C:\IfBoxTester\検査データ\合格品データ\";
        public static readonly string FailDataFolderPath = @"C:\IfBoxTester\検査データ\不良品データ\";

        //Imageの透明度
        public const double OpacityImgMin = 0.0;

        //リトライ回数
        public static readonly int RetryCount = 0;












    }
}
