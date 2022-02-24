using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    interface ITransacciones
    {
        void Agregar();

        void Borrar();

        void Modificar();

        void Buscar(int num); //este sí o sí tiene que recibir parámetro para hacer su trabajo
    }
}
