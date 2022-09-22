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
    }
}
