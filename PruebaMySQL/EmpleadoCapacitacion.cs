//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class EmpleadoCapacitacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public EmpleadoCapacitacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM EmpleadoCapacitacion ORDER BY idEmpleadoCapacitacion");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompraCliente compra = new CompraCliente();
            compra.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            MarcaProducto marca = new MarcaProducto();
            marca.Show();
        }

        private void EmpleadoCapacitacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string idEmpleado = textBox1.Text;
            string idCapacitacion = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO EmpleadoCapacitacion (idEmpleado, idCapacitacion, estatus) values('" + idEmpleado + "', '" + idCapacitacion + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string idEmpleado = textBox1.Text;
            string idCapacitacion = textBox2.Text;
            string estatus = textBox3.Text;
            int idEmpleadoCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EmpleadoCapacitacion SET idEmpleado = '" + idEmpleado + "',idCapacitacion = '" + idCapacitacion + "',estatus = '" + estatus + "' WHERE idEmpleadoCapacitacion = " + idEmpleadoCapacitacion.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idEmpleadoCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE EmpleadoCapacitacion SET Estatus = 0 WHERE idEmpleadoCapacitacion = " + idEmpleadoCapacitacion.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
