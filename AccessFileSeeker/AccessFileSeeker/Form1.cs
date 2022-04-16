using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessFileSeeker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();

            saveFileDialog1.Title = "Select a Database File";
            saveFileDialog1.Filter = "MDB Files (*.mdb) | (*.mdb)";
            saveFileDialog1.CheckFileExists = true;

            dialogResult = saveFileDialog1.ShowDialog();
        }
    }
}
