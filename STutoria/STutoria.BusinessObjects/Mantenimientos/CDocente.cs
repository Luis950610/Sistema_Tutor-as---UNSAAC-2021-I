using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace STutoria.BusinessObjects.Mantenimientos
{
    public partial class CDocente
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

        public String CarreraProfesional { get; set; }

        #region Constructores
        // Constructores
        public CDocente()
        {
        }

        public CDocente(String CodDocente_, String Nombres_, String ApellidoPaterno_, String ApellidoMaterno_, String Clase_, String Categoria_, String Regimen_, String CarreraProfesional_)
        {
            CodDocente = CodDocente_;
            Nombres = Nombres_;
            ApellidoPaterno = ApellidoPaterno_;
            ApellidoMaterno = ApellidoMaterno_;
            Clase = Clase_;
            Categoria = Categoria_;
            Regimen = Regimen_;
            CarreraProfesional = CarreraProfesional_;
        }
        #endregion
    }
}
