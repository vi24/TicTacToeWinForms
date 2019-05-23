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

        public void PlayRandom(Sign[,] map, List<Position> freePositions)
        {
            int randomX, randomY, index;

            index = _random.Next(freePositions.Count);
            var freePosition = freePositions[index];
            randomX = freePosition.PositionX;
            randomY = freePosition.PositionY;
            Play(map, randomX, randomY);
        }
    }
}
