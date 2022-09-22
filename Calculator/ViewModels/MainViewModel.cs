using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Calculator.Models;
using Calculator.Themes;
using ControlzEx.Theming;
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

        public string InputString => main.InputString;

        public string InputResult => main.InputResult;

        public RelayCommand InputCharCommand => new(obj => main.InputChar(obj.ToString()));

        public RelayCommand SetOperationCommand => new(obj => main.SetOperation(obj.ToString()));

        public List<AppThemeMenuData> AppThemes => ThemeManager.Current.Themes
                                         .GroupBy(x => x.BaseColorScheme)
                                         .Select(x => x.First())
                                         .Select(a => new AppThemeMenuData { Name = a.BaseColorScheme, BorderColorBrush = a.Resources["MahApps.Brushes.ThemeForeground"] as Brush, ColorBrush = a.Resources["MahApps.Brushes.ThemeBackground"] as Brush })
                                         .ToList();

        public List<AccentColorMenuData> AccentColors => ThemeManager.Current.Themes
                                            .GroupBy(x => x.ColorScheme)
                                            .OrderBy(a => a.Key)
                                            .Select(a => new AccentColorMenuData { Name = a.Key, ColorBrush = a.First().ShowcaseBrush })
                                            .ToList();
    }
}
