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
        private Random _random;

        public Bot(Sign sign):base(sign)
        {
            _random = new Random();
        }

        public void PlayRandom(PictureBox [,] pictures, Sign [,] map)
        {
            int randomX, randomY;
            List<List<int>> freeSpaces = new List<List<int>>();
            PictureBox pictureBox = null;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == Sign.Nothing)
                    {
                        freeSpaces.Add(new List<int>() { i, j });
                    }
                }
            }
            randomX = freeSpaces[_random.Next(freeSpaces.Count)][0];
            randomY = freeSpaces[_random.Next(freeSpaces.Count)][1];
            pictureBox = pictures[randomX, randomY];
            Play(pictureBox, map, randomX, randomY);
        }
    }
}
