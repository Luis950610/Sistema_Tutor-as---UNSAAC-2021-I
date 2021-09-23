using DevExpress.XtraGrid.Views.Grid;
using STutoria.App.Auxiliares;
using STutoria.BusinessObjects.Mantenimientos;
using STutoria.BusinessObjects.Procesos;
using STutoria.Facade.Mantenimiento;
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
    public partial class FormAsignacion : Form
    {
        public CDocente recivirdat;
        public IList<CEstudiante> espera = new List<CEstudiante>();
        public FichaTutoriaFacade fichatutoria;
        public EstudianteFacade estudiantefacade;
        public IList<CEstudiante> DatosSelect = new List<CEstudiante>();
        public IList<CEstudiante> DatosDelete = new List<CEstudiante>();
        public FormAsignacion()
        {
            InitializeComponent();
            fichatutoria = new FichaTutoriaFacade();
            estudiantefacade = new EstudianteFacade();
            dateEdit1.EditValue = "";
            llenarGV();
        }
        public void llenarGV()
        {
            try
            {
                //recuperamos datos 
                espera = estudiantefacade.ListarEF();
                if (espera.Count > 0)
                {
                    gcEstudiantes.DataSource = espera;
                    gcEstudiantes.RefreshDataSource();
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
        private void repositoryItemButtonEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                CEstudiante estut = new CEstudiante();
                var gv = gcFichaTutor.MainView as GridView;
                int index = gv.FocusedRowHandle;
                estut.CodEstudiante = DatosSelect[index].CodEstudiante.ToString();
                estut.Nombres = DatosSelect[index].Nombres.ToString();
                estut.ApellidoPaterno = DatosSelect[index].ApellidoPaterno.ToString() != null ? DatosSelect[index].ApellidoPaterno.ToString() : "";
                estut.ApellidoMaterno = DatosSelect[index].ApellidoMaterno.ToString() != null ? DatosSelect[index].ApellidoMaterno.ToString() : "";
                estut.Carreraprofesional = DatosSelect[index].Carreraprofesional.ToString() != null ? DatosSelect[index].Carreraprofesional.ToString() : "";
                estut.Condicion = DatosSelect[index].Condicion.ToString() != null ? DatosSelect[index].Condicion.ToString() : "";
                //eliminamos el dato 
                DatosSelect.RemoveAt(index);
                espera.Add(estut);
                if (DatosSelect.Count > 0)
                {
                    gcFichaTutor.DataSource = DatosSelect;
                    gcFichaTutor.RefreshDataSource();
                }
                else
                {
                    gcFichaTutor.DataSource = null;
                    gcFichaTutor.RefreshDataSource();
                }
                if (espera.Count > 0)
                {
                    gcEstudiantes.DataSource = espera;
                    gcEstudiantes.RefreshDataSource();
                }
                else
                {
                    gcEstudiantes.DataSource = null;
                    gcEstudiantes.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                CEstudiante estut = new CEstudiante();
                var gv = gcEstudiantes.MainView as GridView;
                int index = gv.FocusedRowHandle;
                estut.CodEstudiante = espera[index].CodEstudiante.ToString();
                estut.Nombres = espera[index].Nombres.ToString();
                estut.ApellidoPaterno = espera[index].ApellidoPaterno.ToString() != null ? espera[index].ApellidoPaterno.ToString() : "";
                estut.ApellidoMaterno = espera[index].ApellidoMaterno.ToString() != null ? espera[index].ApellidoMaterno.ToString() : "";
                estut.Carreraprofesional = espera[index].Carreraprofesional.ToString() != null ? espera[index].Carreraprofesional.ToString() : "";
                estut.Condicion = espera[index].Condicion.ToString() != null ? espera[index].Condicion.ToString() : "";
                DatosSelect.Add(estut);
                if (DatosSelect.Count > 0)
                {
                    gcFichaTutor.DataSource = DatosSelect;
                    gcFichaTutor.RefreshDataSource();
                }
                else
                {
                    gcFichaTutor.DataSource = null;
                    gcFichaTutor.RefreshDataSource();
                }
                espera.RemoveAt(index);
                if (espera.Count > 0)
                {
                    gcEstudiantes.DataSource = espera;
                    gcEstudiantes.RefreshDataSource();
                }
                else
                {
                    gcEstudiantes.DataSource = null;
                    gcEstudiantes.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FormTutores L = new FormTutores();
            if (L.ShowDialog() == DialogResult.OK)
            {
                this.recivirdat = L.docdatos;
                textEdit1.Text = recivirdat.CodDocente;
                textEdit5.Text = recivirdat.Nombres;
                textEdit3.Text = recivirdat.ApellidoPaterno;
                textEdit4.Text = recivirdat.ApellidoMaterno;
                textEdit6.Text = recivirdat.Clase;
                textEdit8.Text = recivirdat.Categoria;
                textEdit9.Text = recivirdat.Regimen;
                textEdit10.Text = recivirdat.CarreraProfesional;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Trim() != "" && textEdit1.Text.Trim() != "" && textEdit5.Text.Trim() != "" && textEdit3.Text.Trim() != "" && textEdit4.Text.Trim() != "" && textEdit6.Text.Trim() != "" && textEdit8.Text.Trim() != "" && textEdit9.Text.Trim() != "" && textEdit10.Text.Trim() != "")
            {
                IList<CFichaTutoria> fichat = new List<CFichaTutoria>();
                for (int i = 0; i < DatosSelect.Count; i++)
                {
                    CFichaTutoria l = new CFichaTutoria();
                    l.IDTutoria = 0;
                    l.CodDocente = textEdit1.Text.Trim();
                    l.CodEstudiantes = DatosSelect[i].CodEstudiante.Trim();
                    l.Semestre = textEdit2.Text.Trim();
                    l.Descripcion= "";
                    fichat.Add(l);
                }
                DialogResult res = MessageBox.Show("¿Desea confirma?", "Advertencia", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    bool ver = fichatutoria.Grabar(fichat);
                    if (ver)
                    {
                        llenarGV();
                        DatosSelect.Clear();
                        gcFichaTutor.DataSource = null;
                        gcFichaTutor.RefreshDataSource();
                        MessageBox.Show("Registros asignados coreectamente", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        llenarGV();
                        MessageBox.Show("Registros no Guardados ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else { MessageBox.Show("Elige Tutor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question); }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            espera.Clear();
            DatosSelect.Clear();
            gcFichaTutor.DataSource = null;
            gcFichaTutor.RefreshDataSource();
            llenarGV();
        }
    }
}
