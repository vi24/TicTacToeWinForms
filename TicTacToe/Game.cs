using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class Game
    {
        private static Game _instance = null;
        private static State _state = null;

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
            _state = new State(pictureBoxes, players, map, Sign.X, false);
        }

        public void Play(PictureBox pictureBox, int positionX, int positionY)
        {
            if (_state == null) return;

            if (_state.TurnPlayer == Sign.X)
            {
                _state.Players[0].Play(pictureBox, _state.Map, positionX, positionY);
                _state.TurnPlayer = Sign.O;
                if (_state.CheckState(Sign.X))
                {
                    MessageBox.Show("You won");
                    _state.GameOver = true;
                    return;
                }
                if (_state.Players[1] is Bot)
                {
                    Bot bot = (Bot)_state.Players[1];
                    bot.PlayRandom(_state.PictureBoxes, _state.Map);
                    _state.TurnPlayer = Sign.X;
                    if (_state.CheckState(Sign.O))
                    {
                        MessageBox.Show("You lost");
                        _state.GameOver = true;
                        return;
                    }
                }
            }
            else 
            {
                _state.Players[1].Play(pictureBox, _state.Map, positionX, positionY);
                _state.TurnPlayer = Sign.X;

                if (_state.CheckState(Sign.O))
                {
                    MessageBox.Show("Player 2 won!");
                    _state.GameOver = true;
                    return;
                }
            }
        }

        public void ExportState()
        {

        }

        public void ImportState(State state)
        {
            _state = state;
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
    }
}
