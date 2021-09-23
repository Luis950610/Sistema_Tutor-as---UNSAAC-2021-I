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
    public partial class DocenteFacade
    {

        private DocenteDao docente;

        // --- Variables de control de errores 
        private string Error;

        private bool hayError;

        #region Constructores
        public DocenteFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default:
                    docente = new DocenteDao();
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
            return docente.getNombre_Tabla();
        }

        public virtual string getCampos_Busqueda()
        {
            return docente.getCampos_Busqueda();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CDocente oDocente)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oDocente.CodDocente.Trim() == "")
            {
                Error = "CodDocente no puede ser vacío.";
                hayError = true;
                return false;
            }
            else
                return docente.Grabar(oDocente);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CDocente oDocente, out string error)
        {
            bool rpta = Grabar(oDocente);
            error = Error;
            return rpta;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String CodEstudiante)
        {
            return docente.Eliminar(CodEstudiante);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CDocente Recuperar(String CodDocente)
        {
            return docente.Recuperar(CodDocente);
        }
        #endregion

        #region Metodos Secundarios
        public virtual bool Existe(String CodDocente)
        {
            return docente.Existe(CodDocente);
        }

        public virtual bool Existe(String CodDocente, out CDocente oDocente)
        {
            return docente.Existe(CodDocente, out oDocente);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CDocente> Listar()
        {
            return docente.Listar();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CDocente> ListarXPerfil(int IDPerfil)
        {
            return docente.ListarXPerfil(IDPerfil);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CDocente> Buscar(String CodDocente, String Nombres)
        {
            return docente.Buscar(CodDocente, Nombres);
        }
        #endregion
    }
}
