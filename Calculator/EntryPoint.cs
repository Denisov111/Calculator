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
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;

            MvvmFactory.CreateWindow(new Main(), new MainViewModel(), new MainView(), ViewMode.Show);
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowException(e.Exception);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowException((Exception)e.ExceptionObject);
        }

        private void ShowException(Exception ex)
        {
            _ = System.Windows.MessageBox.Show(ex.Message, "Упс!! Исключение");
            System.Windows.Forms.Application.Exit();
        }
    }
}
