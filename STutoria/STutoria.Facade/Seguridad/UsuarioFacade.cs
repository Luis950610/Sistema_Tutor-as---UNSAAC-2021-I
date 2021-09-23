using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using STutoria.DataObjects.Seguridad;
using STutoria.BusinessObjects.Seguridad;
using STutoria.Libreria.Seguridad;
using System.Data;

namespace STutoria.Facade.Seguridad
{
    [DataObject(true)]
    public partial class UsuarioFacade
    {

        private UsuarioDao usuario;

        // --- Variables de control de errores 
        private string Error;

        private bool hayError;

        #region Constructores
        public UsuarioFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default:
                    usuario = new UsuarioDao();
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
            return usuario.getNombre_Tabla();
        }

        public virtual string getCampos_Busqueda()
        {
            return usuario.getCampos_Busqueda();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CUsuario oUsuario)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oUsuario.CodUsuario.Trim() == "")
            {
                Error = "CodUsuario no puede ser vacío.";
                hayError = true;
                return false;
            }
            else
                return usuario.Grabar(oUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CUsuario oUsuario, out string error)
        {
            bool rpta = Grabar(oUsuario);
            error = Error;
            return rpta;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String CodUsuario)
        {
            return usuario.Eliminar(CodUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CUsuario Recuperar(String CodUsuario)
        {
            return usuario.Recuperar(CodUsuario);
        }
        #endregion

        #region Metodos Secundarios
        public virtual bool Existe(String CodUsuario)
        {
            return usuario.Existe(CodUsuario);
        }

        public virtual bool Existe(String CodUsuario, out CUsuario oUsuario)
        {
            return usuario.Existe(CodUsuario, out oUsuario);
        }

        public bool ExisteXPersonal(String IDPersonal, out CUsuario oUsuario)
        {
            return usuario.ExisteXPersonal(IDPersonal, out oUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CUsuario> Listar()
        {
            return usuario.Listar();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CUsuario> ListarXPerfil(int IDPerfil)
        {
            return usuario.ListarXPerfil(IDPerfil);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CUsuario> Buscar(String Codigo, String Nombre)
        {
            return usuario.Buscar(Codigo);
        }

        #endregion
    }
}
