using STurotia.App.Mantenimiento;
using STutoria.BusinessObjects.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STutoria.App.Padre
{
    public partial class FormPadre : Form
    {
        public CUsuario recivirdata = new CUsuario();
        public CUsuario usuario ;
        public FormPadre()
        {
            InitializeComponent();
        }
        private void FormPadre_Load(object sender, EventArgs e)
        {
            usuario = new CUsuario();
            usuario = recivirdata;
            labelControl2.Text = usuario.CodUsuario;
        }
        private Form activoFrm;

        //Metodo para mostrar los formularios
        private void abrirFormularioHijo(Form hijo)
        {
            if (activoFrm != null)
            {
                activoFrm.Close();
            }
            activoFrm = hijo;
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            panelFormHijo.Controls.Add(hijo);
            panelFormHijo.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }
        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Show();
        }

        private void FormPadre_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Mantenimiento.Estudiante());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Mantenimiento.Docente());
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Procesos.FormAsignacion());
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Mantenimiento.Tutor());
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Mantenimiento.Tutor());
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Procesos.FormTutorias());
        }
    }
}
