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

        public Profesor()
        {

        }

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
            GestorDB.InsertarProfesor(this.nombre, this.apellido, this.dni, this.email, this.anioIncorporacion, this.legajo);
        }

        public void Borrar()
        {
            GestorDB.EliminarProfesor(this.id);
        }

        public void Modificar()
        {
            GestorDB.ActualizarProfesor(this.nombre, this.apellido, this.dni, this.email, this.anioIncorporacion, this.legajo, this.id);
        }

        public void Buscar(int dni)
        {
            
        }
    }
}
