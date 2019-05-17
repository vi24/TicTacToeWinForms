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
        private static State _state;
        private static Random _random = new Random();

        public void InitializeGame(PictureBox[,] pictureBoxes, string[,] map, bool playerX, bool playerY)
        {
            Player[] players = CreatePlayers(playerX, playerY);
            _state = new State(pictureBoxes, players, map, true, false);
        }

        public void Play(PictureBox pictureBox, int x, int y)
        {
            bool empty = String.IsNullOrEmpty((string)_state.Map[x, y]);
            if (!empty)
            {
                return;
            }
            if (_state.TurnPlayerX)
            {
                _state.Players[0].Play(pictureBox);
                _state.Map[x, y] = "X";
                _state.TurnPlayerX = false;
                if (CheckState("X"))
                {
                    MessageBox.Show("You won");
                    _state.GameOver = true;
                    return;
                }
                if (_state.Players[1] is Bot)
                {
                    int j = _random.Next(3);
                    int k = _random.Next(3);
                    while (!String.IsNullOrEmpty(_state.Map[j, k]))
                    {
                        j = _random.Next(3);
                        k = _random.Next(3);
                    }
                    Bot bot = (Bot)_state.Players[1];
                    bot.PlayRandom(_state.PictureBoxes,j,k);
                    _state.Map[j, k] = "O";
                    _state.TurnPlayerX = true;
                    if (CheckState("O"))
                    {
                        MessageBox.Show("You lost");
                        _state.GameOver = true;
                        return;
                    }
                }
            }
            else 
            {
                _state.Players[1].Play(pictureBox);
                _state.TurnPlayerX = true;
                _state.Map[x, y] = "O";
                if (CheckState("O"))
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

        private Player[] CreatePlayers(bool playerXIsHuman, bool playerOIsHuman)
        {
            return (playerXIsHuman && playerOIsHuman) ? new Player[] { new HumanPlayer(true), new HumanPlayer(false) } : new Player[] { new HumanPlayer(true), new Bot(false) };
        }

        private bool CheckHorizontal(string sign)
        {
            if(!sign.Equals("X") && !sign.Equals("O"))
            {
                return false;
            }

            bool horizontal = false;
            int j;
            for(int i = 0; i < 3; i++)
            {
                j = 0;
                do
                {
                    if (!String.IsNullOrEmpty((string)_state.Map[i,j]) && _state.Map[i, j].Equals(sign))
                    {
                        horizontal = true;
                    }
                    else
                    {
                        horizontal = false;
                    }
                    j++;
                } while(horizontal && j < 3);

                if (horizontal)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckVertical(string sign)
        {
            if (!sign.Equals("X") && !sign.Equals("O"))
            {
                return false;
            }

            bool vertical = false;
            int j;
            for (int i = 0; i < 3; i++)
            {
                j = 0;
                vertical = false;
                do
                {
                    if (!String.IsNullOrEmpty((string)_state.Map[j, i]) && _state.Map[j, i].Equals(sign))
                    {
                        vertical = true;
                    }
                    else
                    {
                        vertical = false;
                    }
                    j++;
                } while (vertical && j < 3);

                if (vertical)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonal(string sign)
        {
            bool diagonal = false;
            for(int i = 0; i < 3; i++)
            {
                if (!String.IsNullOrEmpty((string)_state.Map[i, i]) && _state.Map[i, i].Equals(sign))
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
                if (!String.IsNullOrEmpty((string)_state.Map[i, j]) && _state.Map[i, j].Equals(sign))
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
            

        private bool CheckState(string sign)
        {
            return CheckHorizontal(sign) || CheckVertical(sign) || CheckDiagonal(sign);
        }

        



    }
}
