using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STutoria.Libreria.Seguridad
{
    public static class AplicacionBS
    {
        public static string Cod_Sistema;
        public static Estilo_App Estilo;
        public static string Ruta_Ayuda;
        public static TGestor_BD Gestor_BD;
        public static TAcceso_Modulo Ultimo_Tipo_Acceso;
        public static string Ultimo_CodAcceso;
        public static string Libreria_Imagenes;
        public static int Año;
        public static bool CargarEnVentanaMDI;
        public static string EndPointName;
        public static string Cod_Perfil;
        public static string Cod_Usuario;
        public static string RUC_Empresa;
        public static string Direccion_Empresa;
        public static string Nombre_Empresa;
        public static string Codigo_Empresa;
        public static string Nombre_Modulo;
        public static string Nombre_Sistema;
        public static string Cod_Sucursal;

        public enum Estilo_App : byte
        {
            Blue = 1,
            Black = 2
        }
        public enum TGestor_BD
        {
            SqlServer = 1,
            PostGres = 2,
            Oracle = 3
        }
        public enum TipoApp : byte
        {
            Web = 1,
            Windows = 2
        }
        public enum TAcceso_Modulo
        {
            Insertar_Modificar = 1,
            Insertar = 2,
            Lectura = 3,
            Sin_Acceso = 4
        }
    }
}
