using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    abstract class GestorDB
    {
        //es estática la cadena de conexion porque no varía a lo largo del programa. Además es usada por métodos estáticos a lo largo de esta clase.
        private static MySqlConnection conexionSQL = new MySqlConnection("Server=localhost; Database=academias; Uid=root; Pwd=013042; SslMode = none");

        public static MySqlDataAdapter RefrescarDB(int entidad)
        {
            MySqlConnection conexion = conexionSQL; //obtengo la cadena de conexion de Sistema.cs para conectarme a la base de datos
            string nomTabla = null;
            switch (entidad)
            {
                case 1:
                    nomTabla = "alumnos";
                    break;
                case 2:
                    nomTabla = "profesores";
                    break;
                case 3:
                    nomTabla = "cursos";
                    break;
                case 4:
                    nomTabla = "alumnos_x_cursos";
                    break;
                case 5:
                    nomTabla = "profes_x_cursos";
                    break;
            }
            string comando = "SELECT * FROM " + nomTabla; //sentencia SQL que selecciona todos los registros de la tabla indicada
            MySqlDataAdapter da = new MySqlDataAdapter(comando, conexion); //crea el adaptador de datos con la info de conexion y la sentencia
            return da; //retorna el adaptador de datos para usarlo en el datagrid (capa de transacciones)
        }

        public static bool BuscarAlumnoPorDNI(int dni)
        {
            try
            {
                MySqlCommand buscar = new MySqlCommand("SELECT * FROM alumnos WHERE dni = @dni", conexionSQL);
                buscar.Parameters.Add("@dni", MySqlDbType.Int32).Value = dni;
                conexionSQL.Open(); //abre la conexion
                buscar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch (Exception c)
            {
                return false;
            }
        }

        public static bool InsertarAlumno(string nom, string ape, string ema, int dni, string tur, int leg)
        {
            try
            {
                MySqlCommand agregar = new MySqlCommand("INSERT INTO alumnos (nombre, apellido, email, dni, turno, legajo) VALUES (@nombre, @apellido, @email, @dni, @turno, @legajo)", conexionSQL);
                agregar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = nom;
                agregar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = ape;
                agregar.Parameters.Add("@email", MySqlDbType.VarChar).Value = ema;
                agregar.Parameters.Add("@dni", MySqlDbType.Int32).Value = dni;
                agregar.Parameters.Add("@turno", MySqlDbType.VarChar).Value = tur;
                agregar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = leg;
                conexionSQL.Open(); //abre la conexion
                agregar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }catch(Exception c)
            {
                return false;
            }
        }

        public static bool EliminarAlumno(int id)
        {
            try
            {
                MySqlCommand borrar = new MySqlCommand("DELETE FROM alumnos WHERE id = @id", conexionSQL);
                borrar.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                conexionSQL.Open(); //abre la conexion
                borrar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch(Exception c)
            {
                return false;
            }
        }

        public static bool ActualizarAlumno(string nom, string ape, string ema, int dni, string tur, int leg, int id)
        {
            try
            {
                MySqlCommand modificar = new MySqlCommand("UPDATE alumnos SET nombre = @nombre, apellido = @apellido, email = @email, dni = @dni, turno = @turno, legajo = @legajo WHERE id = @id", conexionSQL);
                modificar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = nom;
                modificar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = ape;
                modificar.Parameters.Add("@email", MySqlDbType.VarChar).Value = ema;
                modificar.Parameters.Add("@dni", MySqlDbType.Int32).Value = dni;
                modificar.Parameters.Add("@turno", MySqlDbType.VarChar).Value = tur;
                modificar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = leg;
                modificar.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                conexionSQL.Open(); //abre la conexion
                modificar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch(Exception c)
            {
                return false;
            }
        }

        public static bool InsertarProfesor(string nom, string ape, int dni, string ema, int anio, int leg)
        {
            try
            {
                MySqlCommand agregar = new MySqlCommand("INSERT INTO profesores (nombre, apellido, dni, email, anioIncorporacion, legajo) VALUES (@nombre, @apellido, @dni, @email, @anioIncorporacion, @legajo)", conexionSQL);
                agregar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = nom;
                agregar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = ape;
                agregar.Parameters.Add("@dni", MySqlDbType.Int32).Value = dni;
                agregar.Parameters.Add("@email", MySqlDbType.VarChar).Value = ema;
                agregar.Parameters.Add("@anioIncorporacion", MySqlDbType.Int32).Value = anio;
                agregar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = leg;
                conexionSQL.Open(); //abre la conexion
                agregar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }catch(Exception c)
            {
                return false;
            }
        }

        public static bool EliminarProfesor(int id)
        {
            try
            {
                MySqlCommand borrar = new MySqlCommand("DELETE FROM profesores WHERE id = @id", conexionSQL);
                borrar.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                conexionSQL.Open(); //abre la conexion
                borrar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch (Exception c)
            {
                return false;
            }
        }

        public static bool ActualizarProfesor(string nom, string ape, int dni, string ema, int anio, int leg, int id)
        {
            try
            {
                MySqlCommand modificar = new MySqlCommand("UPDATE profesores SET nombre = @nombre, apellido = @apellido, dni = @dni, email = @email, anioIncorporacion = @anioIncorporacion, legajo = @legajo WHERE id = @id", conexionSQL);
                modificar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = nom;
                modificar.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = ape;
                modificar.Parameters.Add("@dni", MySqlDbType.Int32).Value = dni;
                modificar.Parameters.Add("@email", MySqlDbType.VarChar).Value = ema;
                modificar.Parameters.Add("@anioIncorporacion", MySqlDbType.Int32).Value = anio;
                modificar.Parameters.Add("@legajo", MySqlDbType.Int32).Value = leg;
                modificar.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                conexionSQL.Open(); //abre la conexion
                modificar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch (Exception c)
            {
                return false;
            }
        }

        public static bool InsertarMateria(string nom, string desc)
        {
            try
            {
                MySqlCommand agregar = new MySqlCommand("INSERT INTO cursos (nombre, descripcion) VALUES (@nombre, @descripcion)", conexionSQL);
                agregar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = nom;
                agregar.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = desc;
                conexionSQL.Open(); //abre la conexion
                agregar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch (Exception c)
            {
                return false;
            }
        }

        public static bool EliminarMateria(int id)
        {
            try
            {
                MySqlCommand borrar = new MySqlCommand("DELETE FROM cursos WHERE id = @id", conexionSQL);
                borrar.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                conexionSQL.Open(); //abre la conexion
                borrar.ExecuteNonQuery(); //ejecuta el comando en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch (Exception c)
            {
                return false;
            }
        }

        public static bool ActualizarMateria(string nom, string desc, int id)
        {
            try
            {
                MySqlCommand modificar = new MySqlCommand("UPDATE cursos SET nombre = @nombre, descripcion = @descripcion WHERE id = @id", conexionSQL);
                modificar.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = nom;
                modificar.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = desc;
                modificar.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                conexionSQL.Open(); //abre la conexion
                modificar.ExecuteNonQuery(); //ejecuta el comando "agregar" en la base de datos
                conexionSQL.Close(); //la cierra
                return true;
            }
            catch (Exception c)
            {
                return false;
            }
        }

    }
}
