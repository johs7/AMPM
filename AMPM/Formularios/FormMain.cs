using AMPM.clases;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace AMPM.Formularios
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        ClassProduct produ=new clases.ClassProduct();
   

        private void pbxRegUsuarios_Click(object sender, EventArgs e)
        {
            FormProductos formu = new FormProductos();
            formu.ShowDialog();
        }
        int y,x;
        private void FormMain_Load(object sender, EventArgs e)
        {
            ClassProduct cp = new ClassProduct();
            var productos = cp.Listar();
            foreach (var producto in productos)
            {
                Guna.UI2.WinForms.Suite.PictureBox pictureBox = new Guna.UI2.WinForms.Suite.PictureBox();
                pictureBox.Location = new Point(x, y);
                pictureBox.Size = new Size(250, 250);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if (producto.img != null)
                {
                    using (var stream = new MemoryStream(producto.img))
                    {
                        pictureBox.Image = Image.FromStream(stream);
                    }
                }
                panel1.Controls.Add(pictureBox);

                Guna2Button boton = new Guna.UI2.WinForms.Guna2Button();
                boton.Text = "Ver opciones";
                boton.Location = new Point(x, y + pictureBox.Height);
                boton.Click += (botonClick, eventArgs) =>
                {
                    ClassOptions claseOpciones = new ClassOptions();
                    List<options> opcionesProducto = claseOpciones.ListarOpcionesProducto(producto.code);

                  

                    FormOptions formOptions = new FormOptions();
                    formOptions.DgvOptions.DataSource = opcionesProducto;
                    
                    formOptions.Show();

                };
                panel1.Controls.Add(boton);

                y += pictureBox.Height + boton.Height;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var nombre = txtBuscar.Text;
            var productos = produ.Listar().Where(p => p.nombre.Contains(nombre)).ToList();
            if (productos.Count > 0)
            {
                var producto = productos.First();
                if (producto.img != null)
                {
                    using (var stream = new MemoryStream(producto.img))
                    {
                      pbxFind.Image = Image.FromStream(stream);
                    }
                }
            }
            else
            {
                MessageBox.Show("Producto no encontrado.");
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            FormUsers formu = new FormUsers();
            formu.ShowDialog();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new AMPMEntities())
            {
                string selectedStatus = cmbEstado.SelectedItem.ToString();
                var products = from p in context.products
                               where p.estado == selectedStatus
                               select new { p.img, p.estado};
                DgvEstado.DataSource = products.ToList();
              
            }
        }

        private void DgvEstado_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvEstado.Rows)
            {
                row.Height = 90;
                
                DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)DgvEstado.Columns["img"];
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            }
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            FormOptions frm = new FormOptions();
            frm.ShowDialog();
        }

        private void boton_Click(object sender, EventArgs e)
        {

        }
    }
}
    
