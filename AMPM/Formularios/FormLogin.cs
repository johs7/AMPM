using AMPM.clases;
using AMPM.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMPM
{
    public partial class FormLogin : Form
    {
        ClassUsers usuario = new ClassUsers();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtUser.Text;
                string pass = txtPass.Text;
                if (usuario.Verificar(name, pass))
                {
                   
                    Formularios.FormMain obj = new Formularios.FormMain();
                    obj.ShowDialog();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            FormUsers formu = new FormUsers();
            formu.ShowDialog();
        }
    }
}
