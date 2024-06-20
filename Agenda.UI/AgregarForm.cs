using Agenda.BL;
using ML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda.UI
{
    public partial class AgregarForm : Form
    {
        ContactoBL contexto = new ContactoBL();
        public AgregarForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Contacto contacto = new Contacto
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Direccion = txtDireccion.Text,
                Genero = cmbGenero.SelectedItem.ToString(),
                EstadoCivil = cmbEstadoCivil.SelectedItem.ToString(),
                Movil = txtMovil.Text,
                Telefono = txtTelefono.Text,
                CorreoElectronico = txtCorreoElectronico.Text

            };
            contexto.InsertarContacto(contacto);
            this.LimpiarControles();
            MessageBox.Show("Contacto insertado con éxito.");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }


        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            txtDireccion.Clear();
            cmbGenero.SelectedIndex = -1;
            cmbEstadoCivil.SelectedIndex = -1;
            txtMovil.Clear();
            txtTelefono.Clear();
            txtCorreoElectronico.Clear();
        }

        //public void CargarDatos()
        //{
        //    List<Contacto> listaContactos = contactoBL.GetContactos();
        //    dgvContacto.DataSource = listaContactos;
        //}
    }
}
