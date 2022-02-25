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

            for (int i = 0; i < materias.Count; i++)
            {
                if (materias[i].getId() == idMateria) //si la id de la materia M concuerda con el id de materia provisto...
                {
                    materias.Remove(materias[i]); //se quita la materia M de la lista de materias
                }
            }

            GestorDB.DarDeBajaAlumno(idFila);
        }

        public void modificarMateria(int idMateria, int idFila)
        {
            for (int i = 0; i < materias.Count; i++)
            {
                if (i == idFila)
                {
                    materias[i].setId(idMateria);
                }
            }
            GestorDB.ModificarInscripcionAlumno(this.id, idMateria, idFila);
        }

        public void reconstruirListaMaterias(int idAlumno) //ERROR: SE PRODUCE UN BUCLE INFINITO
        {
            List <int> numMaterias = GestorDB.getFromDataBase(idAlumno); //recibe la List de valores INT (indices de materias)
            /*
            foreach (Materia m in materias) 
            {
                foreach (int idMateria in numMaterias)
                {
                    if (m.getId() != idMateria) //si el id de la materia m actual no coincide con uno de la lista de ids...
                    {
                        Materia mat = new Materia(idMateria); //lo añade a la lista de materias
                        materias.Add(mat);
                    }
                }
            }*/
            for (int i = 0; i < materias.Count; i++)
            {
                for (int j = 0; j < numMaterias.Count; j++)
                {
                    if (materias[i].getId() != j) //si el id de la materia m actual no coincide con uno de la lista de ids...
                    {
                        Materia mat = new Materia(j); //lo añade a la lista de materias
                        materias.Add(mat);
                    }
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

        public void Buscar(int dni)
        {
            GestorDB.BuscarAlumnoPorDNI(dni);
        }
    }
}
