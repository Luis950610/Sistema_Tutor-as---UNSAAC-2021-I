using DevExpress.XtraGrid.Views.Grid;
using STutoria.BusinessObjects.Procesos;
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

namespace STutoria.App.Mantenimiento
{
    public partial class Tutor : Form
    {
        public IList<CTutor> espera = new List<CTutor>();
        public TutorFacade tutorfacade;
        public Tutor()
        {
            InitializeComponent();
            tutorfacade = new TutorFacade();
            llenarGV();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit8.Text = "";
            textEdit9.Text = "";
            textEdit10.Text = "";
            textEdit11.Text = "";
        }

        public void llenarGV()
        {
            try
            {
                //recuperamos datos 
                espera = tutorfacade.Listar();
                if (espera.Count > 0)
                {
                    gcTutor.DataSource = espera;
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit1.Text != "" && textEdit2.Text != "" && textEdit3.Text != "" && textEdit4.Text != "" && textEdit5.Text != "" && textEdit8.Text != "" && textEdit9.Text != "" && textEdit10.Text != "" && textEdit11.Text != "")
                {
                    CTutor datos = new CTutor();
                    datos.CodDocente = textEdit1.Text;
                    datos.Nombres = textEdit2.Text;
                    datos.ApellidoPaterno = textEdit3.Text;
                    datos.ApellidoMaterno = textEdit4.Text;
                    datos.Clase = textEdit5.Text;
                    datos.Categoria = textEdit8.Text;
                    datos.Regimen = textEdit9.Text;
                    datos.EscuelaProfesional = textEdit10.Text;
                    datos.CantidaEstudiantes = Convert.ToInt16( textEdit11.Text.Trim());
                    if (tutorfacade.Grabar(datos))
                    {
                        Limpiar();
                        MessageBox.Show("Regitro Guardado Corectamente", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro No Guardado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }

                }
                else
                {
                    MessageBox.Show("LLene todo los Capos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //recuperamos datos 
                espera = tutorfacade.Buscar(textEdit6.Text, textEdit7.Text);
                if (espera.Count > 0)
                {
                    gcTutor.DataSource = espera;
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

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                CTutor estut = new CTutor();
                var gv = gcTutor.MainView as GridView;
                int index = gv.FocusedRowHandle;
                estut.CodDocente = espera[index].CodDocente.ToString();
                estut.Nombres = espera[index].Nombres.ToString();
                estut.ApellidoPaterno = espera[index].ApellidoPaterno.ToString() != null ? espera[index].ApellidoPaterno.ToString() : "";
                estut.ApellidoMaterno = espera[index].ApellidoMaterno.ToString() != null ? espera[index].ApellidoMaterno.ToString() : "";
                estut.Clase = espera[index].Clase.ToString() != null ? espera[index].Clase.ToString() : "";
                estut.Categoria = espera[index].Categoria.ToString() != null ? espera[index].Categoria.ToString() : "";
                estut.Regimen = espera[index].Regimen.ToString() != null ? espera[index].Regimen.ToString() : "";
                estut.EscuelaProfesional = espera[index].EscuelaProfesional.ToString() != null ? espera[index].EscuelaProfesional.ToString() : "";
                estut.CantidaEstudiantes = espera[index].CantidaEstudiantes.ToString() != null ? Convert.ToInt16(espera[index].CantidaEstudiantes.ToString().Trim()) : 0;
                if (estut != null)
                {
                    this.xtraTabControl1.SelectedTabPage = xtraTabPage1;
                    textEdit1.Text = estut.CodDocente;
                    textEdit2.Text = estut.Nombres;
                    textEdit3.Text = estut.ApellidoPaterno;
                    textEdit4.Text = estut.ApellidoMaterno;
                    textEdit5.Text = estut.Clase;
                    textEdit8.Text = estut.Categoria;
                    textEdit9.Text = estut.Regimen;
                    textEdit10.Text = estut.EscuelaProfesional;
                    textEdit11.Text = estut.CantidaEstudiantes.ToString();

                }
                else
                {
                    Limpiar();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                CTutor estut = new CTutor();
                var gv = gcTutor.MainView as GridView;
                int index = gv.FocusedRowHandle;
                estut.CodDocente = espera[index].CodDocente.ToString();
                estut.Nombres = espera[index].Nombres.ToString();
                estut.ApellidoPaterno = espera[index].ApellidoPaterno.ToString() != null ? espera[index].ApellidoPaterno.ToString() : "";
                estut.ApellidoMaterno = espera[index].ApellidoMaterno.ToString() != null ? espera[index].ApellidoMaterno.ToString() : "";
                estut.Clase = espera[index].Clase.ToString() != null ? espera[index].Clase.ToString() : "";
                estut.Categoria = espera[index].Categoria.ToString() != null ? espera[index].Categoria.ToString() : "";
                estut.Regimen = espera[index].Regimen.ToString() != null ? espera[index].Regimen.ToString() : "";
                estut.EscuelaProfesional = espera[index].EscuelaProfesional.ToString() != null ? espera[index].EscuelaProfesional.ToString() : "";
                estut.CantidaEstudiantes = espera[index].CantidaEstudiantes.ToString() != null ? Convert.ToInt16(espera[index].CantidaEstudiantes.ToString().Trim()) : 0;
                if (estut != null)
                {
                    textEdit1.Text = estut.CodDocente;
                    DialogResult res = MessageBox.Show("¿Seguro que quieres Eliminar el registro " + estut.CodDocente + "?", "Advertencia", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        int ver = tutorfacade.Eliminar(estut.CodDocente.Trim());
                        if (ver > 0)
                        {
                            llenarGV();
                            MessageBox.Show("Reguistro Eliminado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            llenarGV();
                            MessageBox.Show("Registro No eliminado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
