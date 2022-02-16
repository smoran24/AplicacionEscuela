using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AplicacionEscuela
{
    class Alumno : Persona, ITransacciones //relación de tipo GENERALIZACIÓN con Persona e implementación de INTERFAZ con ITransacciones
    {
        private string turno;
        private List<Materia> materias = new List<Materia>(); //relación de tipo AGREGACIÓN con Materia
        private int id;

        public Alumno(int id) //constructor usado cuando se necesite el método Borrar() para eliminar un registro solo por ID
        {
            this.id = id;
        }

        //este constructor sobrecargado existe para cuando se quiera Agregar() un objeto de esta clase a un método SQL
        public Alumno(string turno, int legajo, string nombre, string apellido, string email, int dni) : base(legajo, nombre, apellido, email, dni)
        {
            this.turno = turno;
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.dni = dni;
        }

        //mismo principio, pero este se utiliza en el método Modificar(), donde se necesita conocer el ID tambien
        public Alumno(string turno, int id, int legajo, string nombre, string apellido, string email, int dni) : base(legajo, nombre, apellido, email, dni)
        {
            this.turno = turno;
            this.id = id;
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.dni = dni;
        }

        public string getTurno()
        {
            return this.turno;
        }

        public void setTurno(string p_turno)
        {
            this.turno = p_turno;
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
            MySqlCommand agregar = new MySqlCommand("INSERT INTO alumnos (nombre, apellido, email, dni, turno, legajo) VALUES (@nombre, @apellido, @email, @dni, @turno, @legajo)", conexion);
            agregar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = this.nombre;
            agregar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = this.apellido;
            agregar.Parameters.Add("@email", MySqlDbType.VarChar).Value = this.email;
            agregar.Parameters.Add("@dni", MySqlDbType.Int32).Value = this.dni;
            agregar.Parameters.Add("@turno", MySqlDbType.VarChar).Value = this.turno;
            agregar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = this.legajo;
            conexion.Open(); //abre la conexion
            agregar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
            conexion.Close(); //la cierra
        }

        public void Borrar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand borrar = new MySqlCommand("DELETE FROM alumnos WHERE id = @id", conexion);
            borrar.Parameters.Add("@id", MySqlDbType.Int32).Value = this.id;
            conexion.Open(); //abre la conexion
            borrar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
            conexion.Close(); //la cierra
        }

        public void Modificar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand modificar = new MySqlCommand("UPDATE alumnos SET nombre = @nombre, apellido = @apellido, email = @email, dni = @dni, turno = @turno, legajo = @legajo WHERE id = @id", conexion);
            modificar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = this.nombre;
            modificar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = this.apellido;
            modificar.Parameters.Add("@email", MySqlDbType.VarChar).Value = this.email;
            modificar.Parameters.Add("@dni", MySqlDbType.Int32).Value = this.dni;
            modificar.Parameters.Add("@turno", MySqlDbType.VarChar).Value = this.turno;
            modificar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = this.legajo;
            modificar.Parameters.Add("@id", MySqlDbType.Int32).Value = this.id;
            conexion.Open(); //abre la conexion
            modificar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
            conexion.Close(); //la cierra
        }

        public void Buscar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand buscar = new MySqlCommand("SELECT * FROM alumnos WHERE dni = @dni", conexion);
            buscar.Parameters.Add("@dni", MySqlDbType.Int32).Value = this.dni;
            conexion.Open(); //abre la conexion
            buscar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
            conexion.Close(); //la cierra
        }
    }
}
