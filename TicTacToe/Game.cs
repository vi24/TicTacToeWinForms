using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class Game: INotifyPropertyChanged
    {
        private static Game _instance = null;
        private static State _state = null;
        private static string _turnText;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler BotTurnEvent;

        public string TurnText
        {
            get
            {
                return _turnText;
            }
            set
            {
                _turnText = value;
                OnPropertyChanged("TurnText");
            }
        }

        public static Game Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }

        private Game() {}
        
        public void InitializeGame(PictureBox[,] pictureBoxes, Sign[,] map, bool playerX, bool playerY)
        {
            Player[] players = CreatePlayers(playerX, playerY);
            _state = new State(pictureBoxes, players, map, players[0], false);
            BotTurnEvent += new EventHandler(PlayBot);
        }

        public void OnBotTurn()
        {
            if(BotTurnEvent != null)
            {
                BotTurnEvent(this, null);
            }
        }

        public void Play(PictureBox pictureBox, int positionX, int positionY)
        {
            if (_state == null) return;

            if (IsFirstPlayerTurn())
            {
                _state.Players[0].Play(pictureBox, _state.Map, positionX, positionY);
                if (_state.CheckState(Sign.X))
                {
                    _state.GameOver = true;
                    ShowGameOverMessage();
                    return;
                }
                _state.TurnPlayer = _state.Players[1];
                UpdateTurnLabel();
                OnBotTurn();
            }
            if (IsSecondPlayerTurn() && _state.Players[1] is HumanPlayer)
            {
                _state.Players[1].Play(pictureBox, _state.Map, positionX, positionY);
                if (_state.CheckState(Sign.O))
                {
                    _state.GameOver = true;
                    ShowGameOverMessage();
                    return;
                }
                _state.TurnPlayer = _state.Players[0];
                UpdateTurnLabel();
            }
        }

        public void ExportState()
        {

        }

        private static Player[] CreatePlayers(bool firstPlayerIsHuman, bool secondPlayerIsHuman)
        {
            if (firstPlayerIsHuman && secondPlayerIsHuman)
            {
                return new Player[] { new HumanPlayer(Sign.X), new HumanPlayer(Sign.O) };
            }
            else
            {
                return new Player[] { new HumanPlayer(Sign.X), new Bot(Sign.O) };
            }
        }

        private void ShowGameOverMessage()
        {
            if (_state.GameOver == false) return;

            if (IsFirstPlayerTurn() && _state.Players[1] is Bot)
            {
                MessageBox.Show("You won!");
                return;
            }
            if (IsFirstPlayerTurn())
            {
                MessageBox.Show("Player 1 won!");
                return;
            }
            if (IsSecondPlayerTurn() && _state.Players[1] is HumanPlayer)
            {
                MessageBox.Show("Player 2 won!");
            }
            if (IsSecondPlayerTurn() && _state.Players[1] is Bot)
            {
                MessageBox.Show("Bot won!");
                return;
            }
        }

        public void UpdateTurnLabel()
        {
            if (IsFirstPlayerTurn() && _state.Players[1] is HumanPlayer) 
            {
                TurnText = "Player 1's Turn!";
                return;
            }
            if (IsFirstPlayerTurn())
            {
                TurnText = "Your turn!";
                return;
            }
            if(_state.TurnPlayer is HumanPlayer && IsSecondPlayerTurn())
            {
                TurnText = "Player 2's Turn!";
                return;
            }
            TurnText = "Bot's Turn!";
            return;
        }

        private bool IsFirstPlayerTurn()
        {
            return _state.Players[0] == _state.TurnPlayer && _state.TurnPlayer is HumanPlayer;
        }

        private bool IsSecondPlayerTurn()
        {
            return _state.Players[1] == _state.TurnPlayer;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void PlayBot(object sender, EventArgs e)
        {
            if (_state.TurnPlayer is Bot)
            {
                Bot bot = (Bot)_state.Players[1];
                bot.PlayRandom(_state.PictureBoxes, _state.Map, _state.GetFreePositions());
                if (_state.CheckState(Sign.O))
                {
                    _state.GameOver = true;
                    ShowGameOverMessage();
                    return;
                }
                _state.TurnPlayer = _state.Players[0];
                UpdateTurnLabel();
            }
        }
    }
}
