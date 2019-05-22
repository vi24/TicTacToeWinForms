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
            }
            else if (sign == Sign.O)
            {
                _image = Resources.O;
            }
            if (sign != Sign.Nothing)
            {
                _sign = sign;
            }
        }

        public void Play(PictureBox picture, Sign [,] map, int positionX, int positionY)
        {
            picture.Image = _image;
            map[positionX, positionY] = _sign;
        }

    }
}
