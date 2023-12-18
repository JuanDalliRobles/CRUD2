using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ClaseDatos datos = new ClaseDatos();
        tabla_usuarios usuario = new tabla_usuarios();
        private int ID;
        private void CargarDGV()
        {
            var Lst = new ClaseDatos().Read();
            dgvUsuarios.DataSource = Lst;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDGV();
        }
        private void CargarDatos()
        {
            usuario.ID = ID;
            usuario.Nombre = textBoxNombre.Text;
            usuario.Edad = int.Parse(textBoxEdad.Text);
        }
        private void Limpiar()
        {
            ID = 0;
            textBoxNombre.Focus();
            textBoxNombre.Text = string.Empty;
            textBoxEdad.Focus();
            textBoxEdad.Text = string.Empty;
            CargarDGV();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(textBoxEdad.Text))
            {
                MessageBox.Show("Llena los campos para poder añadir un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CargarDatos();
                datos.Create(usuario);
                MessageBox.Show("Agregaste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
                
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                CargarDatos();
                datos.Update(usuario);
                MessageBox.Show("Editaste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleciona un registro para editar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value.ToString());
            textBoxNombre.Text = (dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString());
            textBoxEdad.Text = (dgvUsuarios.CurrentRow.Cells["Edad"].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                CargarDatos();
                datos.Delete(ID);
                MessageBox.Show("Eliminaste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleciona un registro para editar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            if(textBoxBuscarID.Text != string.Empty)
            {
                var Lst = datos.BuscarID(Convert.ToInt32(textBoxBuscarID.Text));
                dgvUsuarios.DataSource = Lst;
            }
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            if (textBoxBuscarNombre.Text != string.Empty)
            {
                var Lst = datos.BuscarNombre(textBoxBuscarNombre.Text);
                dgvUsuarios.DataSource = Lst;
            }
            else
            {
                CargarDGV();
            }
        }
    }
}
