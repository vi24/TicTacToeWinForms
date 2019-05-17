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
        Image Image { get; }

        public Player(bool x)
        {
            if (x)
            {
                Image = Resources.X;
            }
            else
            {
                Image = Resources.O;
            }
        }

        public void Play(PictureBox picture)
        {
            picture.Image = Image;
        }

    }
}
