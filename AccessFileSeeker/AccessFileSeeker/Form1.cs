using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessFileSeeker
{
    public partial class Form1 : Form
    {
        OleDbConnection dbConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            string sConStr;

            saveFileDialog1.Title = "Select a Database File";
            saveFileDialog1.Filter = "MDB files|*.mdb";
            saveFileDialog1.CheckFileExists = true;

            dialogResult = saveFileDialog1.ShowDialog();

            if (dialogResult != DialogResult.Cancel && saveFileDialog1.FileName.Length > 0)
            {
                sConStr = "Provider=Microsoft.Jet.OLEDB.4.0;";
                sConStr += "Data Source=" + saveFileDialog1.FileName + ";";


                if(dbConnection != null)
                {
                    dbConnection.Close();
                    dbConnection = null;
                }

                dbConnection = new OleDbConnection(sConStr);
                dbConnection.Open();

                string[] filename_path = saveFileDialog1.FileName.ToString().Split((char)92);
                label2.Text = filename_path[filename_path.Length-1];

                DataTable schemaTable = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new Object[]{null,null,null,"Table"});

                dbConnection.Close();

                listBox1.Items.Clear();

                for(int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    listBox1.Items.Add(schemaTable.Rows[i].ItemArray[2].ToString());
                }
            }
        }
    }
}
