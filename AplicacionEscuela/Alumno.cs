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
        private List<Materia> materias = new List<Materia>(); //relación de tipo AGREGACIÓN con Materia (cada alumno tiene varias materias)
        private int id;

        public Alumno()
        {
            
        }

        public string getTurno()
        {
            return this.turno;
        }

        public void setTurno(string p_turno)
        {
            this.turno = p_turno;
        }

        public int getID()
        {
            return this.id;
        }

        public void setID(int p_id)
        {
            this.id = p_id;
        }

        public void agregarMateria(int idMateria)
        {
            if (GestorDB.InscribirAlumno(this.id, idMateria) == true) //si funciona el método de inscripción...
            {
                Materia mat = new Materia(idMateria); //crea un nuevo objeto tipo materia con los parametros recibidos
                materias.Add(mat); //añade la materia "mat" a la List "materias".
            }
        }

        public void borrarMateria(int idFila, int idMateria)
        {  /* //EL FOREACH LARGA ERROR CUANDO SE ALTERA LA LISTA QUE ESTÁ ITERANDO
           foreach (Materia m in materias) //busca la materia M entre las demás en la lista de este alumno
           {
              if (m.getId() == idMateria) //si la id de la materia M concuerda con el id de materia provisto...
              {
                materias.Remove(m); //se quita la materia M de la lista de materias
              }
           }
           */
           if(GestorDB.DarDeBajaAlumno(idFila) == true) //verifica si se pudo eliminar la materia en la base de datos
            {
                for (int i = 0; i < materias.Count; i++) //recorre la lista de materias
                {
                    if (materias[i].getId() == idMateria) //si la id de la materia M concuerda con el id de materia provisto...
                    {
                        materias.Remove(materias[i]); //se quita la materia M de la lista de materias
                    }
                }
            }
        }

        public void modificarMateria(int idMateria, int idFila)
        {
            if(GestorDB.ModificarInscripcionAlumno(this.id, idMateria, idFila) == true)
            {
                for (int i = 0; i < materias.Count; i++) //recorre la lista de materias
                {
                    if (materias[i].getId() == idMateria) //si la id de la materia M concuerda con el id de materia provisto...
                    {
                        materias.Remove(materias[i]); //se quita la materia M de la lista de materias
                    }
                }
                Materia mat = new Materia(idMateria); //crea un nuevo objeto tipo materia con los parametros recibidos
                materias.Add(mat); //añade la materia "mat" a la List "materias".
            }
        }

        public void reconstruirListaMaterias(int idAlumno) //puede que no esté funcionando...
        {
            List <int> numMaterias = GestorDB.getFromDataBase(idAlumno); //recibe la List de valores int (indices de materias)

            int cantMaterias = materias.Count;
            materias.Clear(); //limpio la lista de materias para luego re-rellenarla

            for (int i = 0; i < cantMaterias; i++) //bucles para añadir las materias de la lista de IDs de la base de datos a la lista de materias
            {
                for (int j = 0; j < numMaterias.Count; j++)
                {
                    Materia mat = new Materia(numMaterias[j]); //lo añade a la lista de materias
                    materias.Add(mat);
                }
            }
        }

        public void Agregar()
        {
            GestorDB.InsertarAlumno(this.nombre, this.apellido, this.email, this.dni, this.turno, this.legajo);
        }

        public void Borrar()
        {
            GestorDB.EliminarAlumno(this.id);
        }

        public void Modificar()
        {
            GestorDB.ActualizarAlumno(this.nombre, this.apellido, this.email, this.dni, this.turno, this.legajo, this.id);
        }
    }
}
