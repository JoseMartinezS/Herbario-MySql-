//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class SucursalEmpleado : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public SucursalEmpleado()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM SucursalEmpleado ORDER BY idSucursalEmpleado");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoVenta producto = new ProductoVenta();
            producto.Show();
        }

        private void SucursalEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string idSucursal = textBox1.Text;
            string idEmpleado = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO SucursalEmpleado (idSucursal, idEmpleado, estatus) values('" + idSucursal + "', '" + idEmpleado + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string idSucursal = textBox1.Text;
            string idEmpleado = textBox2.Text;
            string estatus = textBox3.Text;
            int idSucursalEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SucursalEmpleado SET idSucursal = '" + idSucursal + "',idEmpleado = '" + idEmpleado + "',estatus = '" + estatus + "' WHERE idSucursalEmpleado = " + idSucursalEmpleado.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idSucursalEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE SucursalEmpleado SET Estatus = 0 WHERE idSucursalEmpleado = " + idSucursalEmpleado.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
