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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackerLibrary.Models;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TournamentViewerWPF : Window, INotifyPropertyChanged
    {
        #region Fields

        private TournamentModel _tournament;
        private string _tournamentName;
        private ObservableCollection<int> _rounds;
        private ObservableCollection<MatchupModel> _selectedMatchups;

        #endregion

        #region Properties

        public TournamentModel Tournament
        {
            get { return _tournament; }
            set
            {
                if (_tournament != value)
                {
                    _tournament = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<int> Rounds
        {
            get { return _rounds; }
            set
            {
                if (_rounds != value)
                {
                    _rounds = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TournamentName
        {
            get { return _tournamentName; }
            set
            {
                if (_tournamentName != value)
                {
                    _tournamentName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MatchupModel> SelectedMatchups
        {
            get { return _selectedMatchups; }
            set
            {
                if (_selectedMatchups != value)
                {
                    _selectedMatchups = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        public TournamentViewerWPF(TournamentModel tournamentModel)
        {
            Rounds = new ObservableCollection<int>();
            SelectedMatchups = new ObservableCollection<MatchupModel>();
            Tournament = tournamentModel;
            DataContext = this;
            LoadRounds();
            InitializeComponent();
            TournamentName = tournamentModel.TournamentName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadRounds()
        {
            Rounds.Clear();

            Rounds.Add(1);
            int currentRound = 1;
            foreach (List<MatchupModel> matchups in Tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    Rounds.Add(currentRound);
                }
            }
        }

        private void roundDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMatchups();
        }

        private void LoadMatchups()
        {
            int round = (int)roundDropDown.SelectedItem;

            foreach (List<MatchupModel> matchups in Tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    SelectedMatchups = new ObservableCollection<MatchupModel>(matchups);
                }
            }
        }

        private void LoadMatchup()
        {
            if (matchupListBox.SelectedItem == null)
            {
                matchupListBox.SelectedIndex = 0;
            }
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        teamOneNameLabel.Content = m.Entries[i].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[i].Score.ToString();

                        teamTwoNameLabel.Content = "<bye>";
                        teamTwoScoreValue.Text = "";
                    }
                    else
                    {
                        teamOneNameLabel.Content = "Not Yet Set";
                        teamOneScoreValue.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        teamTwoNameLabel.Content = m.Entries[i].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[i].Score.ToString();
                    }
                    else
                    {
                        teamTwoNameLabel.Content = "Not Yet Set";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        private void matchupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMatchup();
        }
    }
}
