//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class MarcaProducto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public MarcaProducto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM MarcaProducto ORDER BY idMarcaProducto");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpleadoCapacitacion empleado = new EmpleadoCapacitacion();
            empleado.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoOferta producto = new ProductoOferta();
            producto.Show();
        }

        private void MarcaProducto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string idMarca = textBox1.Text;
            string idProducto = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO MarcaProducto (idMarca, idProducto, estatus) values('" + idMarca + "', '" + idProducto + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string idMarca = textBox1.Text;
            string idProducto = textBox2.Text;
            string estatus = textBox3.Text;
            int idMarcaProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MarcaProducto SET idMarca = '" + idMarca + "',idProducto = '" + idProducto + "',estatus = '" + estatus + "' WHERE idMarcaProducto = " + idMarcaProducto.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idMarcaProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE MarcaProducto SET Estatus = 0 WHERE idMarcaProducto = " + idMarcaProducto.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
