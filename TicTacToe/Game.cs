using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe
{
    public class Game: INotifyPropertyChanged
    {
        private static PictureBox[,] _pictureBoxes;
        private static Game _instance = null;
        private static State _state = null;
        private static string _turnText;
        private static Player _firstPlayer;
        private static Player _secondPlayer;

        public event PropertyChangedEventHandler PropertyChanged;
        private event EventHandler UpdatePictureBoxEvent;
        private event EventHandler BotTurnEvent;

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
            _state = new State(players, map, players[0], false);
            BotTurnEvent += new EventHandler(PlayBot);
            UpdatePictureBoxEvent += new EventHandler(UpdatePictureBoxes);
            _firstPlayer = players[0];
            _secondPlayer = players[1];
            _pictureBoxes = pictureBoxes;
        }

        public void Play(PictureBox pictureBox, int positionX, int positionY)
        {
            if (_state == null || _state.GameOver) return;

            if (IsFirstPlayerTurn())
            {
                _firstPlayer.Play(_state.Map, positionX, positionY);
                OnUpdateMap();
                if (_state.IsGameOver(Sign.X))
                {
                    ShowGameOverMessage();
                    return;
                }
                _state.TurnPlayer = _secondPlayer;
                UpdateTurnLabel();
                OnBotTurn();
                return;
            }
            if (IsSecondPlayerTurn() && _secondPlayer is HumanPlayer)
            {
                _secondPlayer.Play(_state.Map, positionX, positionY);
                OnUpdateMap();
                if (_state.IsGameOver(Sign.O))
                {
                    ShowGameOverMessage();
                    return;
                }
                _state.TurnPlayer = _firstPlayer;
                UpdateTurnLabel();
                return;
            }
        }

        public void UpdateTurnLabel()
        {
            if (IsFirstPlayerTurn() && _secondPlayer is HumanPlayer)
            {
                TurnText = "Player 1's Turn!";
                return;
            }
            if (IsFirstPlayerTurn())
            {
                TurnText = "Your turn!";
                return;
            }
            if (_state.TurnPlayer is HumanPlayer && IsSecondPlayerTurn())
            {
                TurnText = "Player 2's Turn!";
                return;
            }
            TurnText = "Bot's Turn!";
            return;
        }
        public void ExportState()
        {
            throw new NotImplementedException();
        }

        #region private methods
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

            if(_state.Winner == null)
            {
                MessageBox.Show("Draw!!");
                return;
            }

            if(_secondPlayer is Bot)
            {
                if(_state.Winner == _firstPlayer)
                {
                    MessageBox.Show("You won!");
                    return;
                }
                else
                {
                    MessageBox.Show("Bot won!");
                    return;
                }
            }
            else
            {
                if (_state.Winner == _firstPlayer)
                {
                    MessageBox.Show("Player 1 won!");
                    return;
                }
                else
                {
                    MessageBox.Show("Player 2 won!");
                    return;
                }
            }
        }

        private bool IsFirstPlayerTurn()
        {
            return _firstPlayer == _state.TurnPlayer && _state.TurnPlayer is HumanPlayer;
        }

        private bool IsSecondPlayerTurn()
        {
            return _secondPlayer == _state.TurnPlayer;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnUpdateMap()
        {
            if(UpdatePictureBoxEvent != null)
            {
                UpdatePictureBoxEvent(this, null);
            }
        }

        private void OnBotTurn()
        {
            if (BotTurnEvent != null)
            {
                BotTurnEvent(this, null);
            }
        }

        private void UpdatePictureBoxes(object sender, EventArgs e)
        {
            for(int i = 0; i < _state.Map.GetLength(0); i++)
            {
                for(int j = 0; j < _state.Map.GetLength(1); j++)
                {
                    if(_state.Map[i,j] == Sign.X)
                    {
                        _pictureBoxes[i,j].Image = Resources.X;
                    }
                    if(_state.Map[i,j] == Sign.O)
                    {
                        _pictureBoxes[i, j].Image = Resources.O;
                    }
                }
            }
        }

        private void PlayBot(object sender, EventArgs e)
        {
            if (_state.TurnPlayer is Bot)
            {
                Bot bot = (Bot)_state.Players[1];
                bot.PlayRandom(_state.Map, _state.GetFreePositions());
                OnUpdateMap();
                if (_state.IsGameOver(Sign.O))
                {
                    ShowGameOverMessage();
                    return;
                }
                _state.TurnPlayer = _firstPlayer;
                UpdateTurnLabel();
            }
        }
        #endregion
    }
}
