using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    abstract class Persona
    {
        protected int legajo;
        protected string nombre;
        protected string apellido;
        protected string email;
        protected int dni;

        public Persona()
        {
        
        }

        public Persona(int legajo, string nombre, string apellido, string email, int dni)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.dni = dni;
        }

        public virtual int getLegajo()
        {
            return this.legajo;
        }

        public virtual void setLegajo(int p_legajo)
        {
            this.legajo = p_legajo;
        }

        public virtual string getNombre()
        {
            return this.nombre;
        }

        public virtual void setNombre(string p_nombre)
        {
            this.nombre = p_nombre;
        }

        public virtual string getApellido()
        {
            return this.apellido;
        }

        public virtual void setApellido(string p_apellido)
        {
            this.apellido = p_apellido;
        }

        public virtual string getEmail()
        {
            return this.email;
        }

        public virtual void setEmail(string p_email)
        {
            this.email = p_email;
        }

        public virtual int getDni()
        {
            return this.dni;
        }

        public virtual void setDni(int p_dni)
        {
            this.dni = p_dni;
        }
    }
}
