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
    public partial class editForm2 : Form
    {
        public editForm2()
        {
            InitializeComponent();
            tbName.Enabled = false;
            tbLName.Enabled = false;
            tbDVD_name.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            if(tbID.Text != string.Empty)
            {
                main.buttonEdit(tbID.Text, tbName.Text, tbLName.Text, tbDVD_name.Text, dateTimePicker1.Text, dateTimePicker2.Text);
                clearTB();
                warningLabel.Text = string.Empty;
                this.Hide();
            }
            else
            {
                warningLabel.Text = "Debes ingresar un ID valido";
            }
        }

        public void clearTB()
        {
            tbID.Text= string.Empty;
            tbName.Text= string.Empty;
            tbLName.Text= string.Empty;
            tbDVD_name.Text= string.Empty;
        }

        private void editForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            clearTB();
            this.Hide();
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            if (tbID.Text == string.Empty)
            {
                tbName.Enabled = false;
                tbLName.Enabled = false;
                tbDVD_name.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                tbName.Enabled = true;
                tbLName.Enabled = true;
                tbDVD_name.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }
    }
}
