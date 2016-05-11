using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI;
using Windows.UI.Core;
//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace 控件学习
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool bo = false;
        public MainPage()
        {
            this.InitializeComponent();
            AppViewBackButtonVisibility m = new AppViewBackButtonVisibility();
            m= AppViewBackButtonVisibility.Visible;
            List<Man> dates = new List<Man>()
            {
                new Man {Name="222" },
                new Man {Name="2222" }

            };
            comb.ItemsSource = dates;
        }

        private void Box1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            boxOfblock1.Text = Box1.Text;
        }

        private void Box1_Paste(object sender, TextControlPasteEventArgs e)
        {
            boxOfblock2.Text = "你进行了粘贴";
        }

        private void Box1_TextChanged(object sender, TextChangedEventArgs e)
        {
            boxOfblock3.Text = "你改变了文本";

        }

        private void a_Click(object sender, RoutedEventArgs e)
        {
            if (a.IsChecked == true)
            {
                header.Text += "a";
            }
            if (b.IsChecked == true)
                header.Text += "b";
            if (c.IsChecked == true)
                header.Text += "c";
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {

        }

        private void one_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (one_checkbox.IsChecked != null)
                header.Text = one_checkbox.Content.ToString();
        }

        private void one_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (one_checkbox.IsChecked != null)
            {
                header.Text = "null";
            }
        }

        private void ProgressBar_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void false_Click(object sender, RoutedEventArgs e)
        {
            idt.IsIndeterminate = false;

            idt.Visibility = Visibility.Visible;
        }

        private void true_Click(object sender, RoutedEventArgs e)
        {
            idt.IsIndeterminate = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer a = new DispatcherTimer();
            a.Interval = TimeSpan.FromSeconds(1);
            //a.Tick += a_Tick;
            idt.Value = 300;
            a.Start();
        }

        async void a_Tick(object sender, object e)
        {
            if (idt.Value < 10000)
            {

                idt.Value += 10;
            }
            else
            {
                (sender as DispatcherTimer).Tick -= a_Tick;
                (sender as DispatcherTimer).Stop();
                await new MessageDialog("进度完成").ShowAsync();
            }
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color clr = Color.FromArgb(255, (byte)red.Value, (byte)green.Value, (byte)blue.Value);
            display.Fill = new SolidColorBrush(clr);
            displayNum.Text = clr.ToString();

        }

        private void TimePicker_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            timeDisplay.Text = time.Time.ToString() + " " + date.Date.ToString();
        }

        private void date_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            timeDisplay.Text = " " + date.Date.ToString();

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string s;
            bo = true;
            s = $"保存成功:{name.Text}，{id.Text}";
            await new MessageDialog(s).ShowAsync();
        }

        private async void Flyout_Closed(object sender, object e)
        {
            if (bo)
            {
                bo = false;
                return;
            }
            else
            {
                string s;
                s = $"保存成功:{name.Text}，{id.Text}";
                await new MessageDialog(s).ShowAsync();
            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
                FlyoutBase.ShowAttachedFlyout(element);
        }



        private async void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {

            await new MessageDialog("drop").ShowAsync();

        }

        private async void TextBlock_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            splitview.IsPaneOpen = false;
            await new MessageDialog("YES").ShowAsync();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            splitview.IsPaneOpen = (splitview.IsPaneOpen == true) ? false : true;
        }
    }
}
