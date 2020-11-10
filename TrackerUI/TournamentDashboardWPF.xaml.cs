using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for TournamentDashboardWPF.xaml
    /// </summary>
    public partial class TournamentDashboardWPF : Window, INotifyPropertyChanged
    {
        private ObservableCollection<TournamentModel> _tournaments;

        public ObservableCollection<TournamentModel> Tournaments
        {
            get { return _tournaments; }
            set
            {
                if (_tournaments != value)
                {
                    _tournaments = value;
                    OnPropertyChanged();
                }
            }
        }
        public TournamentDashboardWPF()
        {
            DataContext = this;
            Tournaments = GlobalConfig.Connection.GetTournament_All();
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void createTournamentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsWindowOpen<CreateTournamentWPF>())
            {
                CreateTournamentWPF wpf = new CreateTournamentWPF();
                wpf.Show();
                this.Close();
            }
        }

        public bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }
    }
}
