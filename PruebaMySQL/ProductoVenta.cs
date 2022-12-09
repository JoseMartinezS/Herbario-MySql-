//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class ProductoVenta : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ProductoVenta()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM ProductoVenta ORDER BY idProductoVenta");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoOferta producto = new ProductoOferta();
            producto.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            SucursalEmpleado sucursal = new SucursalEmpleado();
            sucursal.Show();
        }

        private void ProductoVenta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string idProducto = textBox1.Text;
            string idVenta = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO ProductoVenta (idProducto, idVenta, idDoctor) values('" + idProducto + "', '" + idVenta + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string idProducto = textBox1.Text;
            string idVenta = textBox2.Text;
            string estatus = textBox3.Text;
            int idProductoVenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ProductoVenta SET idProducto = '" + idProducto + "',idVenta = '" + idVenta + "',estatus = '" + estatus + "' WHERE idProductoVenta = " + idProductoVenta.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idProductoVenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ProductoVenta SET Estatus = 0 WHERE idProductoVenta = " + idProductoVenta.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


        }
    }
}
