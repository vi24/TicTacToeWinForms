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
        private Game _game;

        public TicTacToe()
        {
            InitializeComponent();
            _game = Game.Instance;
            _pictureBoxes = new PictureBox[3, 3]{
                { Position1PicBox, Position2PicBox, Position3PicBox },
                { Position4PicBox, Position5PicBox, Position6PicBox },
                { Position7PicBox, Position8PicBox, Position9PicBox }
            };
            TurnLabel.Text = "Choose Mode!";
            _game.PropertyChanged += UpdateTurnLabel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Position1PicBox_Click(object sender, EventArgs e)
        {
            if(Position1PicBox.Image == null)
            {
                _game.Play(0, 0);
            }
        }

        private void Position2PicBox_Click(object sender, EventArgs e)
        {
            if(Position2PicBox.Image == null)
            {
                _game.Play(0, 1);
            }
        }

        private void Position3PicBox_Click(object sender, EventArgs e)
        {
            if(Position3PicBox.Image == null)
            {
                _game.Play(0, 2);
            }
        }

        private void Position4PicBox_Click(object sender, EventArgs e)
        {
            if(Position4PicBox.Image == null)
            {
                _game.Play(1, 0);
            }
        }

        private void Position5PicBox_Click(object sender, EventArgs e)
        {
            if(Position5PicBox.Image == null)
            {
                _game.Play(1, 1);
            }
        }

        private void Position6PicBox_Click(object sender, EventArgs e)
        {
            if(Position6PicBox.Image == null)
            {
                _game.Play(1, 2);
            }
        }

        private void Position7PicBox_Click(object sender, EventArgs e)
        {
            if(Position7PicBox.Image == null)
            {
                _game.Play(2, 0);
            }
        }

        private void Position8PicBox_Click(object sender, EventArgs e)
        {
            if(Position8PicBox.Image == null)
            {
                _game.Play(2, 1);
            }
        }

        private void Position9PicBox_Click(object sender, EventArgs e)
        {
            if(Position9PicBox.Image == null)
            {
                _game.Play(2, 2);
            }
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
            _game.InitializeGame(_pictureBoxes, true, false);
        }

        private void PlayerVsPlayerButton_Click(object sender, EventArgs e)
        {
            _game.InitializeGame(_pictureBoxes, true, true);
        }

        public void UpdateTurnLabel(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "TurnText")
            {
                TurnLabel.Text = _game.TurnText;
            }
        }
    }
}
