using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CRUD_DVD.lib;
using CRUD_DVD.model;


namespace CRUD_DVD
{
    public partial class Form1 : Form
    {
        addForm add = new addForm();
        editForm2 edit = new editForm2();

        public Form1()
        {
            InitializeComponent();
            showData();
        }

        public void buttonAdd(string nombre1, string apellido1,string name_DVD1,string fecha_renta1,string fecha_entrega1)
        {
            data obj = new data()
            {
                Nombre = nombre1,
                Apellido = apellido1,
                name_DVD = name_DVD1,
                fecha_renta = fecha_renta1,
                fecha_entrega = fecha_entrega1,
            };
            bool replies = dataLogic.Instance.save(obj);
            if (replies)
            {
                showData();
            }

        }

        public void buttonEdit(string ID,string nombre1, string apellido1, string name_DVD1, string fecha_renta1, string fecha_entrega1)
        {
            data obj = new data()
            {
                ID = int.Parse(ID),
                Nombre = nombre1,
                Apellido = apellido1,
                name_DVD = name_DVD1,
                fecha_renta = fecha_renta1,
                fecha_entrega = fecha_entrega1,
            };

            bool replies = dataLogic.Instance.updater(obj);
            if (replies)
            {
                showData();
            }

        }

        public void showData()
        {
            dGVData.DataSource = null;
            dGVData.DataSource = dataLogic.Instance.add();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (idBox.Text != string.Empty)
            {
                data obj = new data()
                {
                    ID = int.Parse(idBox.Text),

                };

                bool replies = dataLogic.Instance.delete(obj);
                if (replies)
                {
                    showData();
                    warningLabel.Text = string.Empty;
                }
            }
            else
            {
                warningLabel.Text = "Debes ingresar un ID valido";
            }
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<100; i++)
            {
                data obj = new data()
                {
                    ID = i,

                };

                bool replies = dataLogic.Instance.delete(obj);
                if (replies)
                {
                    showData();
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit.Show();
        }
    }
}
