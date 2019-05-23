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
        private Image _image;
        private Sign _sign;

        public Player(Sign sign)
        { 
            if (sign == Sign.X)
            {
                _image = Resources.X;
                _sign = sign;
            }
            else if (sign == Sign.O)
            {
                _image = Resources.O;
                _sign = sign;
            }
            else
            {
                _sign = Sign.Nothing;
            }
        }

        public void Play(PictureBox picture, Sign [,] map, int positionX, int positionY)
        {
            picture.Image = _image;
            map[positionX, positionY] = _sign;
        }

    }
}
