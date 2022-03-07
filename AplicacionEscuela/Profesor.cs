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

        public int getAnioIncorporacion()
        {
            return this.anioIncorporacion;
        }

        public void setAnioIncorporacion(int p_anioIncorporacion)
        {
            this.anioIncorporacion = p_anioIncorporacion;
        }

        public int getID()
        {
            return this.id;
        }

        public void setID(int p_id)
        {
            this.id = p_id;
        }

        /* //METODO SIN USO
        public void agregarMateria(int idMateria)
        {
            Materia mat = new Materia(idMateria); //crea un nuevo objeto tipo materia con los parametros recibidos
            materias.Add(mat); //añade la materia "mat" a la List "materias".
        }
        */

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
    }
}
