using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace STutoria.BusinessObjects.Seguridad
{
    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class CUsuario
    {
        [DataMember()]
        public String CodUsuario { get; set; }

        public String Password { get; set; }


        [DataMember()]
        public String UserNew { get; set; }

        [DataMember()]
        public String UserEdit { get; set; }

        [DataMember()]
        public Char Tipo_Usuario { get; set; }

        #region Constructores
        // Constructores
        public CUsuario()
        {
        }

        public CUsuario(String CodUsuario_, String Password_, String UserNew_, String UserEdit_, Char Tipo_Usuario_)
        {
            CodUsuario = CodUsuario_;
            Password = Password_;
            UserNew = UserNew_;
            UserEdit = UserEdit_;
            Tipo_Usuario = Tipo_Usuario_;
        }
        #endregion
    }
}
