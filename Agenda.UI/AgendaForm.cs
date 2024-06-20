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
    public partial class AgendaForm : Form
    {
        private ContactoBL contactoBL = new ContactoBL();

        public AgendaForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Muestra los datos en la tabla
        private void AgendaForm_Load(object sender, EventArgs e)
        {      
            this.CargarDatos();

        }

        //Para eliminar un contacto de la agenda 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvContacto.CurrentRow.Cells["Id"].Value);
            contactoBL.EliminarContacto(id);
            MessageBox.Show("Operación realizada con éxito");
            this.CargarDatos();
            
        }

        public void CargarDatos()
        {
            List<Contacto> listaContactos = contactoBL.GetContactos();
            dgvContacto.DataSource = listaContactos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarForm frm = new AgregarForm();
            frm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvContacto.SelectedRows.Count > 0)
            {
                string searchTerm = dgvContacto.SelectedRows[0].Cells["Nombre"].Value.ToString(); // Ajusta el campo según tu necesidad
                List<Contacto> contactos = contactoBL.BuscarContactos(searchTerm);

                if (contactos != null && contactos.Count > 0)
                {
                    Contacto contacto = contactos[0]; // Selecciona el primer contacto que coincida con el término de búsqueda
                    ModificarForm formModificar = new ModificarForm(contacto);
                    if (formModificar.ShowDialog() == DialogResult.OK)
                    {
                        // Refrescar el DataGridView después de modificar
                        btnBuscador_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Contacto no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un contacto para modificar.");
            }
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvContacto.CurrentRow.Cells["Id"].Value);

            string searchTerm = txtBuscar.Text;

            List<Contacto> contactos = contactoBL.BuscarContactos(searchTerm);

            if (contactos != null && contactos.Count > 0)
            {
                dgvContacto.DataSource = contactos;
                
            }
            else
            {
                MessageBox.Show("No se encontraron contactos.");
                dgvContacto.DataSource = null;
            }
        }
    }
}
