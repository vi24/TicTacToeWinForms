using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class State
    {
        public Player Winner { get; set; }
        public Player TurnPlayer { get; set; }
        public bool GameOver { get; set; }
        public Sign [,] Map { get; set; }

        public Player[] Players { get; }

        public struct Position
        {
            public int PositionX;
            public int PositionY;
        }

        public State(Player[] players, Sign [,] map, Player player, bool gameover)
        {
            Winner = null;
            TurnPlayer = player;
            GameOver = gameover;
            Players = players;
            Map = map;
        }

        public List<Position> GetFreePositions()
        {
            List<Position> freePositions = new List<Position>();
            Position position;

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] == Sign.Nothing)
                    {
                        position = new Position();
                        position.PositionX = i;
                        position.PositionY = j;
                        freePositions.Add(position);
                    }
                }
            }
            return freePositions;
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
            return CheckTopLeftToBottomRightDiagonal(sign) || CheckBottomLeftToTopRightDiagonal(sign);
        }

        public bool CheckTopLeftToBottomRightDiagonal(Sign sign)
        {
            return (Map[0, 0] == sign) && (Map[1, 1] == sign) && (Map[2, 2] == sign);
        }

        public bool CheckBottomLeftToTopRightDiagonal(Sign sign)
        {
            return (Map[2, 0] == sign) && (Map[1, 1] == sign) && (Map[0, 2] == sign);
        }

        public bool IsGameOver(Sign sign)
        {
            if(CheckHorizontal(sign) || CheckVertical(sign) || CheckDiagonals(sign))
            {
                Winner = TurnPlayer;
                GameOver = true;
                return true;
            }
            if(GetFreePositions().Count == 0)
            {
                GameOver = true;
                return true;
            }
            return false;
        }
    }
}
