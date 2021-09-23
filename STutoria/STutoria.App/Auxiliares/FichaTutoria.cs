using STutoria.BusinessObjects.Mantenimientos;
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

namespace STutoria.App.Auxiliares
{
    public partial class FichaTutoria : Form
    {
        public CFichaTutoria recivir =new CFichaTutoria();
        public CFichaTutoria datos;
        public EstudianteFacade estudiantefacade;
        public DocenteFacade docentefacade;
        public FichaTutoria()
        {
            InitializeComponent();
            estudiantefacade = new EstudianteFacade();
            docentefacade = new DocenteFacade();
        }
        private void FichaTutoria_Load(object sender, EventArgs e)
        {
            datos = new CFichaTutoria();
            CEstudiante estudi = new CEstudiante();
            CDocente Docen = new CDocente();
            datos = recivir;
            estudi = estudiantefacade.Recuperar(datos.CodEstudiantes);
            Docen = docentefacade.Recuperar(datos.CodDocente);
            //asignamos Datos
            tCodest.Text = estudi.CodEstudiante;
            nombreest.Text = estudi.Nombres;
            apestud.Text = estudi.ApellidoPaterno;
            amestud.Text = estudi.ApellidoMaterno;
            conestud.Text = estudi.Condicion;
            cpestud.Text = estudi.Carreraprofesional;
            semestre.Text = datos.Semestre;
            //datos docente
            coddoc.Text = Docen.CodDocente;
            nombredoc.Text = Docen.Nombres;
            apdoc.Text = Docen.ApellidoPaterno;
            amdoc.Text = Docen.ApellidoMaterno;
            //datos generales
            fecha.Text = datos.Fecha;
            descripcion.Text = datos.Descripcion;


        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }
    }
}
