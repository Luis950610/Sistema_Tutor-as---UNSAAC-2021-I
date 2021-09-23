using STutoria.App.Mantenimiento;
using STutoria.App.Padre;
using STutoria.BusinessObjects.Seguridad;
using STutoria.Facade.Seguridad;
using STutoria.Libreria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STutoria.App
{
    public partial class Login : Form
    {
        public CUsuario pasardata;
        public Login()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UsuarioFacade usuariofa = new UsuarioFacade();
            Encriptar_DeSencriptar cript = new Encriptar_DeSencriptar();
            CUsuario usuario = new CUsuario();
            if (username.Text != "" && Password.Text != "")
            {
               usuario = usuariofa.Recuperar(username.Text);
                if (usuario.CodUsuario != null)
                {
                    String Pass = cript.Encriptar(Password.Text.Trim());
                    if (Pass == usuario.Password)
                    {
                        
                        Padre.FormPadre padre_ = new Padre.FormPadre();
                        padre_.recivirdata = usuario;
                        padre_.Show();
                        this.Close();
                    }
                    else
                    {
                        Limpiar();
                        const string message = "Password Incorrecto";
                        const string caption = "ALerta";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                else
                {
                    Limpiar();
                    const string message = "Usuario no existe..";
                    const string caption = "Advertencia";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                const string message = "Ingrese Username y/o Password";
                const string caption = "Advertencia";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        public void Limpiar()
        {
            Password.EditValue = "";
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
