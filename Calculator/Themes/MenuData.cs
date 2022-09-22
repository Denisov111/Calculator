using ControlzEx.Theming;
using EasyMvvm.Core;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculator.Themes
{
    public class AccentColorMenuData
    {
        public string Name { get; set; }

        public Brush BorderColorBrush { get; set; }

        public Brush ColorBrush { get; set; }

        public AccentColorMenuData()
        {
            ChangeAccentCommand = new RelayCommand(obj => DoChangeTheme(obj.ToString()));
        }

        public ICommand ChangeAccentCommand { get; }

        protected virtual void DoChangeTheme(string name)
        {
            if (name is not null)
            {
                _ = ThemeManager.Current.ChangeThemeColorScheme(Application.Current, name);
            }
        }
    }

    public class AppThemeMenuData : AccentColorMenuData
    {
        protected override void DoChangeTheme(string name)
        {
            if (name is not null)
            {
                _ = ThemeManager.Current.ChangeThemeBaseColor(Application.Current, name);
            }
        }
    }
}
