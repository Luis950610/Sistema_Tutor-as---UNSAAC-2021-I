using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using STutoria.BusinessObjects.Mantenimientos;
using STutoria.BusinessObjects.Procesos;

namespace STutoria.DataObjects.Mantenimientos
{
    public partial class TutorDao
    {
        #region Atributos
        public Database Db;

        public string Nombre_Tabla;

        public string Campos_Busqueda;
        #endregion

        #region Constructores
        public TutorDao()
        {
            Db = DatabaseFactory.CreateDatabase("Conexion");
            Nombre_Tabla = "Docente";
            Campos_Busqueda = "CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,EscuelaProfecional,CantidadEstudiantes";
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

        public virtual CTutor getTutor(DataRow dr)
        {
            return new CTutor(Convert.ToString(dr["CodDocente"]), Convert.ToString(dr["Nombres"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Clase"]), Convert.ToString(dr["Categoria"]), Convert.ToString(dr["Regimen"]), Convert.ToString(dr["EscuelaProfesional"]), Convert.ToInt16(dr["CantidadEstudiantes"]));
        }

        public virtual CTutor getTutor(IDataReader dr)
        {
            return new CTutor(Convert.ToString(dr["CodDocente"]), Convert.ToString(dr["Nombres"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Clase"]), Convert.ToString(dr["Categoria"]), Convert.ToString(dr["Regimen"]), Convert.ToString(dr["EscuelaProfesional"]), Convert.ToInt16(dr["CantidadEstudiantes"]));
        }

        #region Metodos Principales
        public virtual bool Grabar(CTutor oDocente)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("spu_Tutor_Agregar"))
            {
                Db.AddInParameter(dbCmd, "CodDocente", DbType.String, oDocente.CodDocente);
                Db.AddInParameter(dbCmd, "Nombres", DbType.String, oDocente.Nombres);
                Db.AddInParameter(dbCmd, "ApellidoPaterno", DbType.String, oDocente.ApellidoPaterno);
                Db.AddInParameter(dbCmd, "ApellidoMaterno", DbType.String, oDocente.ApellidoMaterno);
                Db.AddInParameter(dbCmd, "Clase", DbType.String, oDocente.Clase);
                Db.AddInParameter(dbCmd, "Categoria", DbType.String, oDocente.Categoria);
                Db.AddInParameter(dbCmd, "Regimen", DbType.String, oDocente.Regimen);
                Db.AddInParameter(dbCmd, "EscuelaProfecional", DbType.String, oDocente.EscuelaProfesional);
                Db.AddInParameter(dbCmd, "CantidadEstudiantes", DbType.Int16, oDocente.CantidaEstudiantes);
                // --- Ejecutando procedimiento almacenado
                return Db.ExecuteNonQuery(dbCmd) > 0;
            }
        }

        public virtual int Eliminar(String CodDocente)
        {
            return Db.ExecuteNonQuery("spu_Tutor_Eliminar", CodDocente);
        }

        public virtual CTutor Recuperar(String CodDocente)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Tutor_Recuperar", CodDocente).Tables[0];
            if (dtDatos.Rows.Count > 0)
                return getTutor(dtDatos.Rows[0]);
            else
                return new CTutor();
        }

        public virtual bool Existe(String CodDocente)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Tutor_Recuperar", CodDocente).Tables[0];
            return dtDatos.Rows.Count > 0;
        }

        public virtual bool Existe(String CodDocente, out CTutor oDocente)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Tutor_Recuperar", CodDocente).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                oDocente = getTutor(dtDatos.Rows[0]);
                return true;
            }
            else
            {
                oDocente = new CTutor();
                return false;
            }
        }

        public virtual IList<CTutor> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Tutor_Listar"))
            {
                IList<CTutor> list = new List<CTutor>();
                while (dr.Read())
                    list.Add(getTutor(dr));
                return list;
            }
        }

        public virtual IList<CTutor> ListarXPerfil(int IDPerfil)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Docente_ListarXPerfil", IDPerfil))
            {
                IList<CTutor> list = new List<CTutor>();
                while (dr.Read())
                    list.Add(getTutor(dr));
                return list;
            }
        }

        public virtual IList<CTutor> Buscar(String CodDocente, String Nombre)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Tutor_Buscar", CodDocente, Nombre))
            {
                IList<CTutor> list = new List<CTutor>();
                while (dr.Read())
                    list.Add(getTutor(dr));
                return list;
            }
        }
        //---
        #endregion
    }
}
