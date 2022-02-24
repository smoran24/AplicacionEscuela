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
    public partial class VentanaProfesoresConsultas : Form
    {
        public VentanaProfesoresConsultas()
        {
            InitializeComponent();
            refrescarTabla(); //muestra la datagridview para poder ver la base de datos
            btnAgregar.Enabled = false;
        }

        public void refrescarTabla()
        {
            MySqlDataAdapter da = GestorDB.RefrescarDB(2); //2 indica que se refrescará la tabla de profes
            DataSet ds = new DataSet(); //crea data set para llenar la datagrid
            da.Fill(ds, "profesores"); //llena con la tabla indicada el adaptador de datos
            dgvProfesores.DataSource = ds.Tables["profesores"].DefaultView; //llena la datagridview usando los datos de la tabla indicada
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void VentanaProfesoresConsultas_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellido.Text) || String.IsNullOrEmpty(txtLegajo.Text) || String.IsNullOrEmpty(txtDNI.Text) || String.IsNullOrEmpty(txtEmail.Text) || cmbAnio.SelectedIndex == -1)
            {
                MessageBox.Show("Error: Debe completar todos los campos para añadir un elemento");
            }
            else
            {
                string p_nombre = txtNombre.Text;
                string p_apellido = txtApellido.Text;
                string p_email = txtEmail.Text;
                int p_anio;
                int p_legajo;
                int p_dni;
                try
                {
                    p_legajo = int.Parse(txtLegajo.Text); //convierto a int lo que este en el textbox
                    p_dni = int.Parse(txtDNI.Text); //idem
                    p_anio = int.Parse(cmbAnio.Text);
                    Profesor pro = new Profesor(p_anio, p_legajo, p_nombre, p_apellido, p_email, p_dni); //creo el objeto de la clase con los parametros dados
                    pro.Agregar(); //llamo al método de la clase para hacer un alta con esta instancia de la clase
                    MessageBox.Show("Registro añadido correctamente");
                    refrescarTabla();
                    btnAgregar.Enabled = false;
                }
                catch(Exception c)
                {
                    MessageBox.Show("Error: Debe ingresar valores numéricos para DNI o legajo");
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.SelectedRows.Count == 0) //si no se ha seleccionado una fila para borrar, larga error
            {
                MessageBox.Show("Error: No se ha seleccionado un registro para borrar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar este registro?", "Confirmar acción", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int indiceElegido = dgvProfesores.SelectedRows[0].Index; //puntero que indica la fila seleccionada
                    int IDfila = Convert.ToInt32(dgvProfesores[0, indiceElegido].Value); //obtiene y convierte a int lo que esté en la fila del datagrid
                    Profesor pro = new Profesor(IDfila);
                    pro.Borrar();
                    MessageBox.Show("Registro borrado con éxito");
                    refrescarTabla();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.SelectedRows.Count == 0) //si no se ha seleccionado una fila para editar, larga error
            {
                MessageBox.Show("Error: No se ha seleccionado un registro para modificar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea alterar este registro?", "Confirmar acción", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int indiceElegido = dgvProfesores.SelectedRows[0].Index; //puntero que indica la fila seleccionada
                    int IDfila = Convert.ToInt32(dgvProfesores[0, indiceElegido].Value); //obtiene y convierte a int lo que esté en la fila del datagrid
                    string p_nombre = txtNombre.Text;
                    string p_apellido = txtApellido.Text;
                    string p_email = txtEmail.Text;
                    int p_legajo = int.Parse(txtLegajo.Text); //convierto a int lo que este en el textbox
                    int p_dni = int.Parse(txtDNI.Text); //idem
                    int p_anio = int.Parse(cmbAnio.Text);
                    Profesor pro = new Profesor(p_anio, IDfila, p_legajo, p_nombre, p_apellido, p_email, p_dni);
                    pro.Modificar();
                    MessageBox.Show("Registro modificado con éxito");
                    refrescarTabla();
                }
            }
        }

        private void dgvProfesores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //guarda todas las filas del dgv
                DataGridViewRow row = this.dgvProfesores.Rows[e.RowIndex];
                //llena las textbox con los valores de cada columna a partir del indice 1 (el 0 es el ID)
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtApellido.Text = row.Cells[2].Value.ToString();
                txtDNI.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
                cmbAnio.Text = row.Cells[5].Value.ToString();
                txtLegajo.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtDNI.Text = "";
            cmbAnio.Text = "";
            txtLegajo.Text = "";
            btnAgregar.Enabled = true;
        }
    }
}
