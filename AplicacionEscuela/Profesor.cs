using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    class Profesor : Persona //relación de tipo GENERALIZACIÓN con Persona
    {
        private int anioIncorporacion;
        private List<Materia> materias = new List<Materia>(); //relación de tipo AGREGACIÓN con Materia

        public Profesor() //constructor vacío: se usan los getter y setter (tambien los heredados por Persona.cs) para acceder a los atributos
        {
             
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
    }
}
