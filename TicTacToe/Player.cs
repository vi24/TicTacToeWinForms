using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe
{
    public abstract class Player
    {
        private Sign _sign;

        public Player(Sign sign)
        { 
            if (sign == Sign.X)
            {

                _sign = sign;
            }
            else if (sign == Sign.O)
            {
                _sign = sign;
            }
            else
            {
                _sign = Sign.Nothing;
            }
        }

        public void Play(Sign [,] map, int positionX, int positionY)
        {
            map[positionX, positionY] = _sign;
        }
    }
}
