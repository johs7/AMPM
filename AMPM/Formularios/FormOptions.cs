using AMPM.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMPM.Formularios
{
    public partial class FormOptions : Form
    {
        ClassOptions opt = new ClassOptions();
        public FormOptions()
        {
            InitializeComponent();


        }
        public DataGridView DgvOptions2;

        private void btnReg_Click(object sender, EventArgs e)
        {
            options op = new options();
            op.name = txtNom.Text;
            op.product_code = int.Parse(txtCodigo.Text);
            op.status = cmbEstado.ToString();
            if (opt.Guardar(op) == true)
            {
                MessageBox.Show("guardado");
            }


        }
    }
    
}
