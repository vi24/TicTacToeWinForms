using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(bool x) : base(x)
        { }
    }
}
