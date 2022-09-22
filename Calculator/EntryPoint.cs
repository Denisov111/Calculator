using Calculator.Models;
using Calculator.ViewModels;
using Calculator.Views;
using EasyMvvm.Core;
using System;
using System.Threading;

namespace Calculator
{
    internal class EntryPoint
    {
        internal void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; ;
            //System.Windows.Forms.Application.ThreadException +=
            //    new ThreadExceptionEventHandler(Log.Application_ThreadException);

            MvvmFactory.CreateWindow(new Main(), new MainViewModel(), new MainView(), ViewMode.Show);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
