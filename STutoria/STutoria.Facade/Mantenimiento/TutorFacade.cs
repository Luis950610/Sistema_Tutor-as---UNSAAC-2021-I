using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using STutoria.DataObjects.Mantenimientos;
using STutoria.BusinessObjects.Mantenimientos;
using STutoria.Libreria.Seguridad;
using STutoria.BusinessObjects.Procesos;

namespace STutoria.Facade.Mantenimiento
{
    [DataObject(true)]
    public partial class TutorFacade
    {

        private TutorDao tutor;

        // --- Variables de control de errores 
        private string Error;

        private bool hayError;

        #region Constructores
        public TutorFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default:
                    tutor = new TutorDao();
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
            return tutor.getNombre_Tabla();
        }

        public virtual string getCampos_Busqueda()
        {
            return tutor.getCampos_Busqueda();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CTutor oDocente)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oDocente.CodDocente.Trim() == "")
            {
                Error = "CodTutor no puede ser vacío.";
                hayError = true;
                return false;
            }
            else
                return tutor.Grabar(oDocente);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CTutor oDocente, out string error)
        {
            bool rpta = Grabar(oDocente);
            error = Error;
            return rpta;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String CodEstudiante)
        {
            return tutor.Eliminar(CodEstudiante);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CTutor Recuperar(String CodDocente)
        {
            return tutor.Recuperar(CodDocente);
        }
        #endregion

        #region Metodos Secundarios
        public virtual bool Existe(String CodDocente)
        {
            return tutor.Existe(CodDocente);
        }

        public virtual bool Existe(String CodDocente, out CTutor oTutor)
        {
            return tutor.Existe(CodDocente, out oTutor);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CTutor> Listar()
        {
            return tutor.Listar();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CTutor> ListarXPerfil(int IDPerfil)
        {
            return tutor.ListarXPerfil(IDPerfil);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CTutor> Buscar(String CodDocente, String Nombres)
        {
            return tutor.Buscar(CodDocente, Nombres);
        }
        #endregion
    }
}
