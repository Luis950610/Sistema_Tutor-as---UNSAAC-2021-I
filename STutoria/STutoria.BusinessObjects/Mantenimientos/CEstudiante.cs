using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace STutoria.BusinessObjects.Mantenimientos
{
    [DataContract()]
    [Serializable()]
    public partial class CEstudiante
    {
        [DataMember()]
        public String CodEstudiante { get; set; }

        [DataMember()]
        public String Nombres { get; set; }

        [DataMember()]
        public String ApellidoPaterno { get; set; }

        [DataMember()]
        public String ApellidoMaterno { get; set; }

        [DataMember()]
        public String Carreraprofesional { get; set; }
        [DataMember()]
        public String Condicion { get; set; }

        #region Constructores
        // Constructores
        public CEstudiante()
        {
        }

        public CEstudiante(String CodEstudiante_, String Nombres_, String ApellidoPaterno_, String ApellidoMaterno_, String Carreraprofesional_, String Condicion_)
        {
            CodEstudiante = CodEstudiante_;
            Nombres = Nombres_;
            ApellidoPaterno = ApellidoPaterno_;
            ApellidoMaterno = ApellidoMaterno_;
            Carreraprofesional = Carreraprofesional_;
            Condicion = Condicion_;
        }
        #endregion
    }
}
