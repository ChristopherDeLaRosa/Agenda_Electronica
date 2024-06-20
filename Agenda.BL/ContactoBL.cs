using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.DAL;
using ML;

namespace Agenda.BL
{
    public class ContactoBL
    {
        private ContactoDAL context;

        public ContactoBL()
        {
            context = new ContactoDAL();
        }

        public void InsertarContacto(Contacto contacto)
        {
            context.InsertarContacto(contacto);
        }

        public void ModificarContacto(Contacto contacto)
        {
            context.ModificarContacto(contacto);
        }

        public void EliminarContacto(int id)
        {
            context.EliminarContacto(id);
        }

        public List<Contacto> BuscarContactos(string searchTerm)
        {
            return context.BuscarContactos(searchTerm);
        }


        public List<Contacto> GetContactos()
        {
            return context.GetContactos();
        }
    }

}
