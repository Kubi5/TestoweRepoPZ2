using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'addressBookDataSet.tblContacts' table. You can move, or remove it, as needed.
            this.tblContactsTableAdapter.Fill(this.addressBookDataSet.tblContacts);
            //textBox1.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly =true;
            label13.Text = (bindingSource1.Position+1).ToString();
            label14.Text = bindingSource1.Count.ToString();

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.Position++;
            label13.Text = (bindingSource1.Position+1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.Position--;
            label13.Text = (bindingSource1.Position+1).ToString();
        }

        private void button5_Click(object sender, EventArgs e) //EDIT
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            //textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly =false;
            textBox1.Focus();
        }

        private void button6_Click(object sender, EventArgs e) //SAVE
        {
            //int currentPostion;
            bindingSource1.EndEdit();
            //currentPostion = bindingSource1.Position;

            if (addressBookDataSet.HasChanges())
            {
                tblContactsTableAdapter.Update(addressBookDataSet);
                this.tblContactsTableAdapter.Fill(this.addressBookDataSet.tblContacts);
            }
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;


        }

        private void button7_Click(object sender, EventArgs e)  //CANCEL
        {
            bindingSource1.CancelEdit();

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;

        }

        private void button8_Click(object sender, EventArgs e)  //ADD
        {
            //textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;

            bindingSource1.AddNew();
            //bindingSource1.Position += 1;
            label14.Text = bindingSource1.Count.ToString();
            label13.Text = (bindingSource1.Position + 1).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;

            dialogResult = MessageBox.Show("Czy aby na pewno chcesz usunąć wiersz?", "Potwierdź",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                bindingSource1.RemoveAt(bindingSource1.Position);
                label14.Text = bindingSource1.Count.ToString();
                label13.Text = (bindingSource1.Position+1).ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = bindingSource1.Count;
            label13.Text = (bindingSource1.Position+1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
            label13.Text = (bindingSource1.Position + 1).ToString();
        }
    }
}
