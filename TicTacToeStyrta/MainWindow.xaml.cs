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
            if (_GameLogic.stillPlaying == false) return;
            var space = (Button)sender;
            
            //check if space is used
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
            
            //use player sign to mark spot
            space.Content = _GameLogic.CurrentPlayer;

            //tag to jest takie cos "numer,numer"
            var coodinates = space.Tag.ToString().Split(',');
            var xValue = int.Parse(coodinates[0]);
            var yValue = int.Parse(coodinates[1]);

            //klasa pozycji
            var buttonPosition = new Position() { x = xValue, y = yValue };
            _GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);

            //check player win
            var pointForPlayer = _GameLogic.PlayerWin();
            if (pointForPlayer == true)
            {
                _GameLogic.stillPlaying = false;
                WinScreen.Text = $"{_GameLogic.CurrentPlayer} WINS!!!!";
                WinScreen.Visibility = Visibility.Visible;
                btnNewGame.Visibility = Visibility.Visible;
            } 
            else if (pointForPlayer == false && _GameLogic.moves >= 9)
            {
                _GameLogic.stillPlaying = false;
                WinScreen.Text = "Remis";
                WinScreen.Visibility = Visibility.Visible;
                btnNewGame.Visibility = Visibility.Visible;
            }

            if (_GameLogic.stillPlaying == true)
            {
                _GameLogic.SetNextPlayer();
                playingNow.Text = $"teraz gra - {_GameLogic.CurrentPlayer}";
            }
        }
        
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            //reset gry
            //ustaw
            foreach( var control in gridBoard.Children)
            {
                if(control is Button)
                {
                    ((Button)control).Content = String.Empty;
                }
            }

            _GameLogic = new GameLogic();
            WinScreen.Visibility=Visibility.Collapsed;
            btnNewGame.Visibility=Visibility.Collapsed;
        }
    }
}
