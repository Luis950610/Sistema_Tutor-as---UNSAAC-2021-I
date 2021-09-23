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

namespace STutoria.DataObjects.Procesos
{
    public partial class FichaTutoriaDao
    {
        #region Atributos
        public Database Db;

        public string Nombre_Tabla;

        public string Campos_Busqueda;
        #endregion

        #region Constructores
        public FichaTutoriaDao()
        {
            Db = DatabaseFactory.CreateDatabase("Conexion");
            Nombre_Tabla = "FichaTutoria";
            Campos_Busqueda = "IDTutor,CodDocente,CodEstudiante,Semestre,Fecha,Descripcionl";
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

        public virtual CFichaTutoria getFichaTutor(DataRow dr)
        {
            return new CFichaTutoria(Convert.ToInt16(dr["IDTutoria"].ToString().Trim()), Convert.ToString(dr["CodDocente"]), Convert.ToString(dr["CodEstudiante"]), Convert.ToString(dr["Semestre"]), Convert.ToString(dr["Fecha"]), Convert.ToString(dr["Descripcion"]));
        }

        public virtual CFichaTutoria getFichaTutor(IDataReader dr)
        {
            return new CFichaTutoria(Convert.ToInt16(dr["IDTutoria"].ToString().Trim()), Convert.ToString(dr["CodDocente"]), Convert.ToString(dr["CodEstudiante"]), Convert.ToString(dr["Semestre"]), Convert.ToString(dr["Fecha"]), Convert.ToString(dr["Descripcion"]));
        }

        #region Metodos Principales
        public virtual bool Grabar(IList<CFichaTutoria> fichaturotia )
        {
            try
            {
                bool a = false;
                for (int i = 0; i < fichaturotia.Count; i++)
                {
                    using (DbCommand dbCmd = Db.GetStoredProcCommand("spu_FichaTutoria_Agregar"))
                    {
                        CFichaTutoria fichatutoria = new CFichaTutoria();
                        Db.AddInParameter(dbCmd, "CodDocente", DbType.String, fichaturotia[i].CodDocente);
                        Db.AddInParameter(dbCmd, "CodEstudiante", DbType.String, fichaturotia[i].CodEstudiantes);
                        Db.AddInParameter(dbCmd, "Semestre", DbType.String, fichaturotia[i].Semestre);
                        Db.AddInParameter(dbCmd, "Descripcion", DbType.String, fichaturotia[i].Descripcion);
                        // --- Ejecutando procedimiento almacenado
                        a = Db.ExecuteNonQuery(dbCmd) > 0;
                    }
                }
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            
        }

        public virtual int Eliminar(String CodDocente)
        {
            return Db.ExecuteNonQuery("spu_Docente_Eliminar", CodDocente);
        }

        public virtual IList<CFichaTutoria> RecuperarAsignacion()
        {
            using (IDataReader dr = Db.ExecuteReader("spu_FichaTutoria_ListaAsig"))
            {
                IList<CFichaTutoria> list = new List<CFichaTutoria>();
                while (dr.Read())
                    list.Add(getFichaTutor(dr));
                return list;
            }
        }
        
        public virtual IList<CFichaTutoria> Buscar(String IDTutoria, String CodDocente,String CodEstudiante)
        {
            using (IDataReader dr = Db.ExecuteReader("spu_Fichatutoria_Buscar", IDTutoria, CodDocente,CodEstudiante))
            {
                IList<CFichaTutoria> list = new List<CFichaTutoria>();
                while (dr.Read())
                    list.Add(getFichaTutor(dr));
                return list;
            }
        }
        public virtual bool Existe(String CodDocente)
        {
            DataTable dtDatos = Db.ExecuteDataSet("spu_Docente_Recuperar", CodDocente).Tables[0];
            return dtDatos.Rows.Count > 0;
        }

        public virtual bool Update(String IDTutoria,String Descripcion)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("spu_FichaTutoriaUpdate"))
            {
                Db.AddInParameter(dbCmd, "IDTutoria", DbType.Int16,Convert.ToUInt16(IDTutoria));
                Db.AddInParameter(dbCmd, "Descripcion", DbType.String, Descripcion);
                // --- Ejecutando procedimiento almacenado
                return Db.ExecuteNonQuery(dbCmd) > 0;
            }
        }

        #endregion
    }
}
