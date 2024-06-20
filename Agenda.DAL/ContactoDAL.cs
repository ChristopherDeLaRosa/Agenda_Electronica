using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace Agenda.DAL
{
    public class ContactoDAL
    {
        //SqlConnection conexion = Database.Instance.Connection;
        string cadena = "Data Source = LAPTOP-LGPSKH9S\\SQLEXPRESS; Initial Catalog = AgendaDB; Integrated Security = True; Trusted_Connection = True; TrustServerCertificate = True;";


        public void InsertarContacto(Contacto contacto)
        {
            try
            {    
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();

                    string query = "INSERT INTO Contactos (Nombre, Apellido, FechaNacimiento, Direccion, Genero, EstadoCivil, Movil, Telefono, CorreoElectronico) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Direccion, @Genero, @EstadoCivil, @Movil, @Telefono, @CorreoElectronico)";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id", contacto.Id);
                    cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion", contacto.Direccion);
                    cmd.Parameters.AddWithValue("@Genero", contacto.Genero);
                    cmd.Parameters.AddWithValue("@EstadoCivil", contacto.EstadoCivil);
                    cmd.Parameters.AddWithValue("@Movil", contacto.Movil);
                    cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", contacto.CorreoElectronico);
                    
                    cmd.ExecuteNonQuery();

                    conexion.Close();

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al establecer la conexion con la base de datos", ex);
            }
        }

        public void ModificarContacto(Contacto contacto)
        {
            try
            {
                using(SqlConnection conexion = new SqlConnection(cadena))
                {

                    conexion.Open();
                    string query = "UPDATE Contactos SET Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fechaNacimiento, Direccion = @direccion, Genero = @genero, EstadoCivil = @estadoCivil, Movil = @movil, Telefono = @telefono, CorreoElectronico = @correoElectronico WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id", contacto.Id);
                    cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion", contacto.Direccion);
                    cmd.Parameters.AddWithValue("@Genero", contacto.Genero);
                    cmd.Parameters.AddWithValue("@EstadoCivil", contacto.EstadoCivil);
                    cmd.Parameters.AddWithValue("@Movil", contacto.Movil);
                    cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", contacto.CorreoElectronico);

                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        contacto.Nombre = "";
                    }

                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al establecer la conexion con la base de datos", ex);
            }
        }

        public void EliminarContacto(int id)
        {
            try
            {
                using(SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "DELETE FROM Contactos WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("Id", id);

                    cmd.ExecuteNonQuery();
                    conexion.Close();

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al establecer la conexion con la base de datos", ex);
            }
        }


        public List<Contacto> BuscarContactos(string searchTerm)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();

                    string query = "SELECT * FROM Contactos WHERE " +
                    "Nombre LIKE @SearchTerm OR " +
                    "Apellido LIKE @SearchTerm OR " +
                    "Direccion LIKE @SearchTerm OR " +
                    "CorreoElectronico LIKE @SearchTerm OR " +
                    "Movil LIKE @SearchTerm OR " +
                    "Telefono LIKE @SearchTerm";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Contacto> listaContactos = new List<Contacto>();

                    while (reader.Read())
                    {
                        int id = int.Parse(reader["Id"].ToString());
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        DateTime fechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                        string direccion = reader["Direccion"].ToString();
                        string genero = reader["Genero"].ToString();
                        string stadoCivil = reader["EstadoCivil"].ToString();
                        string movil = reader["Movil"].ToString();
                        string telefono = reader["Telefono"].ToString();
                        string correo = reader["CorreoElectronico"].ToString();

                        Contacto contacto = new Contacto(id, nombre, apellido, fechaNacimiento, direccion, genero, stadoCivil, movil, telefono, correo);
                        listaContactos.Add(contacto);
                    }
                    reader.Close();
                    return listaContactos;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Contacto> GetContactos()
        {
            try
            {
                using(SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();

                    string query = "SELECT * FROM Contactos";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Contacto> listaContactos = new List<Contacto>();

                    while(reader.Read())
                    {
                        int id = int.Parse(reader["Id"].ToString());
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        DateTime fechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                        string direccion = reader["Direccion"].ToString();
                        string genero = reader["Genero"].ToString();
                        string stadoCivil = reader["EstadoCivil"].ToString();
                        string movil = reader["Movil"].ToString();
                        string telefono = reader["Telefono"].ToString();
                        string correo = reader["CorreoElectronico"].ToString();

                        Contacto contacto = new Contacto(id, nombre, apellido, fechaNacimiento, direccion, genero, stadoCivil, movil, telefono, correo);
                        listaContactos.Add(contacto);
                    }
                    reader.Close();
                    return listaContactos;

                    
                }
            }
            catch 
            {
                return null;
            }
        }


    }
}
