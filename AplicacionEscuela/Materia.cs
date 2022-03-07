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
        private List<Alumno> alumnos = new List<Alumno>(); //relación de tipo AGREGACIÓN con Alumno (cada materia tiene varios alumnos)
        private List<Profesor> profes = new List<Profesor>(); //relación de tipo AGREGACIÓN con Profesor (cada materia tiene varios profes)

        public Materia()
        {

        }

        public Materia(int id) //constructor usado cuando se necesite el método agregarMateria() en Alumno.cs
        {
            this.id = id;
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

        /* //METODOS NO IMPLEMENTADOS (el primero porque ya está implementado por Alumno y el otro porque no lo está)
        public void agregarAlumno(int legajo, string nombre, string apellido, string email, int dni, string turno)
        {
            Alumno alu = new Alumno(turno, legajo, nombre, apellido, email, dni); //crea un nuevo objeto con los parámetros recibidos
            alumnos.Add(alu); //añade el elemento a la lista
        }

        public void agregarProfesor(int legajo, string nombre, string apellido, string email, int dni, int anioIncorp)
        {
            Profesor pro = new Profesor(anioIncorp, legajo, nombre, apellido, email, dni); //crea un nuevo objeto con los parámetros recibidos
            profes.Add(pro); //añade el elemento a la lista
        }
        */

        public void Agregar()
        {
            GestorDB.InsertarMateria(this.nombre, this.descripcion);
        }

        public void Borrar()
        {
            GestorDB.EliminarMateria(this.id);
        }

        public void Modificar()
        {
            GestorDB.ActualizarMateria(this.nombre, this.descripcion, this.id);
        }
    }
}
