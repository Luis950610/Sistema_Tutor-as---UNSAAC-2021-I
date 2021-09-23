using DevExpress.XtraGrid.Views.Grid;
using STutoria.App.Auxiliares;
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

namespace STutoria.App.Procesos
{
    public partial class FormTutorias : Form
    {
        public IList<CFichaTutoria> espera = new List<CFichaTutoria>();
        public FichaTutoriaFacade fichatutoriafacade;
        public CFichaTutoria ficha = new CFichaTutoria();
        public FormTutorias()
        {
            InitializeComponent();
            fichatutoriafacade = new FichaTutoriaFacade();
            llenarGV();
        }
        public void llenarGV()
        {
            try
            {
                //recuperamos datos 
                espera = fichatutoriafacade.RecuperarAsignacion();
                if (espera.Count > 0)
                {
                    gcFichaTutoria.DataSource = espera;
                    gcFichaTutoria.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show("No hay ningun registro de Estudiantes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            var gv = gcFichaTutoria.MainView as GridView;
            int i = gv.FocusedRowHandle;
            CFichaTutoria l = new CFichaTutoria();
            l.IDTutoria = espera[i].IDTutoria;
            l.CodDocente = espera[i].CodDocente;
            l.CodEstudiantes = espera[i].CodEstudiantes;
            l.Semestre = espera[i].Semestre;
            l.Fecha = espera[i].Fecha;
            l.Descripcion = espera[i].Descripcion;
            FichaTutoria L = new FichaTutoria();
            L.recivir = l;
            L.Show();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //recuperamos datos 
                espera = fichatutoriafacade.Buscar(textEdit1.Text,textEdit2.Text,textEdit3.Text);
                if (espera.Count > 0)
                {
                    gcFichaTutoria.DataSource = espera;
                    gcFichaTutoria.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show("No hay ningun registro de Estudiantes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            var gv = gcFichaTutoria.MainView as GridView;
            int i = gv.FocusedRowHandle;
            CFichaTutoria l = new CFichaTutoria();
            l.IDTutoria = espera[i].IDTutoria;
            l.CodDocente = espera[i].CodDocente;
            l.CodEstudiantes = espera[i].CodEstudiantes;
            l.Semestre = espera[i].Semestre;
            l.Fecha = espera[i].Fecha;
            l.Descripcion = espera[i].Descripcion; 
            Form1 L = new Form1();
            L.recivir = l;
            if (L.ShowDialog() == DialogResult.OK)
            {
                llenarGV();
            }


        }
    }
}
