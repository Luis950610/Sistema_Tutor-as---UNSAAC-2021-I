using STutoria.BusinessObjects.Procesos;
using STutoria.Facade.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STutoria.App.Auxiliares
{
    public partial class Form1 : Form
    {
        public CFichaTutoria recivir = new CFichaTutoria();
        public CFichaTutoria datosres;
        public FichaTutoriaFacade fichafacade = new FichaTutoriaFacade();
        public Form1()
        {
            InitializeComponent();
            datosres = new CFichaTutoria();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            descripcion.Text = "";
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datosres = recivir;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (descripcion.Text != "")
            {
                if (fichafacade.Update(datosres.IDTutoria.ToString(), descripcion.Text.Trim()))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ingrese descripcion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
