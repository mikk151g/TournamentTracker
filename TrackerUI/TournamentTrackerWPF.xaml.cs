using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TournamentViewer : Window
    {
        public TournamentViewer()
        {
            InitializeComponent();

            //if(this.scoreButton.IsMouseOver && System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed)
            //{
            //    scoreButton.Background = new SolidColorBrush(Color.FromRgb(102, 102, 102));
            //}
            //else if(this.scoreButton.IsMouseOver && System.Windows.Input.Mouse.LeftButton != MouseButtonState.Pressed)
            //{
            //    scoreButton.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            //}
        }

        private void ScoreButton_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Mouse enter");
        }
    }
}
