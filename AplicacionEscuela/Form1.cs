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
            
        }


        private void desconectarseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        private void alumnosEnMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaInscribirAlumnos form = new VentanaInscribirAlumnos();
            form.Show();
        }
    }
}
