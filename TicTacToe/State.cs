using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public struct State
    {
        public bool TurnPlayerX { get; set; }
        public bool GameOver { get; set; }
        public PictureBox[,] PictureBoxes { get; }

        public string [,] Map { get; set; }

        public Player[] Players { get; }
        public State(PictureBox[,] pictureBoxes, Player[] players, string [,] map, bool turnPlayerX, bool gameover)
        {
            TurnPlayerX = turnPlayerX;
            GameOver = gameover;
            PictureBoxes = pictureBoxes;
            Players = players;
            Map = map;
        }

    }
}
