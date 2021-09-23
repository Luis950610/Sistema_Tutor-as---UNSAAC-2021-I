using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace STutoria.BusinessObjects.Procesos
{
    public partial class CTutor
    {
        [DataMember()]
        public String CodDocente { get; set; }

        [DataMember()]
        public String Nombres { get; set; }

        [DataMember()]
        public String ApellidoPaterno { get; set; }

        [DataMember()]
        public String ApellidoMaterno { get; set; }

        [DataMember()]
        public String Clase { get; set; }

        [DataMember()]
        public String Categoria { get; set; }

        [DataMember()]
        public String Regimen { get; set; }

        [DataMember()]
        public String EscuelaProfesional { get; set; }

        [DataMember()]
        public int CantidaEstudiantes { get; set; }

        #region Constructores
        // Constructores
        public CTutor()
        {
        }

        public CTutor(String CodDocente_, String Nombres_, String ApellidoPaterno_, String ApellidoMaterno_, String Clase_, String Categoria_, String Regimen_, String EscuelaProfesional_,int CantidaEstudiantes_)
        {
            CodDocente = CodDocente_;
            Nombres = Nombres_;
            ApellidoPaterno = ApellidoPaterno_;
            ApellidoMaterno = ApellidoMaterno_;
            Clase = Clase_;
            Categoria = Categoria_;
            Regimen = Regimen_;
            EscuelaProfesional = EscuelaProfesional_;
            CantidaEstudiantes = CantidaEstudiantes_;
        }
        #endregion
    }
}
