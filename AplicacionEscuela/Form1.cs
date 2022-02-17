using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscuela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
  
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAlumnosConsultas form = new VentanaAlumnosConsultas();
            form.Show();
        }

        private void conectarseASQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            cadenaConexion = new MySqlConnection("Server=localhost; Database=sebastian; Uid=root; Pwd=013042; SslMode = none"); //uso el argumento "sslmode = none" para desactivar el uso de SSL (solucion al problema de la conexion)

            try
            {
                if(cadenaConexion != null && cadenaConexion.State == ConnectionState.Closed)
                {
                    cadenaConexion.Open();
                    MessageBox.Show("Conectado a la base de datos!");
                    
                }
                
            }catch(Exception c)
            {
                MessageBox.Show("No se pudo establecer la conexión con la base de datos.");
            }
            */
        }


        private void desconectarseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*

            if (cadenaConexion != null && cadenaConexion.State == ConnectionState.Open)
            {
                cadenaConexion.Close();
                MessageBox.Show("Se ha desconectado de la base de datos.");
            }

            //PRUEBO SI FUNCIONA LA HERENCIA DE ATRIBUTOS DE PERSONA.CS
            Profesor prof1 = new Profesor();
            prof1.setApellido("moran");
            string ape=prof1.getApellido();
            MessageBox.Show("hola, " + ape);
            

            //PRUEBO SI FUNCIONA LA HERENCIA DE METODOS DE INTERFAZ ITRANSACCIONES.CS
            Alumno alu = new Alumno();
            alu.Agregar();
          */
        }

        private void consultasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VentanaProfesoresConsultas form = new VentanaProfesoresConsultas();
            form.Show();
        }

        private void consultasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VentanaMateriasConsultas form = new VentanaMateriasConsultas();
            form.Show();
        }
    }
}
