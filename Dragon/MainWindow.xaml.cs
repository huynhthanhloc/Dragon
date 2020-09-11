using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dragon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region data
        Bitmap Q1_1;
        Bitmap Q1_2;
        Bitmap Q1_3;
        Bitmap Q1_4;
        Bitmap Q1_5;
        Bitmap Q1_6;
        Bitmap Q1_7;
        Bitmap Q1_8;
        Bitmap Q1_9;
        Bitmap Q1_10;
        Bitmap Q1_10_1;
        Bitmap Q1_10_2;
        Bitmap Q1_10_3;
        Bitmap Q1_11;
        Bitmap Q1_12;
        Bitmap Q1_13;
        Bitmap Q1_14;
        Bitmap Q1_15;
        Bitmap Q1_16;
        Bitmap Q1_17;
        Bitmap Q1_18;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            Q1_1 = (Bitmap)Bitmap.FromFile("Data//question1_1.png");
            Q1_2 = (Bitmap)Bitmap.FromFile("Data//question1_2.png");
            Q1_3 = (Bitmap)Bitmap.FromFile("Data//question1_3.png");
            Q1_4 = (Bitmap)Bitmap.FromFile("Data//question1_4.png");
            Q1_5 = (Bitmap)Bitmap.FromFile("Data//question1_5.png");
            Q1_6 = (Bitmap)Bitmap.FromFile("Data//question1_6.png");
            Q1_7 = (Bitmap)Bitmap.FromFile("Data//question1_7.png");
            Q1_8 = (Bitmap)Bitmap.FromFile("Data//question1_8.png");
            Q1_9 = (Bitmap)Bitmap.FromFile("Data//question1_9.png");
            Q1_10 = (Bitmap)Bitmap.FromFile("Data//question1_10.png");
            Q1_10_1 = (Bitmap)Bitmap.FromFile("Data//question1_10_1.png");
            Q1_10_2 = (Bitmap)Bitmap.FromFile("Data//question1_10_2.png");
            Q1_10_3 = (Bitmap)Bitmap.FromFile("Data//question1_10_3.png");
            Q1_11 = (Bitmap)Bitmap.FromFile("Data//question1_11.png");
            Q1_12 = (Bitmap)Bitmap.FromFile("Data//question1_12.png");
            Q1_13 = (Bitmap)Bitmap.FromFile("Data//question1_13.png");
            Q1_14 = (Bitmap)Bitmap.FromFile("Data//question1_14.png");
            Q1_15 = (Bitmap)Bitmap.FromFile("Data//question1_15.png");
            Q1_16 = (Bitmap)Bitmap.FromFile("Data//question1_16.png");
            Q1_17 = (Bitmap)Bitmap.FromFile("Data//question1_17.png");
            Q1_18 = (Bitmap)Bitmap.FromFile("Data//question1_18.png");
            Logger("LoadData ---------------------------------------");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() =>
            {
                isStop = false;
                Auto();
            });
            t.Start();
        }

        bool isStop = false;

        void Logger(string log)
        {
            Console.WriteLine(log);
        }


        void Auto()
        {
            //Lấy ra danh sách thiết bị
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            //Chạy từng devices
            foreach (var deviceID in devices)
            {
                // tạo ra một luồng xử lý riêng
                Task t = new Task(() =>
                {
                    if (isStop)
                        return;
                    Logger("Start Q1_1");
                    
                    // go_now - question 1_1
                    var question1_1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_1);
                    // tìm thấy hình click vào hình
                    if (question1_1 != null)
                    {
                        Logger("Found Q1_1");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_1.Value.X, question1_1.Value.Y);
                        Logger("Sleep 50s Q1_1");
                        Delay(55);
                        Logger("Done Sleep 50s Q1_1");
                    }
                    if (isStop)
                        return;
                    //Handle Q1_2
                    //question 1-2 (Frost Dragon Claw)
                    Logger("Start Q1_2");
                    var question1_2 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_2);
                    // tìm thấy hình click vào hình
                    if (question1_2 != null)
                    {
                        Logger("Found Q1_2");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_2.Value.X, question1_2.Value.Y);
                        Delay(5);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 90.8, 91.5);
                        Delay(15);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96.4, 2.9);
                        Delay(5);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 71.0, 64.2);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                    }
                    if (isStop)
                        return;
                    
                    //Handle Q1_3
                    Logger("Check Q1_3");
                    StartQuest1_3:
                    var check_question1_3 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_3);
                    // wait for new quest1_3
                    if(check_question1_3 == null) // Q1_3 not found
                    {
                        Logger("Not found Q1_3");
                        // sleep time...
                        Delay(2);
                        if (isStop)
                            return;
                        goto StartQuest1_3;
                    }
                    if (isStop)
                        return;
                    // question1_3 (Got it)
                    Logger("Start Q1_3");
                    var question1_3 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_3);
                    if (question1_3 != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_3.Value.X, question1_3.Value.Y);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(10);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_3");
                    //Handle Q1_4
                    Logger("Check Q1_4");
                    StartQuest1_4:
                    var check_question1_4 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_4);
                    // wait for new quest1_4
                    if (check_question1_4 == null) // Q1_4 not found
                    {
                        Logger("Found Check Q1_4");
                        // sleep time...
                        Delay(2);
                        if (isStop)
                            return;
                        goto StartQuest1_4;
                    }
                    if (isStop)
                        return;
                    //question1_4	(skill)
                    Logger("Start Q1_4");
                    var question1_4 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_4);
                    // tìm thấy hình click vào hình
                    if (question1_4 != null)
                    {
                        Logger("Found Q1_4");
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 90.4, 92.2);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.9, 85.5);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_4");
                    
                    //Handle Q1_5
                    Logger("Check Q1_5");
                     StartQuest1_5:
                    var check_question1_5 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_5);
                    // wait for new quest1_5
                    if (check_question1_5 == null) // Q1_5 not found
                    {
                        Logger("Found Check Q1_5");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_5;
                    }
                    if (isStop)
                        return;
                    // question1_5	(activate)
                    Logger("Start Q1_5");
                    var question1_5 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_5);
                    // tìm thấy hình click vào hình
                    if (question1_5 != null)
                    {
                        Logger("Found Q1_5");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_5.Value.X, question1_5.Value.Y);
                        Delay(4);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(30);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(30);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_5");
                    
                    //Handle Q1_6
                    Logger("Check Q1_6");
                     StartQuest1_6:
                    var check_question1_6 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_6);
                    // wait for new quest1_6
                    if (check_question1_6 == null) // Q1_6 not found
                    {
                        Logger("Found Check Q1_6");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_6;
                    }
                    if (isStop)
                        return;
                    // question1_6	(click auto)
                    Logger("Start Q1_6");
                    var question1_6 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_6);
                    // tìm thấy hình click vào hình
                    if (question1_6 != null)
                    {
                        Logger("Found Q1_6");
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 83.0, 63.8);
                        Delay(2);
                    }
                    Logger("Done Quest1_6");

                    //Handle Q1_7
                    Logger("Check Q1_7");
                    StartQuest1_7:
                    var check_question1_7 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_7);
                    // wait for new quest1_7
                    if (check_question1_7 == null) // Q1_7 not found
                    {
                        Logger("Found Check Q1_7");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_7;
                    }
                    if (isStop)
                        return;
                    // question1_7	(activate)
                    Logger("Start Q1_7");
                    var question1_7 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_7);
                    // tìm thấy hình click vào hình
                    if (question1_7 != null)
                    {
                        Logger("Found Q1_7");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_7.Value.X, question1_7.Value.Y);
                        Delay(5);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(3);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(60);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(50);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_7");

                    //Handle Q1_8
                    Logger("Check Q1_8");
                    StartQuest1_8:
                    var check_question1_8 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_8);
                    // wait for new quest1_8
                    if (check_question1_8 == null) // Q1_8 not found
                    {
                        Logger("Found Check Q1_8");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_8;
                    }
                    if (isStop)
                        return;
                    // question1_8	(activate)
                    Logger("Start Q1_8");
                    var question1_8 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_8);
                    // tìm thấy hình click vào hình
                    if (question1_8 != null)
                    {
                        Logger("Found Q1_8");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_8.Value.X, question1_8.Value.Y);
                        Delay(5);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_8");
                    
                    //Handle Q1_9
                    if (isStop)
                        return;
                    Logger("Check Q1_9");
                    StartQuest1_9:
                    var check_question1_9 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_9);
                    // wait for new quest1_9
                    if (check_question1_9 == null) // Q1_9 not found
                    {
                        Logger("Found Check Q1_9");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_9;
                    }
                    if (isStop)
                        return;
                    // question1_9	(Forge)
                    Logger("Start Q1_9");
                    var question1_9 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_9);
                    // tìm thấy hình click vào hình
                    if (question1_9 != null)
                    {
                        Logger("Found Q1_9");
                        //Click Froge
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 78.0, 93.3);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.4, 26.8);
                        Delay(2);
                        //Click Enhance 1
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 66.6, 88.9);
                        Delay(2);
                        //Click Enhance 2
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 66.6, 88.9);
                        Delay(2);
                        //Click Enhance 3
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 66.6, 88.9);
                        Delay(2);
                        //Click Enhance 4 
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 66.6, 88.9);
                        Delay(2);
                        //Click Enhance 5
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 66.6, 88.9);
                        Delay(2);
                        //Click Enhance 6
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 66.6, 88.9);
                        Delay(2);
                        //Click view
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 55.5, 27.2);
                        Delay(2);
                        //Click set
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 10.5, 90.4);
                        Delay(2);
                        //Click level
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 88.3, 77.3);
                        Delay(4);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_9");

                    //Handle Q1_10
                    Logger("Check Q1_10");
                    StartQuest1_10:
                    var check_question1_10 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10);
                    // wait for new quest1_10
                    if (check_question1_10 == null) // Q1_10 not found
                    {
                        Logger("Found Check Q1_10");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_10;
                    }
                    if (isStop)
                        return;
                    // question1_10	(activate)
                    Logger("Start Q1_10");
                    var question1_10 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10);
                    // tìm thấy hình click vào hình
                    if (question1_10 != null)
                    {
                        Logger("Found Q1_10");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_10.Value.X, question1_10.Value.Y);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_10");

                    //Handle Q1_10-1
                    Logger("Check Q1_10-1");
                    StartQuest1_10_1:
                        var check_question1_10_1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10_1);
                    // wait for new quest1_10-1
                    if (check_question1_10_1 == null) // Q1_10-1 not found
                    {
                        Logger("Found Check Q1_10-1");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_10_1;
                    }
                    if (isStop)
                        return;
                    // question1_10-1 (activate)
                    Logger("Start Q1_10-1");
                    var question1_10_1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10_1);
                    // tìm thấy hình click vào hình
                    if (question1_10_1 != null)
                    {
                        Logger("Found Q1_10-1");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_10_1.Value.X, question1_10_1.Value.Y);
                        Delay(30);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_10-1");

                    //Handle Q1_10_2
                    Logger("Check Q1_10_2");
                    StartQuest1_10_2:
                    var check_question1_10_2 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10_2);
                    // wait for new quest1_10_2
                    if (check_question1_10_2 == null) // Q1_10_2 not found
                    {
                        Logger("Found Check Q1_10_2");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_10_2;
                    }
                    if (isStop)
                        return;
                    // question1_10_2	(click auto)
                    Logger("Start Q1_10_2");
                    var question1_10_2 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10_2);
                    // tìm thấy hình click vào hình
                    if (question1_10_2 != null)
                    {
                        Logger("Found Q1_10_2");
                            // click trail
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 75.0, 3.7);
                            Delay(2);
                            // do not show again
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 74.2, 87.7);
                            Delay(2);
                            // get strength
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.9, 85.1);
                            Delay(2);
                            //Thoát
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                            Delay(2);
                            //Next
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                            Delay(2);
                    }
                    Logger("Done Quest1_10_2");

                    //Handle Q1_10_3
                    Logger("Check Q1_10_3");
                    StartQuest1_10_3:
                    var check_question1_10_3 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10_3);
                    // wait for new quest1_10_3
                    if (check_question1_10_3 == null) // Q1_10_3 not found
                    {
                        Logger("Found Check Q1_10_3");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_10_3;
                    }
                    if (isStop)
                        return;
                    // question1_10_3	(click auto)
                    Logger("Start Q1_10_3");
                    var question1_10_3 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_10_3);
                    // tìm thấy hình click vào hình
                    if (question1_10_3 != null)
                    {
                        Logger("Found Q1_10_3");
                        //Click Bone Dragon
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_10_3.Value.X, question1_10_3.Value.Y);
                        Delay(2);
                    }
                    Logger("Done Quest1_10_3");

                    //Handle Q1_11
                    Logger("Check Q1_11");
                    StartQuest1_11:
                    var check_question1_11 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_11);
                    // wait for new quest1_11
                    if (check_question1_11 == null) // Q1_11 not found
                    {
                        Logger("Found Check Q1_11");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_11;
                    }
                    if (isStop)
                        return;
                    // question1_11	(Story Dungeon - Login Reward - Download)
                    Logger("Start Q1_11");
                    var question1_11 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_11);
                    // tìm thấy hình click vào hình
                    if (question1_11 != null)
                    {
                        Logger("Found Q1_11");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_11.Value.X, question1_11.Value.Y);
                        Delay(4);
                        //Go daily
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 23.7, 75.4);
                        Delay(2);
                        //Story
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 53.2, 28.0);
                        Delay(2);
                        //Map
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 17.0, 54.1);
                        Delay(2);
                        //1-3
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 30.7, 66.8);
                        Delay(2);
                        //Raid
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 65.1, 82.5);
                        Delay(5);
                        //Close
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.4, 83.3);
                        Delay(2);
                        //Cancel
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 40.8, 67.2);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 89.1, 16.7);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 89.5, 13.0);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Login Reward
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 74.8, 16.0);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.6, 82.5);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 59.5, 90.4);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 59.5, 90.4);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 90.6, 26.1);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 90.6, 26.1);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 90.6, 26.1);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 90.6, 26.1);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_11");

                    
                    //Handle Q1_12
                    Logger("Check Q1_12");
                    StartQuest1_12:
                    var check_question1_12 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_12);
                    // wait for new quest1_12
                    if (check_question1_12 == null) // Q1_12 not found
                    {
                        Logger("Found Check Q1_12");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_12;
                    }
                    if (isStop)
                        return;
                    // question1_12	(Darkness Below Light)
                    Logger("Start Q1_12");
                    var question1_12 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_12);
                    // tìm thấy hình click vào hình
                    if (question1_12 != null)
                    {
                        Logger("Found Q1_12");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_12.Value.X, question1_12.Value.Y);
                        Delay(2);
                    }
                    Logger("Done Quest1_12");

                    //Handle Q1_13
                    Logger("Check Q1_13");
                    StartQuest1_13:
                    var check_question1_13 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_13);
                    // wait for new quest1_13
                    if (check_question1_13 == null) // Q1_13 not found
                    {
                        Logger("Found Check Q1_13");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_13;
                    }
                    if (isStop)
                        return;
                    // question1_13	(Heart of Forest)
                    Logger("Start Q1_13");
                    var question1_13 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_13);
                    // tìm thấy hình click vào hình
                    if (question1_13 != null)
                    {
                        Logger("Found Q1_13");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_13.Value.X, question1_13.Value.Y);
                        Delay(2);
                    }
                    Logger("Done Quest1_13");


                    //Handle Q1_14
                    Logger("Check Q1_14");
                    StartQuest1_14:
                    var check_question1_14 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_14);
                    // wait for new quest1_14
                    if (check_question1_14 == null) // Q1_14 not found
                    {
                        Logger("Found Check Q1_14");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_14;
                    }
                    if (isStop)
                        return;
                    // question1_14	(For Love)
                    Logger("Start Q1_14");
                    var question1_14 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_14);
                    // tìm thấy hình click vào hình
                    if (question1_14 != null)
                    {
                        Logger("Found Q1_14");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_14.Value.X, question1_14.Value.Y);
                        Delay(2);
                    }
                    Logger("Done Quest1_14");

                    //Handle Q1_15
                    Logger("Check Q1_15");
                    StartQuest1_15:
                    var check_question1_15 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_15);
                    // wait for new quest1_15
                    if (check_question1_15 == null) // Q1_15 not found
                    {
                        Logger("Found Check Q1_15");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_15;
                    }
                    if (isStop)
                        return;
                    // question1_15	(Armored War)
                    Logger("Start Q1_15");
                    var question1_15 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_15);
                    // tìm thấy hình click vào hình
                    if (question1_15 != null)
                    {
                        Logger("Found Q1_15");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_15.Value.X, question1_15.Value.Y);
                        Delay(2);
                        //Mounts
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 78.0, 93.0);
                        Delay(2);
                        //Click pet
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 4.8, 23.5);
                        Delay(2);
                        //Click Activate
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 80.3, 92.6);
                        Delay(2);
                        //Thoát
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 96, 3);
                        Delay(10);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_15");

                    //Handle Q1_16
                    Logger("Check Q1_16");
                    StartQuest1_16:
                    var check_question1_16 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_16);
                    // wait for new quest1_16
                    if (check_question1_16 == null) // Q1_16 not found
                    {
                        Logger("Found Check Q1_16");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_16;
                    }
                    if (isStop)
                        return;
                    // question1_16	(Download resources)
                    Logger("Start Q1_16");
                    var question1_16 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_16);
                    // tìm thấy hình click vào hình
                    if (question1_16 != null)
                    {
                        Logger("Found Q1_16");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_16.Value.X, question1_16.Value.Y);
                        Delay(2);
                    }
                    Logger("Done Quest1_16");

                    //Handle Q1_17
                    Logger("Check Q1_17");
                    StartQuest1_17:
                    var check_question1_17 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_17);
                    // wait for new quest1_17
                    if (check_question1_17 == null) // Q1_17 not found
                    {
                        Logger("Found Check Q1_17");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_17;
                    }
                    if (isStop)
                        return;
                    // question1_17	(AFK Mode)
                    Logger("Start Q1_17");
                    var question1_17 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_17);
                    // tìm thấy hình click vào hình
                    if (question1_17 != null)
                    {
                        Logger("Found Q1_17");
                        //click AFK
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 43.3, 84.0);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 84.0);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 84.0);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 84.0);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 84.0);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 84.0);
                        Delay(2);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 84.0);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                        //Next
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.5, 48.5);
                        Delay(2);
                    }
                    Logger("Done Quest1_17");

                    //Handle Q1_18
                    Logger("Check Q1_18");
                StartQuest1_18:
                    var check_question1_18 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_18);
                    // wait for new quest1_18
                    if (check_question1_18 == null) // Q1_18 not found
                    {
                        Logger("Found Check Q1_18");
                        // sleep time...
                        Delay(2);
                        goto StartQuest1_18;
                    }
                    if (isStop)
                        return;
                    // question1_18	(Depth of)
                    Logger("Start Q1_18");
                    var question1_18 = KAutoHelper.ImageScanOpenCV.FindOutPoint(KAutoHelper.ADBHelper.ScreenShoot(deviceID), Q1_18);
                    // tìm thấy hình click vào hình
                    if (question1_18 != null)
                    {
                        Logger("Found Q1_18");
                        KAutoHelper.ADBHelper.Tap(deviceID, question1_18.Value.X, question1_18.Value.Y);
                        Delay(2);
                    }
                    Logger("Done Quest1_18");

                    Logger("Finish!!!!");
                });
                t.Start();
            }
        }

        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isStop = true;
            Logger("Stop");
        }
    }
}
