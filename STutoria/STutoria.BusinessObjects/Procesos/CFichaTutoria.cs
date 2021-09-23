using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace STutoria.BusinessObjects.Procesos
{
    public partial class CFichaTutoria
    {
        [DataMember()]
        public int IDTutoria { get; set; }

        [DataMember()]
        public String CodDocente { get; set; }

        [DataMember()]
        public String CodEstudiantes { get; set; }

        [DataMember()]
        public String Semestre { get; set; }

        [DataMember()]
        public String Fecha { get; set; }

        [DataMember()]
        public String Descripcion { get; set; }

        #region Constructores
        // Constructores
        public CFichaTutoria()
        {
        }

        public CFichaTutoria(int IDTutoria_, String CodDocente_, String CodEstudiantes_, String Semestre_, String Fecha_, String Descripcion_)
        {
            IDTutoria = IDTutoria_;
            CodDocente = CodDocente_;
            CodEstudiantes = CodEstudiantes_;
            Semestre = Semestre_;
            Fecha = Fecha_;
            Descripcion = Descripcion_;
        }
        #endregion
    }
}
