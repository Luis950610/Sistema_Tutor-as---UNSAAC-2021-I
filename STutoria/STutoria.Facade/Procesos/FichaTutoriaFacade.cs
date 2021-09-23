using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using STutoria.DataObjects.Seguridad;
using STutoria.BusinessObjects.Seguridad;
using STutoria.Libreria.Seguridad;
using System.Data;
using STutoria.DataObjects.Procesos;
using System.Collections.Generic;
using STutoria.BusinessObjects.Procesos;

namespace STutoria.Facade.Procesos
{
    [DataObject(true)]
    public partial class FichaTutoriaFacade
    {

        private FichaTutoriaDao fichatutoria;

        // --- Variables de control de errores 
        private string Error;

        private bool hayError;

        #region Constructores
        public FichaTutoriaFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default:
                    fichatutoria = new FichaTutoriaDao();
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
            return fichatutoria.getNombre_Tabla();
        }

        public virtual string getCampos_Busqueda()
        {
            return fichatutoria.getCampos_Busqueda();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(IList<CFichaTutoria> fichaturotia)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (fichaturotia.Count==0)
            {
                Error = "no hy datos.";
                hayError = true;
                return false;
            }
            else
                return fichatutoria.Grabar(fichaturotia);
        }
        public virtual bool Update(string IDTutoria, string Descripcion)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (IDTutoria == "")
            {
                Error = "no hy datos.";
                hayError = true;
                return false;
            }
            else
                return fichatutoria.Update(IDTutoria,Descripcion);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CFichaTutoria> RecuperarAsignacion()
        {
            return fichatutoria.RecuperarAsignacion();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CFichaTutoria> Buscar(string IDTutoria, string CodDocente,string CodEstudiante)
        {
            return fichatutoria.Buscar(IDTutoria, CodDocente,CodEstudiante);
        }
        #endregion
    }
}
