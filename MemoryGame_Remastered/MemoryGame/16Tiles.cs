using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
   
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            GameLogic.SettingFormAndLayout(this, this.tableLayoutPanel1);
            GameLogic.InitiatingTimers();
            GameLogic.addingImagestoTiles(this.tableLayoutPanel1,16);
            GameLogic.TimeToLearnImages(TimeHandler.TimeToLearnTiles,this.tableLayoutPanel1);
            GameLogic.SettingTheTimetoDisplayPair(TimeHandler.TimeToDisplayPair);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            GameLogic.LabelClickedLogic(sender);      
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            GameLogic.PauseTheGame(e);
        }

        
    }
}
