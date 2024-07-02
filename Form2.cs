using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Game_
{
    public partial class Game_Form : Form
    {
        private WarGame game;

        public Game_Form()
        {
            InitializeComponent();
            game = new WarGame();
        }
        private void btnPlayRound_Click(object sender, EventArgs e)
        {
            string result = game.PlayRound();
            lblResult.Text = result;
            UpdateUI();
        }

        private void UpdateUI()
        {
            lstPlayer1Deck.DataSource = null;
            lstPlayer2Deck.DataSource = null;
            lstPlayer1Deck.DataSource = game.GetPlayer1Deck();
            lstPlayer2Deck.DataSource = game.GetPlayer2Deck();
        }
    }
}
