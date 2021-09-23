using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using STutoria.DataObjects.Mantenimientos;
using STutoria.BusinessObjects.Mantenimientos;
using STutoria.Libreria.Seguridad;

namespace STutoria.Facade.Mantenimiento
{
    [DataObject(true)]
    public partial class EstudianteFacade
    {

        private EstudianteDao estudiante;

        // --- Variables de control de errores 
        private string Error;

        private bool hayError;

        #region Constructores
        public EstudianteFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default:
                    estudiante = new EstudianteDao();
                    break;
            }
        }
        #endregion

        #region Metodos de Control de Errores
        public virtual string getError()
        {
            return Error;
        }

        public virtual bool HayError()
        {
            return hayError;
        }
        #endregion

        #region Metodos Basicos
        public virtual string getNombre_Tabla()
        {
            return estudiante.getNombre_Tabla();
        }

        public virtual string getCampos_Busqueda()
        {
            return estudiante.getCampos_Busqueda();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CEstudiante oEstudiante)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oEstudiante.CodEstudiante.Trim() == "")
            {
                Error = "CodEstudiante no puede ser vacío.";
                hayError = true;
                return false;
            }
            else
                return estudiante.Grabar(oEstudiante);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CEstudiante oEstudiante, out string error)
        {
            bool rpta = Grabar(oEstudiante);
            error = Error;
            return rpta;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String CodEstudiante)
        {
            return estudiante.Eliminar(CodEstudiante);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CEstudiante Recuperar(String CodEstudiante)
        {
            return estudiante.Recuperar(CodEstudiante);
        }
        #endregion

        #region Metodos Secundarios
        public virtual bool Existe(String CodEstudiante)
        {
            return estudiante.Existe(CodEstudiante);
        }

        public virtual bool Existe(String CodEstudiante, out CEstudiante oEstudiante)
        {
            return estudiante.Existe(CodEstudiante, out oEstudiante);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CEstudiante> Listar()
        {
            return estudiante.Listar();
        }
        public virtual IList<CEstudiante> ListarEF()
        {
            return estudiante.ListarEF();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CEstudiante> ListarXPerfil(int IDPerfil)
        {
            return estudiante.ListarXPerfil(IDPerfil);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CEstudiante> Buscar(String CodEstudiante,String Nombres)
        {
            return estudiante.Buscar(CodEstudiante,Nombres);
        }
        #endregion
    }
}
