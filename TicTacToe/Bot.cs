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
    public class Bot: Player
    {
        public Bot(bool x):base(x)
        {}

        public void PlayRandom(PictureBox [,] pictures, int randomX, int randomY)
        {
            Play(pictures[randomX,randomY]);
        }
    }
}
