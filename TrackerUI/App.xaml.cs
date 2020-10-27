using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrackerLibrary;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Initialize the database connection
            TrackerLibrary.GlobalConfig.InitializeConnections(DatabaseType.TextFile);

            base.OnStartup(e);
        }
    }
}
