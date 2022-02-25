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
    public partial class VentanaInscribirAlumnos : Form
    {
        Alumno alu = new Alumno(); //creo el objeto para usarlo a lo largo de esta ventana

        public VentanaInscribirAlumnos()
        {
            InitializeComponent();
            refrescarTabla(); //al iniciar muestra la datagridview para poder ver la base de datos
            btnAgregar.Enabled = false;
        }

        public void refrescarTabla()
        {
            MySqlDataAdapter da = GestorDB.RefrescarDB(4); //4 indica que se refrescará la tabla de alumnos por cursos
            DataSet ds = new DataSet(); //crea data set para llenar la datagrid
            da.Fill(ds, "alumnos_x_cursos"); //llena con la tabla indicada el adaptador de datos
            dataGridView1.DataSource = ds.Tables["alumnos_x_cursos"].DefaultView; //llena la datagridview usando los datos de la tabla indicada
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIDalumno.Text = "";
            txtIDmateria.Text = "";
            btnAgregar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIDalumno.Text) || String.IsNullOrEmpty(txtIDmateria.Text))
            {
                MessageBox.Show("Error: Debe completar todos los campos para añadir un elemento");
            }
            else
            {
                int p_idAlumno;
                int p_idMateria;
                try
                {
                    p_idAlumno = int.Parse(txtIDalumno.Text); //convierto a int lo que este en el textbox. Si no funciona, tirará excepción
                    p_idMateria = int.Parse(txtIDmateria.Text); //idem
                    alu.agregarMateria(p_idMateria); //llamo al método de la clase para hacer un alta con esta instancia de la clase
                    MessageBox.Show("Registro añadido correctamente");
                    refrescarTabla();
                    btnAgregar.Enabled = false;
                }
                catch (Exception c)
                {
                    MessageBox.Show("Error: Debe ingresar valores numéricos para DNI o legajo");
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) //si no se ha seleccionado una fila para borrar, larga error
            {
                MessageBox.Show("Error: No se ha seleccionado un registro para borrar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar este registro?", "Confirmar acción", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int indiceFilaElegido = dataGridView1.SelectedRows[0].Index; //puntero que indica la fila seleccionada
                    int IDfila = Convert.ToInt32(dataGridView1[0, indiceFilaElegido].Value); //obtiene y convierte a int el valor del indice de la fila elegida
                    int IDmateria = Convert.ToInt32(dataGridView1[2, indiceFilaElegido].Value); //idem pero con el valor de la columna 2 (curso_id)
                    alu.borrarMateria(IDfila, IDmateria);
                    MessageBox.Show("Registro borrado con éxito");
                    refrescarTabla();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtIDalumno.Text = row.Cells[1].Value.ToString();
                txtIDmateria.Text = row.Cells[2].Value.ToString();
                int idAlumno = int.Parse(txtIDalumno.Text);
                //reconstruirListaMaterias(idAlumno);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
