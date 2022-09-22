using System.Windows.Controls;
using EasyMvvm.Core;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Calculator.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow, IView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public async void OnSendMessage(string message)
        {
            _ = await this.ShowMessageAsync("", message);
        }

        /// <summary>
        /// Прокрутка вправо, чтобы было возможно видеть последний
        /// введённый символ, если стока не вмещается в текстбокс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((TextBox)sender).ScrollToHorizontalOffset(inputTextBox.GetRectFromCharacterIndex(inputTextBox.Text.Length).Right);
        }
    }
}
