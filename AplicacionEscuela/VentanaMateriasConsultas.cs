using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AplicacionEscuela
{
    public partial class VentanaMateriasConsultas : Form
    {
        public VentanaMateriasConsultas()
        {
            InitializeComponent();
            refrescarTabla(); //muestra la datagridview para poder ver la base de datos
            btnAgregar.Enabled = false;
        }

        public void refrescarTabla()
        {
            MySqlDataAdapter da = GestorDB.RefrescarDB(3); //3 indica que se refrescará la tabla de materias
            DataSet ds = new DataSet(); //crea data set para llenar la datagrid
            da.Fill(ds, "cursos"); //llena con la tabla indicada el adaptador de datos
            dgvMaterias.DataSource = ds.Tables["cursos"].DefaultView; //llena la datagridview usando los datos de la tabla indicada
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Error: Debe completar todos los campos para añadir un elemento");
            }
            else
            {
                string p_nombre = txtNombre.Text;
                string p_desc = txtDescripcion.Text;
                Materia mat = new Materia(p_nombre, p_desc); //creo el objeto de la clase con los parametros dados
                mat.Agregar(); //llamo al método de la clase para hacer un alta con esta instancia de la clase
                MessageBox.Show("Registro añadido correctamente");
                refrescarTabla();
                btnAgregar.Enabled = false;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count == 0) //si no se ha seleccionado una fila para borrar, larga error
            {
                MessageBox.Show("Error: No se ha seleccionado un registro para borrar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar este registro?", "Confirmar acción", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int indiceElegido = dgvMaterias.SelectedRows[0].Index; //puntero que indica la fila seleccionada
                    int IDfila = Convert.ToInt32(dgvMaterias[0, indiceElegido].Value); //obtiene y convierte a int lo que esté en la fila del datagrid
                    Materia mat = new Materia(IDfila);
                    mat.Borrar();
                    MessageBox.Show("Registro borrado con éxito");
                    refrescarTabla();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count == 0) //si no se ha seleccionado una fila para editar, larga error
            {
                MessageBox.Show("Error: No se ha seleccionado un registro para modificar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea alterar este registro?", "Confirmar acción", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int indiceElegido = dgvMaterias.SelectedRows[0].Index; //puntero que indica la fila seleccionada
                    int IDfila = Convert.ToInt32(dgvMaterias[0, indiceElegido].Value); //obtiene y convierte a int lo que esté en la fila del datagrid
                    string p_nombre = txtNombre.Text;
                    string p_desc = txtDescripcion.Text;
                    Materia mat = new Materia(IDfila, p_nombre, p_desc);
                    mat.Modificar();
                    MessageBox.Show("Registro modificado con éxito");
                    refrescarTabla();
                }
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //guarda todas las filas del dgv
                DataGridViewRow row = this.dgvMaterias.Rows[e.RowIndex];
                //llena las textbox con los valores de cada columna a partir del indice 1 (el 0 es el ID)
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtDescripcion.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            btnAgregar.Enabled = true;
        }

        private void txtIdProfesor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
