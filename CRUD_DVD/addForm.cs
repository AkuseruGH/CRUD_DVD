using CRUD_DVD.lib;
using CRUD_DVD.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRUD_DVD
{
    public partial class addForm : Form
    {
        public addForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.buttonAdd(tbName.Text, tbLName.Text, tbDVD_name.Text, dateTimePicker1.Text, dateTimePicker2.Text);
            clearTB();
            this.Hide();
        }

        private void addForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            clearTB();
            this.Hide(); 
        }
        public void clearTB()
        {
            tbName.Text = string.Empty;
            tbLName.Text = string.Empty;
            tbDVD_name.Text = string.Empty;
        }
    }
}
