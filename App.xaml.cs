using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DialogHost
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dialogService = new DialogService();

            var window = new MainWindow() { DataContext = new MainWindowViewModel(dialogService) };

            window.Show();
        }
    }
}
