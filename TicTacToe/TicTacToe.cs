using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        private PictureBox[,] _pictureBoxes;
        private string[,] _map;
        private Game _game;

        public TicTacToe()
        {
            InitializeComponent();
            _game = new Game();
            _pictureBoxes = new PictureBox[3, 3]{
                { Position1PicBox, Position2PicBox, Position3PicBox },
                { Position4PicBox, Position5PicBox, Position6PicBox },
                { Position7PicBox, Position8PicBox, Position9PicBox }
            };
            _map = new string[3,3];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Position1PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position1PicBox, 0, 0);
        }

        private void Position2PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position2PicBox, 0, 1);
        }

        private void Position3PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position3PicBox, 0, 2);
        }

        private void Position4PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position4PicBox, 1, 0);
        }

        private void Position5PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position5PicBox, 1, 1);
        }

        private void Position6PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position6PicBox, 1, 2);
        }

        private void Position7PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position7PicBox, 2, 0);
        }

        private void Position8PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position8PicBox, 2, 1);
        }

        private void Position9PicBox_Click(object sender, EventArgs e)
        {
            _game.Play(Position9PicBox, 2, 2);
        }

        private void JsonRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void XmlRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }

        private void PlayerVsBotButton_Click(object sender, EventArgs e)
        {
            _game.InitializeGame(_pictureBoxes, _map, true, false);
        }

        private void PlayerVsPlayerButton_Click(object sender, EventArgs e)
        {
            _game.InitializeGame(_pictureBoxes, _map, true, true);
        }
    }
}
