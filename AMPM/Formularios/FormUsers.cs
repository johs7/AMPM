using AMPM.clases;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMPM.Formularios
{
    public partial class FormUsers : Form
    {
        clases.ClassUsers us = new clases.ClassUsers();
        public FormUsers()
        {
            InitializeComponent();
        }
        public void CargarDatos()
        {
            List<users> listaFabricantes = us.Listar();
            DgvUsers.DataSource = listaFabricantes;
        }
        public static void SoloLetras(KeyPressEventArgs v)
        {
            if (char.IsLetter(v.KeyChar))
            {

                v.Handled = false;
            }
            else if (char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
                MessageBox.Show("Espacios no permitidos");
            }
            else if (char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {

                v.Handled = true;
                MessageBox.Show("Digite solo letras porfavor");

            }
        }

        public static void SoloNumeros(KeyPressEventArgs v)
        {

            if (char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (char.IsSeparator(v.KeyChar))
            {

                v.Handled = false;
            }
            else if (char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {

                v.Handled = true;
                MessageBox.Show("Digite solo números porfavor");
            }
        }
        private bool ValidarCampo(Guna2TextBox control, string mensajeError)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                ERROR.SetError(control, mensajeError);
                return false;
            }
            else
            {
               ERROR.SetError(control, "");
                return true;
            }
        }
        private bool ValidarUsuario()
        {
            return ValidarCampo(txtUser, "Debe escribir el usuario");
        }
        private bool ValidarContraseña()
        {
            return ValidarCampo(txtPass, "Debe escribir la contraseña del usuario");
        }
        private bool ValidarNombre()
        {
            return ValidarCampo(txtNom, "Debe escribir el nombre del usuario");
        }
        private bool ValidarApe()
        {
            return ValidarCampo(txtApe, "Debe escribir el apellido del usuario");
        }
        private bool ValidarCorreo()
        {
            return ValidarCampo(txtCorreo, "Debe escribir el correo del usuario");
        }
        private bool ValidarTelefono()
        {
            return ValidarCampo(txtTel, "Debe escribir el telefono del vendedor");
        }
        public static bool ValidarFormatoCorreo(string comprobarEmail)
        {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool ValidarFormatoTelefono(string comprobarTelefono)
        {
            string telefonoFormato;
            telefonoFormato = "^\\d{4}-\\d{4}$";
            if (Regex.IsMatch(comprobarTelefono, telefonoFormato))
            {
                if (Regex.Replace(comprobarTelefono, telefonoFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private new users Update()
        {
            string id = txtBuscar.Text;
           users user = us.Buscar(id);
            if (id != "")
                return user;
            else
                return null;
        }


        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarNombre() == false)
                { return; }
                if (ValidarUsuario() == false)
                { return; }
                if (ValidarContraseña() == false)
                { return; }
                if (ValidarApe() == false)
                { return; }
                if (ValidarCorreo() == false)
                { return; }
                if (ValidarTelefono() == false)
                { return; }

                if (ValidarFormatoCorreo(txtCorreo.Text) == false)
                {
                   ERROR.SetError(txtCorreo, "Debe Escribir Una dirrecion correcta");
                    return;
                }
                if (ValidarFormatoTelefono(txtTel.Text) == false)
                {
                    ERROR.SetError(txtTel, "Debe Escribir Un formato correcto");
                    return;
                }
                users user = new users();
                user.username = txtUser.Text;
                user.password = txtPass.Text;
                user.name = txtNom.Text;
                user.last_name = txtApe.Text;
                user.email = txtCorreo.Text;
                user.phone = txtTel.Text;
                user.creation_date = DateTime.Now;
                if (us.Guardar(user) == true)
                {
                    MessageBox.Show("registrado");
                    CargarDatos();
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

    

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Update() != null)
                {
                    
                    users user = Update();
                    user.username = txtUser.Text;
                    user.password = txtPass.Text;
                    user.name = txtNom.Text;
                    user.last_name = txtApe.Text;
                    user.email = txtCorreo.Text;
                    user.phone = txtTel.Text;
                    user.creation_date = DateTime.Now;
                    if (us.Modificar(user) == true)
                    {
                        MessageBox.Show("actualizado");
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("no actualizado");
                    }
                }
            }
            catch
            {
                MessageBox.Show(" no actualizado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ClassUsers classUsers = new ClassUsers();
                users usuario = classUsers.Buscar(txtUser.Text);

                if (usuario != null)
                {
                    if (classUsers.Eliminar(usuario))
                    {
                        MessageBox.Show("El usuario ha sido eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();

                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no fue encontrado.", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void txtApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                users usuario = us.Buscar(txtBuscar.Text);
                if (usuario != null)
                {
                    txtUser.Text = usuario.username;
                    txtPass.Text = usuario.password;
                    txtNom.Text = usuario.name;
                    txtApe.Text = usuario.last_name;
                    txtCorreo.Text = usuario.email;
                    txtTel.Text = usuario.phone;

                }
                else
                {
                    MessageBox.Show("no encontrado");
                }

            }
            catch
            {
                MessageBox.Show("no encontrado");
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}