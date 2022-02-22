using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    class Profesor : Persona, ITransacciones //relación de tipo GENERALIZACIÓN con Persona e implementación de INTERFAZ con ITransacciones
    {
        private int anioIncorporacion;
        private List<Materia> materias = new List<Materia>(); //relación de tipo AGREGACIÓN con Materia (cada profesor tiene varias materias)
        private int id;

        public Profesor(int id) //constructor usado cuando se necesite el método Borrar() para eliminar un registro solo por ID
        {
            this.id = id;
        }
        
        //este constructor sobrecargado existe por las dudas que se quiera pasar un objeto de esta clase a un método sql
        public Profesor(int anioIncorporacion, int legajo, string nombre, string apellido, string email, int dni) : base(legajo, nombre, apellido, email, dni)
        {
            this.anioIncorporacion = anioIncorporacion;
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.dni = dni;
        }

        //mismo principio, pero este se utiliza en el método Modificar(), donde se necesita conocer el ID tambien
        public Profesor(int anioIncorporacion, int id, int legajo, string nombre, string apellido, string email, int dni) : base(legajo, nombre, apellido, email, dni)
        {
            this.anioIncorporacion = anioIncorporacion;
            this.id = id;
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.dni = dni;
        }

        public int getAnioIncorporacion()
        {
            return this.anioIncorporacion;
        }
        public void setAnioIncorporacion(int p_anioIncorporacion)
        {
            this.anioIncorporacion = p_anioIncorporacion;
        }

        public void agregarMateria(int idMateria)
        {
            Materia mat = new Materia(idMateria); //crea un nuevo objeto tipo materia con los parametros recibidos
            materias.Add(mat); //añade la materia "mat" a la List "materias".
        }

        public void Agregar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand agregar = new MySqlCommand("INSERT INTO profesores (nombre, apellido, dni, email, anioIncorporacion, legajo) VALUES (@nombre, @apellido, @dni, @email, @anioIncorporacion, @legajo)", conexion);
            agregar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = this.nombre;
            agregar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = this.apellido;
            agregar.Parameters.Add("@dni", MySqlDbType.Int32).Value = this.dni;
            agregar.Parameters.Add("@email", MySqlDbType.VarChar).Value = this.email;
            agregar.Parameters.Add("@anioIncorporacion", MySqlDbType.Int32).Value = this.anioIncorporacion;
            agregar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = this.legajo;
            conexion.Open(); //abre la conexion
            agregar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
            conexion.Close(); //la cierra
        }

        public void Borrar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand borrar = new MySqlCommand("DELETE FROM profesores WHERE id = @id", conexion);
            borrar.Parameters.Add("@id", MySqlDbType.Int32).Value = this.id;
            conexion.Open(); //abre la conexion
            borrar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
            conexion.Close(); //la cierra
        }

        public void Modificar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand modificar = new MySqlCommand("UPDATE profesores SET nombre = @nombre, apellido = @apellido, dni = @dni, email = @email, anioIncorporacion = @anioIncorporacion, legajo = @legajo WHERE id = @id", conexion);
            modificar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = this.nombre;
            modificar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = this.apellido;
            modificar.Parameters.Add("@dni", MySqlDbType.Int32).Value = this.dni;
            modificar.Parameters.Add("@email", MySqlDbType.VarChar).Value = this.email;
            modificar.Parameters.Add("@anioIncorporacion", MySqlDbType.Int32).Value = this.anioIncorporacion;
            modificar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = this.legajo;
            modificar.Parameters.Add("@id", MySqlDbType.Int32).Value = this.id;
            conexion.Open(); //abre la conexion
            modificar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
            conexion.Close(); //la cierra
        }

        public void Buscar()
        {
            
        }
    }
}
