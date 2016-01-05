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

using LRSkipAsync;
using GetkenAsync;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MyWindows
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region 初期設定
        private CS_GetkenAsync getken;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();

            getken = new CS_GetkenAsync();

            textBox01.Text = "";
            textBox02.Text = "";

            ClearResultTextBox();			// 初期表示をクリアする
        }

        #region ［Ｇｅｔｋｅｎ］ボタン押下
        private async void button01_Click(object sender, RoutedEventArgs e)
        {   // [Getken]ボタン押下
            //            WriteLineResult("\n[Getken]ボタン押下");
            String KeyWord = textBox02.Text;

            await getken.ClearAsync();
            getken.Wbuf = textBox02.Text;
            await getken.ExecAsync();

            WriteLineResult("\nResult :");
            for (int i = 0; i < getken.Array.Length; i++)
            {
                WriteLineResult("\n [{0}] : [{1}]", i, getken.Array[i]);
            }
        }
        #endregion

        #region ［Ｒｅｓｅｔ］ボタン押下
        private void button02_Click(object sender, RoutedEventArgs e)
        {   // [Reset]ボタン押下
            ClearResultTextBox();			// 初期表示をクリアする

            textBox01.Text = "";
            textBox02.Text = "";
        }
        #endregion
    }
}
