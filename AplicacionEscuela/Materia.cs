using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    class Materia : ITransacciones //implementación de INTERFAZ con ITransacciones
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int idProf; //ASUMIENDO QUE CADA MATERIA TIENE UN SOLO PROFESOR
        private List<Alumno> alumnos = new List<Alumno>(); //relación de tipo AGREGACIÓN con Alumno (cada materia tiene varios alumnos)

        public Materia(int id) //constructor usado cuando se necesite el método Borrar() para eliminar un registro solo por ID
        {
            this.id = id;
        }

        //este constructor sobrecargado existe para cuando se quiera Agregar() un objeto de esta clase a un método SQL
        public Materia(string nombre, string descripcion, int idProf)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.idProf = idProf;
        }

        //mismo principio, pero este se utiliza en el método Modificar(), donde se necesita conocer el ID tambien
        public Materia(int id, string nombre, string descripcion, int idProf)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.idProf = idProf;
        }

        public int getId()
        {
            return this.id;
        }
        public void setId(int p_id)
        {
            this.id = p_id;
        }

        public string getNombre()
        {
            return this.nombre;
        }
        public void setNombre(string p_nombre)
        {
            this.nombre = p_nombre;
        }

        public string getDescripcion()
        {
            return this.descripcion;
        }
        public void setDescripcion(string p_descripcion)
        {
            this.descripcion = p_descripcion;
        }

        public int getIdProfesor()
        {
            return this.idProf;
        }
        public void setIdProfesor(int p_idProf)
        {
            this.idProf = p_idProf;
        }

        public void agregarAlumno(int legajo, string nombre, string apellido, string email, int dni, string turno)
        {
            Alumno alu = new Alumno(turno, legajo, nombre, apellido, email, dni); //crea un nuevo objeto con los parámetros recibidos
            alumnos.Add(alu); //añade el elemento a la lista
        }

        public void Agregar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand agregar = new MySqlCommand("INSERT INTO cursos (nombre, descripcion, profesor_id) VALUES (@nombre, @descripcion, @profesor_id)", conexion);
            agregar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = this.nombre;
            agregar.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = this.descripcion;
            agregar.Parameters.Add("@profesor_id", MySqlDbType.Int32).Value = this.idProf;
            conexion.Open(); //abre la conexion
            agregar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
            conexion.Close(); //la cierra
        }

        public void Borrar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand borrar = new MySqlCommand("DELETE FROM cursos WHERE id = @id", conexion);
            borrar.Parameters.Add("@id", MySqlDbType.Int32).Value = this.id;
            conexion.Open(); //abre la conexion
            borrar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
            conexion.Close(); //la cierra
        }

        public void Modificar()
        {
            Sistema sis = new Sistema();
            MySqlConnection conexion = sis.getConexion(); //obtiene la cadena de conexion
            MySqlCommand modificar = new MySqlCommand("UPDATE cursos SET nombre = @nombre, descripcion = @descripcion, profesor_id = @profesor_id WHERE id = @id", conexion);
            modificar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = this.nombre;
            modificar.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = this.descripcion;
            modificar.Parameters.Add("@profesor_id", MySqlDbType.Int32).Value = this.idProf;
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
