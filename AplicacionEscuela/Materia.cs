using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    class Materia
    {
        private int id;
        private string nombre;
        private string descripcion;
        private Nota notaMateria; //relación de ASOCIACIÓN con Nota
        private List<Alumno> alumnos = new List<Alumno>(); //relación de tipo AGREGACIÓN con Alumno

        public Materia(int id)
        {
            this.id = id;

        }

        public Materia(int id, string nombre, string descripcion, Nota notaMateria)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.notaMateria = notaMateria;
            
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

        public void agregarAlumno(int legajo, string nombre, string apellido, string email, int dni, string turno)
        {
            Alumno alu = new Alumno(turno, legajo, nombre, apellido, email, dni); //crea un nuevo objeto con los parámetros recibidos
            alumnos.Add(alu); //añade el elemento a la lista
        }

        public void setNota(int id, float calificacion)
        {
            Nota estaNota = new Nota(id, calificacion);
            this.notaMateria = estaNota;
        }
    }
}
