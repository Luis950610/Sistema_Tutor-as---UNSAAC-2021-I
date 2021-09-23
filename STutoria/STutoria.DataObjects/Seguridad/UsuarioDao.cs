using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using STutoria.BusinessObjects.Seguridad;

namespace STutoria.DataObjects.Seguridad
{
    public partial class UsuarioDao
    {
        #region Atributos
        public Database Db;

        public string Nombre_Tabla;

        public string Campos_Busqueda;
        #endregion

        #region Constructores
        public UsuarioDao()
        {
            Db = DatabaseFactory.CreateDatabase("Conexion");
            Nombre_Tabla = "Usuario";
            Campos_Busqueda = "CodUsuario,Hash,UserNew,UserEdit,Tipo_Usuario";
        }
        #endregion

        public virtual string getNombre_Tabla()
        {
            return Nombre_Tabla;
        }

        public virtual string getCampos_Busqueda()
        {
            return Campos_Busqueda;
        }

        public virtual CUsuario getUsuario(DataRow dr)
        {
            return new CUsuario(Convert.ToString(dr["CodUsuario"]), Convert.ToString(dr["Hash"]), Convert.ToString(dr["UserNew"]), Convert.ToString(dr["UserEdit"]), Convert.ToChar(dr["TipoUser"]));
        }

        public virtual CUsuario getUsuario(IDataReader dr)
        {
            return new CUsuario(Convert.ToString(dr["CodUsuario"]), Convert.ToString(dr["Hash"]), Convert.ToString(dr["UserNew"]), Convert.ToString(dr["UserEdit"]), Convert.ToChar(dr["TipoUser"]));
        }

        #region Metodos Principales
        public virtual bool Grabar(CUsuario oUsuario)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("spu_Usuario_Guardar"))
            {
                Db.AddInParameter(dbCmd, "CodUsuario", DbType.String, oUsuario.CodUsuario);
                Db.AddInParameter(dbCmd, "Hash", DbType.String, oUsuario.Password);
                Db.AddInParameter(dbCmd, "UserNew", DbType.String, oUsuario.UserNew);
                Db.AddInParameter(dbCmd, "UserEdit", DbType.String, oUsuario.UserEdit);
                Db.AddInParameter(dbCmd, "Tipo_Usuario", DbType.String, oUsuario.Tipo_Usuario);

                // --- Ejecutando procedimiento almacenado
                return Db.ExecuteNonQuery(dbCmd) > 0;
            }
        }

        public virtual int Eliminar(String CodUsuario)
        {
            return Db.ExecuteNonQuery("spu_Usuario_Eliminar", CodUsuario);
        }

        public virtual CUsuario Recuperar(String CodUsuario)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Usuario_Recuperar", CodUsuario).Tables[0];
            if (dtDatos.Rows.Count > 0)
                return getUsuario(dtDatos.Rows[0]);
            else
                return new CUsuario();
        }

        public virtual bool Existe(String CodUsuario)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Usuario_Recuperar", CodUsuario).Tables[0];
            return dtDatos.Rows.Count > 0;
        }

        public virtual bool Existe(String CodUsuario, out CUsuario oUsuario)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Usuario_Recuperar", CodUsuario).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                oUsuario = getUsuario(dtDatos.Rows[0]);
                return true;
            }
            else
            {
                oUsuario = new CUsuario();
                return false;
            }
        }

        public bool ExisteXPersonal(String IDPersonal, out CUsuario oUsuario)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Usuario_RecuperarXPersonal", IDPersonal).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                oUsuario = getUsuario(dtDatos.Rows[0]);
                return true;
            }
            else
            {
                oUsuario = new CUsuario();
                return false;
            }
        }

        public virtual IList<CUsuario> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Usuario_Listar"))
            {
                IList<CUsuario> list = new List<CUsuario>();
                while (dr.Read())
                    list.Add(getUsuario(dr));
                return list;
            }
        }

        public virtual IList<CUsuario> ListarXPerfil(int IDPerfil)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Usuario_ListarXPerfil", IDPerfil))
            {
                IList<CUsuario> list = new List<CUsuario>();
                while (dr.Read())
                    list.Add(getUsuario(dr));
                return list;
            }
        }

        public virtual IList<CUsuario> Buscar(String Codigo)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Usuario_Buscar", Codigo))
            {
                IList<CUsuario> list = new List<CUsuario>();
                while (dr.Read())
                    list.Add(getUsuario(dr));
                return list;
            }
        }
        public virtual DataTable RecuperarUsuario()
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_MaxFT").Tables[0];
            string sql = "exec spu_MaxFT";
            return Db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        //---
        #endregion
    }
}
