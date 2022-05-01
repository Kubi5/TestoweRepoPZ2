using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            GameLogic.SettingFormAndLayout(this, this.tableLayoutPanel1);
            GameLogic.InitiatingTimers();
            GameLogic.addingImagestoTiles(this.tableLayoutPanel1, 64);
            GameLogic.TimeToLearnImages(TimeHandler.TimeToLearnTiles, this.tableLayoutPanel1);
            GameLogic.SettingTheTimetoDisplayPair(TimeHandler.TimeToDisplayPair);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            GameLogic.LabelClickedLogic(sender);
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            GameLogic.PauseTheGame(e);
        }
    }
}

