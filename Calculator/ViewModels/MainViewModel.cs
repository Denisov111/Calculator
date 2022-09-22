using Calculator.Models;
using EasyMvvm.Core;

namespace Calculator.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private Main main;

        public override void InitializeViewModel()
        {
            main = (Main)Model;
        }
    }
}
