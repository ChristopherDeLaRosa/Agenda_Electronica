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
    public partial class ModificarForm : Form
    {
        private Contacto contacto;

        public ModificarForm(Contacto contacto)
        {
            InitializeComponent();
            this.contacto = contacto;
            CargarDatosContacto();
        }

        private void CargarDatosContacto()
        {
            txtNombre.Text = contacto.Nombre;
            txtApellido.Text = contacto.Apellido;
            dtpFechaNacimiento.Value = contacto.FechaNacimiento;
            txtDireccion.Text = contacto.Direccion;
            cmbGenero.SelectedItem = contacto.Genero;
            cmbEstadoCivil.SelectedItem = contacto.EstadoCivil;
            txtMovil.Text = contacto.Movil;
            txtTelefono.Text = contacto.Telefono;
            txtCorreoElectronico.Text = contacto.CorreoElectronico;
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            contacto.Nombre = txtNombre.Text;
            contacto.Apellido = txtApellido.Text;
            contacto.FechaNacimiento = dtpFechaNacimiento.Value;
            contacto.Direccion = txtDireccion.Text;
            contacto.Genero = cmbGenero.SelectedItem.ToString();
            contacto.EstadoCivil = cmbEstadoCivil.SelectedItem.ToString();
            contacto.Movil = txtMovil.Text;
            contacto.Telefono = txtTelefono.Text;
            contacto.CorreoElectronico = txtCorreoElectronico.Text;

            ContactoBL contactoBL = new ContactoBL();
            contactoBL.ModificarContacto(contacto);
            MessageBox.Show("Contacto modificado con éxito.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
