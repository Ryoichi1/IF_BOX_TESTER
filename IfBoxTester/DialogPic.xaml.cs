﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IfBoxTester
{
    /// <summary>
    /// Dialog.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogPic
    {

        public DialogPic(string mess)
        {
            InitializeComponent();

            this.MouseLeftButtonDown += (sender, e) => this.DragMove();//ウィンドウ全体でドラッグ可能にする

            this.DataContext = State.VmTestStatus;
            labelMessage.Content = mess;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            General.StopSound();
            Flags.DialogReturn = true;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            General.StopSound();
            Flags.DialogReturn = false;
            this.Close();
        }

        private void metroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            General.PlaySoundLoop(General.soundAlarm);
            ButtonOk.Focus();
            imagePic.Source = new BitmapImage(new Uri("Resources/Pic/non2.PNG", UriKind.Relative));
        }


        bool FlagButtonOkSelected = true;


        private void ButtonOk_GotFocus(object sender, RoutedEventArgs e)
        {
            ButtonOk.Background = General.DialogOnBrush;
            FlagButtonOkSelected = true;
        }

        private void ButtonCancel_GotFocus(object sender, RoutedEventArgs e)
        {
            ButtonCancel.Background = General.DialogOnBrush;
            FlagButtonOkSelected = false;
        }

        private void ButtonOk_LostFocus(object sender, RoutedEventArgs e)
        {
            ButtonOk.Background = Brushes.Transparent;
        }

        private void ButtonCancel_LostFocus(object sender, RoutedEventArgs e)
        {
            ButtonCancel.Background = Brushes.Transparent;
        }

        private void ButtonOk_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!FlagButtonOkSelected)
            {
                ButtonOk.Background = General.DialogOnBrush;
                ButtonCancel.Background = Brushes.Transparent;
            }
        }

        private void ButtonCancel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (FlagButtonOkSelected)
            {
                ButtonCancel.Background = General.DialogOnBrush;
                ButtonOk.Background = Brushes.Transparent;
            }
        }

        private void ButtonOk_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!FlagButtonOkSelected)
            {
                ButtonOk.Background = Brushes.Transparent;
                ButtonCancel.Background = General.DialogOnBrush;
            }
        }

        private void ButtonCancel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (FlagButtonOkSelected)
            {
                ButtonCancel.Background = Brushes.Transparent;
                ButtonOk.Background = General.DialogOnBrush;
            }
        }
    }
}
