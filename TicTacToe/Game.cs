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
            if (_state.TurnPlayer == Sign.X)
            {
                _state.Players[0].Play(pictureBox, _state.Map, positionX, positionY);
                _state.TurnPlayer = Sign.O;
                if (CheckState(Sign.X))
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
                    if (CheckState(Sign.O))
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

                if (CheckState(Sign.O))
                {
                    MessageBox.Show("Player 2 won!");
                    _state.GameOver = true;
                    return;
                }
            }
        }

        public static void ExportState()
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

        private bool CheckHorizontal(Sign x)
        {
            int horizontal = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; i++)
                {
                    if(_state.Map[i,j] == x)
                    {
                        horizontal++;
                    }
                }
                if(horizontal == 3)
                {
                    return true;
                }
                else
                {
                    horizontal = 0;
                }
            }
            return false;
        }

        private bool CheckVertical(Sign x)
        {
            int vertical = 0;
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; i++)
                {
                    if(_state.Map[i,j] == x)
                    {
                        vertical++;
                    }
                }
                if(vertical == 3)
                {
                    return true;
                }
                else
                {
                    vertical = 0;
                }
            }
            return false;
        }

        private bool CheckDiagonals (Sign sign)
        {
            bool diagonal = false;
            for(int i = 0; i < 3; i++)
            {
                if (_state.Map[i, i].Equals(sign))
                {
                    diagonal = true;
                }
                else
                {
                    diagonal = false;
                }
            }
            if (diagonal)
            {
                return true;
            }
            for(int i = 2, j = 0; i <= 0 && j < 3; i--, j++)
            {
                if (_state.Map[i, j].Equals(sign))
                {
                    diagonal = true;
                }
                else
                {
                    diagonal = false;
                }
            }
            if (diagonal)
            {
                return true;
            }

            return false;
        }

        private bool CheckTopLeftToBottomRightDiagonal(Sign sign)
        {
            throw new NotImplementedException();
        }
            

        private bool CheckState(Sign sign)
        {
            return CheckHorizontal(sign) || CheckVertical(sign) || CheckDiagonals(sign);
        }

        



    }
}
