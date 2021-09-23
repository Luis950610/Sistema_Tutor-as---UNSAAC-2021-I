using DevExpress.XtraGrid.Views.Grid;
using STutoria.BusinessObjects.Mantenimientos;
using STutoria.Facade.Mantenimiento;
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
    public partial class FormTutores : Form
    {
        public CDocente docdatos = new CDocente();
        public IList<CDocente> espera = new List<CDocente>();
        public DocenteFacade docentefacade;
        public FormTutores()
        {
            InitializeComponent();
            docentefacade = new DocenteFacade();
            llenarGV();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            CDocente estut = new CDocente();
            var gv = gcDocente.MainView as GridView;
            int index = gv.FocusedRowHandle;
            estut.CodDocente = espera[index].CodDocente.ToString();
            estut.Nombres = espera[index].Nombres.ToString();
            estut.ApellidoPaterno = espera[index].ApellidoPaterno.ToString() != null ? espera[index].ApellidoPaterno.ToString() : "";
            estut.ApellidoMaterno = espera[index].ApellidoMaterno.ToString() != null ? espera[index].ApellidoMaterno.ToString() : "";
            estut.Clase = espera[index].Clase.ToString() != null ? espera[index].Clase.ToString() : "";
            estut.Categoria = espera[index].Categoria.ToString() != null ? espera[index].Categoria.ToString() : "";
            estut.Regimen = espera[index].Regimen.ToString() != null ? espera[index].Regimen.ToString() : "";
            estut.CarreraProfesional = espera[index].CarreraProfesional.ToString() != null ? espera[index].CarreraProfesional.ToString() : "";
            this.docdatos = estut;
            this.Close();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //recuperamos datos 
                espera = docentefacade.Buscar(textEdit6.Text, textEdit7.Text);
                if (espera.Count > 0)
                {
                    gcDocente.DataSource = espera;
                }
                else
                {
                    MessageBox.Show("No hay ningun registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void llenarGV()
        {
            try
            {
                //recuperamos datos 
                espera = docentefacade.Listar();
                if (espera.Count > 0)
                {
                    gcDocente.DataSource = espera;
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
    }
}
