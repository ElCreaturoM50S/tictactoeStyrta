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

namespace TicTacToeStyrta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
          
        GameLogic _GameLogic = new GameLogic();

        private void PlayerClickSpace (object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
            space.Content = _GameLogic.CurrentPlayer;

            var coodinates = space.Tag.ToString().Split(',');
            var xValue = int.Parse(coodinates[0]);
            var yValue = int.Parse(coodinates[1]);

            var buttonPosition = new Position() { x = xValue, y = yValue };
            _GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);

            var pointForPlayer = _GameLogic.PlayerWin();
            if (pointForPlayer == true)
            {
                WinScreen.Text = $"{_GameLogic.CurrentPlayer} WINS!!!!";
                WinScreen.Visibility = Visibility.Visible;
            } 
            else if (pointForPlayer == false && _GameLogic.moves >= 9)
            {
                WinScreen.Text = "Draw";
                WinScreen.Visibility = Visibility.Visible;
            }

            _GameLogic.SetNextPlayer();

        }
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach( var control in gridBoard.Children)
            {
                if(control is Button)
                {
                    ((Button)control).Content = String.Empty;
                }
            }
            _GameLogic = new GameLogic();
            WinScreen.Visibility=Visibility.Collapsed;
        }
    }
}
