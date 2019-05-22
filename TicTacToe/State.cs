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

    }
}
