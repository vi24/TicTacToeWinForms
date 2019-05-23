using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;
using static TicTacToe.State;

namespace TicTacToe
{
    public class Bot: Player
    {
        private Random _random;

        public Bot(Sign sign):base(sign)
        {
            _random = new Random();
        }

        public void PlayRandom(PictureBox [,] pictures, Sign[,] map, List<Position> freePositions)
        {
            int randomX, randomY;
            PictureBox pictureBox = null;

            randomX = freePositions[_random.Next(freePositions.Count-1)].PositionX;
            randomY = freePositions[_random.Next(freePositions.Count-1)].PositionY;
            pictureBox = pictures[randomX, randomY];
            Play(pictureBox, map, randomX, randomY);
        }
    }
}
