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
    /// Interaction logic for CreateTournament.xaml
    /// </summary>
    public partial class CreateTournamentWPF : Window, INotifyPropertyChanged, IPrizeRequester, ITeamRequester
    {
        private ObservableCollection<TeamModel> _availableTeams;
        private ObservableCollection<TeamModel> _selectedTeams;
        private ObservableCollection<PrizeModel> _selectedPrizes;

        public ObservableCollection<TeamModel> AvailableTeams
        {
            get { return _availableTeams; }
            set
            {
                if (_availableTeams != value)
                {
                    _availableTeams = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<TeamModel> SelectedTeams
        {
            get { return _selectedTeams; }
            set
            {
                if (_selectedTeams != value)
                {
                    _selectedTeams = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<PrizeModel> SelectedPrizes
        {
            get { return _selectedPrizes; }
            set
            {
                if (_selectedPrizes != value)
                {
                    _selectedPrizes = value;
                    OnPropertyChanged();
                }
            }
        }

        public CreateTournamentWPF()
        {
            DataContext = this;
            InitializeComponent();
            AvailableTeams = GlobalConfig.Connection.GetTeam_All();
            SelectedTeams = new ObservableCollection<TeamModel>();
            SelectedPrizes = new ObservableCollection<PrizeModel>();
            selectTeamDropDown.SelectedIndex = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void addTeamButton_Click(object sender, RoutedEventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;

            if (t != null)
            {
                AvailableTeams.Remove(t);
                SelectedTeams.Add(t);
            }
        }

        private void createPrizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Call the CreatePrize window
            CreatePrizeWPF wpf = new CreatePrizeWPF(this);
            wpf.Show();

            // Get back a PrizeModel from the window
            // Take the PrizeModel and put it into the observable collection of selected prizes
        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back a PrizeModel from the window
            // Take the PrizeModel and put it into the observable collection of selected prizes
            SelectedPrizes.Add(model);
        }

        public void TeamComplete(TeamModel model)
        {
            SelectedTeams.Add(model);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            CreateTeamWPF wpf = new CreateTeamWPF(this);
            wpf.Show();
        }

        private void removeSelectedTeamButton_Click(object sender, RoutedEventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (t != null)
            {
                SelectedTeams.Remove(t);
                AvailableTeams.Add(t);

                if (AvailableTeams.Count > 0)
                {
                    selectTeamDropDown.SelectedIndex = 0;
                }
            }
        }

        private void removeSelectedPrizeButton_Click(object sender, RoutedEventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;

            if (p != null)
            {
                SelectedPrizes.Remove(p);
            }
        }
    }
}
