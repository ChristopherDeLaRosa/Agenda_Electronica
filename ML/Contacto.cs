using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Movil { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Contacto()
        {
            
        }

        public Contacto(int id, string nombre, string apellido, DateTime fechaNacimiento, string direccion, string genero, string stadoCivil, string movil, string telefono, string correo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Genero = genero;
            EstadoCivil = stadoCivil;
            Movil = movil;
            Telefono = telefono;
            CorreoElectronico = correo;
        }
    }
}
