using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using STutoria.BusinessObjects.Mantenimientos;
using STutoria.BusinessObjects.Seguridad;
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
    public partial class Estudiante : Form
    {
        public CUsuario recivirdata = new CUsuario();
        public CUsuario usuario;
        public IList<CEstudiante> espera = new List<CEstudiante>();
        public EstudianteFacade estudiantefacade;

        public Estudiante()
        {
            InitializeComponent();
            estudiantefacade = new EstudianteFacade();
            llenarGV();
        }

        private void Estudiante_Load(object sender, EventArgs e)
        {
            usuario = recivirdata;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedTabPage = xtraTabPage1;
            Limpiar();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //recuperamos datos 
                espera = estudiantefacade.Buscar(textEdit6.Text, textEdit7.Text);
                if (espera.Count > 0)
                {
                    gcEstudiantes.DataSource = espera;
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
   
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Data()
        {
            try
            {
                //recuperamos datos 
                espera = estudiantefacade.Buscar(textEdit1.Text,textEdit2.Text);
                if (espera.Count > 0)
                {
                    gcEstudiantes.DataSource = espera;
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
        public void llenarGV()
        {
            try
            {
                //recuperamos datos 
                espera = estudiantefacade.Listar();
                if (espera.Count > 0)
                {
                    gcEstudiantes.DataSource = espera;
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

        public String columnapasar;
        private void gcEstudiantes_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                GridView gv = gcEstudiantes.MainView as GridView;
                GridView view = (sender as GridControl).FocusedView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                int index = hitInfo.RowHandle;
                if (hitInfo.Column != null)
                {
                    columnapasar = hitInfo.Column.ToString();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                CEstudiante estut = new CEstudiante();
                var gv = gcEstudiantes.MainView as GridView;
                int index = gv.FocusedRowHandle;
                estut.CodEstudiante= espera[index].CodEstudiante.ToString();
                estut.Nombres = espera[index].Nombres.ToString();
                estut.ApellidoPaterno = espera[index].ApellidoPaterno.ToString() != null? espera[index].ApellidoPaterno.ToString() :"";
                estut.ApellidoMaterno = espera[index].ApellidoMaterno.ToString() != null ? espera[index].ApellidoMaterno.ToString() : "";
                estut.Carreraprofesional = espera[index].Carreraprofesional.ToString() != null ? espera[index].Carreraprofesional.ToString() : "";
                estut.Condicion = espera[index].Condicion.ToString() != null ? espera[index].Condicion.ToString() : "";
                if (estut != null)
                {
                    this.xtraTabControl1.SelectedTabPage = xtraTabPage1;
                    textEdit1.Text = estut.CodEstudiante;
                    textEdit2.Text = estut.Nombres;
                    textEdit3.Text = estut.ApellidoPaterno;
                    textEdit4.Text = estut.ApellidoMaterno;
                    textEdit5.Text = estut.Carreraprofesional;
                    textEdit8.Text = estut.Condicion;

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
            CEstudiante estut = new CEstudiante();
            var gv = gcEstudiantes.MainView as GridView;
            int index = gv.FocusedRowHandle;
            estut.CodEstudiante = espera[index].CodEstudiante.ToString();
            estut.Nombres = espera[index].Nombres.ToString();
            estut.ApellidoPaterno = espera[index].ApellidoPaterno.ToString() != null ? espera[index].ApellidoPaterno.ToString() : "";
            estut.ApellidoMaterno = espera[index].ApellidoMaterno.ToString() != null ? espera[index].ApellidoMaterno.ToString() : "";
            estut.Carreraprofesional = espera[index].Carreraprofesional.ToString() != null ? espera[index].Carreraprofesional.ToString() : "";
            estut.Condicion = espera[index].Condicion.ToString() != null ? espera[index].Condicion.ToString() : "";
            if (estut != null)
            {
                textEdit1.Text = estut.CodEstudiante;
                DialogResult res = MessageBox.Show("¿Seguro que quieres Eliminar el registro "+estut.CodEstudiante+"?", "Advertencia", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    int ver = estudiantefacade.Eliminar(estut.CodEstudiante.Trim());
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
        public void Limpiar()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit8.Text = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit1.Text != "" && textEdit2.Text != ""  && textEdit3.Text != "" && textEdit4.Text != "" && textEdit5.Text != "" && textEdit8.Text != "")
                {
                    CEstudiante datos = new CEstudiante();
                    datos.CodEstudiante = textEdit1.Text ;
                    datos.Nombres = textEdit2.Text ;
                    datos.ApellidoPaterno = textEdit3.Text ;
                    datos.ApellidoMaterno = textEdit4.Text ;
                    datos.Carreraprofesional = textEdit5.Text ;
                    datos.Condicion = textEdit8.Text ;
                    if (estudiantefacade.Grabar(datos))
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
                    MessageBox.Show("LLene todo los Datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            textEdit6.Text = "";
            textEdit7.Text = "";
            llenarGV();
        }

        
    }
}
