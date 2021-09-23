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

    public partial class EstudianteDao
    {
        #region Atributos
        public Database Db;

        public string Nombre_Tabla;

        public string Campos_Busqueda;
        #endregion

        #region Constructores
        public EstudianteDao()
        {
            Db = DatabaseFactory.CreateDatabase("Conexion");
            Nombre_Tabla = "Estudiantes";
            Campos_Busqueda = "CodEstudiante, Nombres,ApellidoPaterno,ApellidoMaterno,CarreraProfecional,Condicion";
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

        public virtual CEstudiante getEstudiante(DataRow dr)
        {
            return new CEstudiante(Convert.ToString(dr["CodEstudiante"]), Convert.ToString(dr["Nombres"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["CarreraProfesional"]), Convert.ToString(dr["Condicion"]));
        }

        public virtual CEstudiante getEstudiante(IDataReader dr)
        {
            return new CEstudiante(Convert.ToString(dr["CodEstudiante"]), Convert.ToString(dr["Nombres"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["CarreraProfesional"]), Convert.ToString(dr["Condicion"]));
        }

        #region Metodos Principales
        public virtual bool Grabar(CEstudiante oEstudiante)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("spu_Estudiante_Agregar"))
            {
                Db.AddInParameter(dbCmd, "CodEstudiante", DbType.String, oEstudiante.CodEstudiante);
                Db.AddInParameter(dbCmd, "Nombres", DbType.String, oEstudiante.Nombres);
                Db.AddInParameter(dbCmd, "ApellidoPaterno", DbType.String, oEstudiante.ApellidoPaterno);
                Db.AddInParameter(dbCmd, "ApellidoMaterno", DbType.String, oEstudiante.ApellidoMaterno);
                Db.AddInParameter(dbCmd, "CarreraProfesional", DbType.String, oEstudiante.Carreraprofesional);
                Db.AddInParameter(dbCmd, "Condicion", DbType.String, oEstudiante.Condicion);
                // --- Ejecutando procedimiento almacenado
                return Db.ExecuteNonQuery(dbCmd) > 0;
            }
        }

        public virtual int Eliminar(String CodUsuario)
        {
            return Db.ExecuteNonQuery("[spu_Estudiante_Eliminar]", CodUsuario);
        }

        public virtual CEstudiante Recuperar(String CodUsuario)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Estudiante_Recuperar", CodUsuario).Tables[0];
            if (dtDatos.Rows.Count > 0)
                return getEstudiante(dtDatos.Rows[0]);
            else
                return new CEstudiante();
        }

        public virtual bool Existe(String CodUsuario)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Estudiante_Recuperar", CodUsuario).Tables[0];
            return dtDatos.Rows.Count > 0;
        }

        public virtual bool Existe(String CodUsuario, out CEstudiante oEstudiante)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Estudiante_Recuperar", CodUsuario).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                oEstudiante = getEstudiante(dtDatos.Rows[0]);
                return true;
            }
            else
            {
                oEstudiante = new CEstudiante();
                return false;
            }
        }

        public virtual IList<CEstudiante> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Estudiante_Listar"))
            {
                IList<CEstudiante> list = new List<CEstudiante>();
                while (dr.Read())
                    list.Add(getEstudiante(dr));
                return list;
            }
        }

        public virtual IList<CEstudiante> ListarEF()
        {
            using (IDataReader dr = Db.ExecuteReader("spu_FichaTutoria_Lista"))
            {
                IList<CEstudiante> list = new List<CEstudiante>();
                while (dr.Read())
                    list.Add(getEstudiante(dr));
                return list;
            }
        }

        public virtual IList<CEstudiante> ListarXPerfil(int IDPerfil)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Estudiante_ListarXPerfil", IDPerfil))
            {
                IList<CEstudiante> list = new List<CEstudiante>();
                while (dr.Read())
                    list.Add(getEstudiante(dr));
                return list;
            }
        }

        public virtual IList<CEstudiante> Buscar(String CodEstudiante, String Nombres)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Estudiante_Buscar", CodEstudiante, Nombres))
            {
                IList<CEstudiante> list = new List<CEstudiante>();
                while (dr.Read())
                    list.Add(getEstudiante(dr));
                return list;
            }
        }
        //---
        #endregion
    }
}
