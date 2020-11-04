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
    /// Interaction logic for CreateTeam.xaml
    /// </summary>
    public partial class CreateTeamWPF : Window, INotifyPropertyChanged
    {
        private ObservableCollection<PersonModel> _availableTeamMembers;
        private ObservableCollection<PersonModel> _selectedTeamMembers;
        private ITeamRequester callingWindow;

        public ObservableCollection<PersonModel> AvailableTeamMembers
        {
            get { return _availableTeamMembers; }
            set
            {
                if (_availableTeamMembers != value)
                {
                    _availableTeamMembers = value;
                    OnPropertyChanged();
                }
            }
        }


        public ObservableCollection<PersonModel> SelectedTeamMembers
        {
            get { return _selectedTeamMembers; }
            set
            {
                if (_selectedTeamMembers != value)
                {
                    _selectedTeamMembers = value;
                    OnPropertyChanged();
                }
            }
        }

        public CreateTeamWPF(ITeamRequester caller)
        {
            DataContext = this;

            InitializeComponent();

            callingWindow = caller;
            AvailableTeamMembers = GlobalConfig.Connection.GetPerson_All();
            SelectedTeamMembers = new ObservableCollection<PersonModel>();
            //CreateSampleData();
            selectTeamMemberDropDown.SelectedIndex = 0;

        }

        private void CreateSampleData()
        {
            AvailableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            AvailableTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });

            SelectedTeamMembers.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
            SelectedTeamMembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
        }

        private void createMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = cellphoneValue.Text;

                p = GlobalConfig.Connection.CreatePerson(p);

                SelectedTeamMembers.Add(p);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill in all the fields.");
            }
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void addMemberButton_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                AvailableTeamMembers.Remove(p);
                SelectedTeamMembers.Add(p);

                if (_availableTeamMembers.Count > 0)
                {
                    selectTeamMemberDropDown.SelectedIndex = 0;
                }
            }
        }

        private void removeSelectedMemberButton_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null)
            {
                SelectedTeamMembers.Remove(p);
                AvailableTeamMembers.Add(p);

                if (_availableTeamMembers.Count > 0)
                {
                    selectTeamMemberDropDown.SelectedIndex = 0;
                }
            }
        }

        private void createTeamButton_Click(object sender, RoutedEventArgs e)
        {
            TeamModel t = new TeamModel();
            t.TeamName = teamNameValue.Text;
            t.TeamMembers = new List<PersonModel>(SelectedTeamMembers);

            GlobalConfig.Connection.CreateTeam(t);

            callingWindow.TeamComplete(t);
            this.Close();
        }
    }
}
