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
        //Instancia de la clase ContactoBL para manejar la logica del negocio de los contactos
        private ContactoBL contactoBL = new ContactoBL();

        public AgendaForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Evento que carga y muestra los datos en la tabla (DataGridView)
        private void AgendaForm_Load(object sender, EventArgs e)
        {      
            this.CargarDatos();

        }

        //Evento ara eliminar un contacto de la agenda 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Obtiene el Id del contacto seleccionado en la tabla
            int id = Convert.ToInt32(dgvContacto.CurrentRow.Cells["Id"].Value);

            //Llama al metodo EliminarContacto() de ContactoBL para eliminar el contacto seleccionado
            contactoBL.EliminarContacto(id);

            //Muestra el msj de operacion realizada con exito
            MessageBox.Show("Operación realizada con éxito");
            this.CargarDatos();
            
        }

        //Metodo usado para cargar y mostrar los datos en la tabla
        public void CargarDatos()
        {
            List<Contacto> listaContactos = contactoBL.GetContactos();
            dgvContacto.DataSource = listaContactos;
        }

        //Evento que muestra el formulario para agregar un nuevo contacto
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarForm frm = new AgregarForm();
            frm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Comprueba si hay una fila seleccionada en la tabla
            if (dgvContacto.SelectedRows.Count > 0)
            {
                //Obtiene el nombre del contacto seleccionado
                string searchTerm = dgvContacto.SelectedRows[0].Cells["Nombre"].Value.ToString(); 

                //Busca los contactos que coincidan con el nombre
                List<Contacto> contactos = contactoBL.BuscarContactos(searchTerm);

                //Si se encuentran contactos con el nombre seleccionado, abre el formulario de modificar
                if (contactos != null && contactos.Count > 0)
                {
                    Contacto contacto = contactos[0]; //Toma el primer contacto encontrado
                    ModificarForm formModificar = new ModificarForm(contacto);//crea el formulario de modificacion
                    
                    //Si el formulario de modificacion se cerro con el resultado OK, recarga los datos
                    if (formModificar.ShowDialog() == DialogResult.OK)
                    {
                        btnBuscador_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Contacto no encontrado.");
                }
            }
            //Muestra un mensaje en caso de que no se haya seleccionado ningun contacto
            else
            {
                MessageBox.Show("Seleccione un contacto para modificar.");
            }
        }
        //Evento que se genera cuando se hace clic en el boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            //Obtiene el termino de busqueda ingresado por el usuario
            string searchTerm = txtBuscar.Text;

            //Busca los contactos que coincidan con el termino de busqueda
            List<Contacto> contactos = contactoBL.BuscarContactos(searchTerm);

            //Si se encuentran contactos, los muestra en la tabla
            if (contactos != null && contactos.Count > 0)
            {
                dgvContacto.DataSource = contactos;
                
            }
            else
            {
                //muestra un msj si no se encuentran contactos
                MessageBox.Show("No se encontraron contactos.");
                dgvContacto.DataSource = null;
            }
        }


    }
}
