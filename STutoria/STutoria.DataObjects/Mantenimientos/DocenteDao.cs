using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using STutoria.BusinessObjects.Mantenimientos;

namespace STutoria.DataObjects.Mantenimientos
{
    public partial class DocenteDao
    {
        #region Atributos
        public Database Db;

        public string Nombre_Tabla;

        public string Campos_Busqueda;
        #endregion

        #region Constructores
        public DocenteDao()
        {
            Db = DatabaseFactory.CreateDatabase("Conexion");
            Nombre_Tabla = "Docente";
            Campos_Busqueda = "CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,CarreraProfecional";
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

        public virtual CDocente getDocente(DataRow dr)
        {
            return new CDocente(Convert.ToString(dr["CodDocente"]), Convert.ToString(dr["Nombres"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Clase"]), Convert.ToString(dr["Categoria"]), Convert.ToString(dr["Regimen"]), Convert.ToString(dr["CarreraProfesional"]));
        }

        public virtual CDocente getDocente(IDataReader dr)
        {
            return new CDocente(Convert.ToString(dr["CodDocente"]), Convert.ToString(dr["Nombres"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Clase"]), Convert.ToString(dr["Categoria"]), Convert.ToString(dr["Regimen"]), Convert.ToString(dr["CarreraProfesional"]));
        }

        #region Metodos Principales
        public virtual bool Grabar(CDocente oDocente)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("spu_Docente_Agregar"))
            {
                Db.AddInParameter(dbCmd, "CodDocente", DbType.String, oDocente.CodDocente);
                Db.AddInParameter(dbCmd, "Nombres", DbType.String, oDocente.Nombres);
                Db.AddInParameter(dbCmd, "ApellidoPaterno", DbType.String, oDocente.ApellidoPaterno);
                Db.AddInParameter(dbCmd, "ApellidoMaterno", DbType.String, oDocente.ApellidoMaterno);
                Db.AddInParameter(dbCmd, "Clase", DbType.String, oDocente.Clase);
                Db.AddInParameter(dbCmd, "Categoria", DbType.String, oDocente.Categoria);
                Db.AddInParameter(dbCmd, "Regimen", DbType.String, oDocente.Regimen);
                Db.AddInParameter(dbCmd, "CarreraProfesional", DbType.String, oDocente.CarreraProfesional);
                // --- Ejecutando procedimiento almacenado
                return Db.ExecuteNonQuery(dbCmd) > 0;
            }
        }

        public virtual int Eliminar(String CodDocente)
        {
            return Db.ExecuteNonQuery("spu_Docente_Eliminar", CodDocente);
        }

        public virtual CDocente Recuperar(String CodDocente)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Docente_Recuperar", CodDocente).Tables[0];
            if (dtDatos.Rows.Count > 0)
                return getDocente(dtDatos.Rows[0]);
            else
                return new CDocente();
        }

        public virtual bool Existe(String CodDocente)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Docente_Recuperar", CodDocente).Tables[0];
            return dtDatos.Rows.Count > 0;
        }

        public virtual bool Existe(String CodDocente, out CDocente oDocente)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Docente_Recuperar", CodDocente).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                oDocente = getDocente(dtDatos.Rows[0]);
                return true;
            }
            else
            {
                oDocente = new CDocente();
                return false;
            }
        }

        public virtual IList<CDocente> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Docente_Listar"))
            {
                IList<CDocente> list = new List<CDocente>();
                while (dr.Read())
                    list.Add(getDocente(dr));
                return list;
            }
        }

        public virtual IList<CDocente> ListarXPerfil(int IDPerfil)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Docente_ListarXPerfil", IDPerfil))
            {
                IList<CDocente> list = new List<CDocente>();
                while (dr.Read())
                    list.Add(getDocente(dr));
                return list;
            }
        }

        public virtual IList<CDocente> Buscar(String CodDocente,String Nombre)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Docente_Buscar", CodDocente,Nombre))
            {
                IList<CDocente> list = new List<CDocente>();
                while (dr.Read())
                    list.Add(getDocente(dr));
                return list;
            }
        }
        //---
        #endregion
    }
}
