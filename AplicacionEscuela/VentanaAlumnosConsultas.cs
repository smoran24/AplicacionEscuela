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
    public partial class VentanaAlumnosConsultas : Form
    {
        Alumno alu = new Alumno(); //creo el objeto para usarlo a lo largo de esta ventana
        

        public VentanaAlumnosConsultas()
        {
            InitializeComponent();
            refrescarTabla(); //al iniciar muestra la datagridview para poder ver la base de datos
            btnAgregar.Enabled = false;
        }

        public void refrescarTabla()
        {
            MySqlDataAdapter da = GestorDB.RefrescarDB(1); //1 indica que se refrescará la tabla de alumnos
            DataSet ds = new DataSet(); //crea data set para llenar la datagrid
            da.Fill(ds, "alumnos"); //llena con la tabla indicada el adaptador de datos
            dgvAlumnos.DataSource = ds.Tables["alumnos"].DefaultView; //llena la datagridview usando los datos de la tabla indicada
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMostrarRegistros_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellido.Text) || String.IsNullOrEmpty(txtLegajo.Text) || String.IsNullOrEmpty(txtDNI.Text) || String.IsNullOrEmpty(txtEmail.Text) || cmbTurno.SelectedIndex == -1)
            {
                MessageBox.Show("Error: Debe completar todos los campos para añadir un elemento");
            }
            else
            {
                string p_nombre = txtNombre.Text;
                string p_apellido = txtApellido.Text;
                string p_email = txtEmail.Text;
                string p_turno = cmbTurno.Text;
                int p_legajo;
                int p_dni;
                try
                {
                    p_legajo = int.Parse(txtLegajo.Text); //convierto a int lo que este en el textbox. Si no funciona, tirará excepción
                    p_dni = int.Parse(txtDNI.Text); //idem
                    alu.setTurno(p_turno);
                    alu.setLegajo(p_legajo);
                    alu.setNombre(p_nombre);
                    alu.setApellido(p_apellido);
                    alu.setEmail(p_email);
                    alu.setDni(p_dni);
                    alu.Agregar(); //llamo al método de la clase para hacer un alta con esta instancia de la clase
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
            if (dgvAlumnos.SelectedRows.Count == 0) //si no se ha seleccionado una fila para borrar, larga error
            {
                MessageBox.Show("Error: No se ha seleccionado un registro para borrar");
            }else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar este registro?", "Confirmar acción", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int indiceElegido = dgvAlumnos.SelectedRows[0].Index; //puntero que indica la fila seleccionada
                    int IDfila = Convert.ToInt32(dgvAlumnos[0, indiceElegido].Value); //obtiene y convierte a int lo que esté en la fila del datagrid
                    alu.setID(IDfila);
                    alu.Borrar();
                    MessageBox.Show("Registro borrado con éxito");
                    refrescarTabla();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count == 0) //si no se ha seleccionado una fila para editar, larga error
            {
                MessageBox.Show("Error: No se ha seleccionado un registro para modificar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea alterar este registro?", "Confirmar acción", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int indiceElegido = dgvAlumnos.SelectedRows[0].Index; //puntero que indica la fila seleccionada
                    int IDfila = Convert.ToInt32(dgvAlumnos[0, indiceElegido].Value); //obtiene y convierte a int lo que esté en la fila del datagrid
                    string p_nombre = txtNombre.Text;
                    string p_apellido = txtApellido.Text;
                    string p_email = txtEmail.Text;
                    string p_turno = cmbTurno.Text;
                    int p_legajo = int.Parse(txtLegajo.Text); //convierto a int lo que este en el textbox
                    int p_dni = int.Parse(txtDNI.Text); //idem
                    alu.setNombre(p_nombre);
                    alu.setApellido(p_apellido);
                    alu.setEmail(p_email);
                    alu.setTurno(p_turno);
                    alu.setLegajo(p_legajo);
                    alu.setDni(p_dni);
                    alu.setID(IDfila);
                    alu.Modificar();
                    MessageBox.Show("Registro modificado con éxito");
                    refrescarTabla();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //guarda todas las filas del dgv
                DataGridViewRow row = this.dgvAlumnos.Rows[e.RowIndex];
                //llena las textbox con los valores de cada columna a partir del indice 1 (el 0 es el ID)
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtApellido.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtDNI.Text = row.Cells[4].Value.ToString();
                cmbTurno.Text = row.Cells[5].Value.ToString();
                txtLegajo.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtDNI.Text = "";
            cmbTurno.Text = "";
            txtLegajo.Text = "";
            btnAgregar.Enabled = true;
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter da = GestorDB.RefrescarDB(1); //1 indica que se refrescará la tabla de alumnos
            DataSet ds = new DataSet();
            da.Fill(ds, "alumnos");

            DataView dv = ds.Tables["alumnos"].DefaultView;
            dv.RowFilter = string.Format("convert(dni, 'System.String') Like '%{0}%' ", txtBusqueda.Text);
            dgvAlumnos.DataSource = dv;
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
