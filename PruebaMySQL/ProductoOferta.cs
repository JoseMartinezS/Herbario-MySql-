//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class ProductoOferta : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ProductoOferta()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM ProductoOferta ORDER BY idProductoOferta");
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            MarcaProducto marca = new MarcaProducto();
            marca.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoVenta producto = new ProductoVenta();
            producto.Show();
        }

        private void ProductoOferta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string idProducto = textBox1.Text;
            string idOferta = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO ProductoOferta (idProducto, idOferta, estatus) values('" + idProducto + "', '" + idOferta + "', '" + estatus + "')";
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
            string idOferta = textBox2.Text;
            string estatus = textBox3.Text;
            int idProductoOferta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ProductoOferta SET idProducto = '" + idProducto + "',idOferta = '" + idOferta + "',estatus = '" + estatus + "' WHERE idProductoOferta = " + idProductoOferta.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idProductoOferta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ProductoOferta SET Estatus = 0 WHERE idProductoOferta = " + idProductoOferta.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
