using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class State
    {
        public Sign TurnPlayer { get; set; }
        public bool GameOver { get; set; }
        public PictureBox[,] PictureBoxes { get; }

        public Sign [,] Map { get; set; }

        public Player[] Players { get; }
        public State(PictureBox[,] pictureBoxes, Player[] players, Sign [,] map, Sign sign, bool gameover)
        {
            TurnPlayer = sign;
            GameOver = gameover;
            PictureBoxes = pictureBoxes;
            Players = players;
            Map = map;
        }

        public bool CheckHorizontal(Sign x)
        {
            int horizontal = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Map[i, j] == x)
                    {
                        horizontal++;

                    }
                }
                if (horizontal == 3)
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

        public bool CheckVertical(Sign sign)
        {
            int vertical = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Map[j, i] == sign)
                    {
                        vertical++;
                    }
                }
                if (vertical == 3)
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

        public bool CheckDiagonals(Sign sign)
        {
            bool diagonal = false;
            for (int i = 0; i < 3; i++)
            {
                if (Map[i, i].Equals(sign))
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
            for (int i = 2, j = 0; i <= 0 && j < 3; i--, j++)
            {
                if (Map[i, j].Equals(sign))
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

        public bool CheckTopLeftToBottomRightDiagonal(Sign sign)
        {
            return (Map[0, 0] == sign) && (Map[1, 1] == sign) && (Map[2, 2] == sign);
        }

        public bool CheckBottomLeftToTopRightDiagonal(Sign sign)
        {
            return (Map[2, 0] == sign) && (Map[1, 1] == sign) && (Map[0, 2] == sign);
        }

        public bool CheckState(Sign sign)
        {
            return CheckHorizontal(sign) || CheckVertical(sign) || CheckDiagonals(sign);
        }
    }
}
