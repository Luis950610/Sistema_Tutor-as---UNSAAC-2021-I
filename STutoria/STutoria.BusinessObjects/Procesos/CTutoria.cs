using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace STutoria.BusinessObjects.Procesos
{
    public partial class CTutoria
    {
        [DataMember()]
        public int IDTutoria { get; set; }

        [DataMember()]
        public String CodDocente { get; set; }

        [DataMember()]
        public String CodEstudiante { get; set; }

        [DataMember()]
        public String Semestre { get; set; }

        [DataMember()]
        public String Fecha { get; set; }

        #region Constructores
        // Constructores
        public CTutoria()
        {
        }

        public CTutoria(int IDTutoria_, String CodDocente_, String CodEstudiante_, String Semestre_, String Fecha_)
        {
            IDTutoria = IDTutoria_;
            CodDocente = CodDocente_;
            CodEstudiante = CodEstudiante_;
            Semestre = Semestre_;
            Fecha = Fecha_;
        }
        #endregion
    }
}
