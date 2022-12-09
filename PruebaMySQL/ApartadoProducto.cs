//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class ApartadoProducto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ApartadoProducto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM ApartadoProducto ORDER BY idApartadoProducto");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venta venta = new Venta();
            venta.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClienteMetodoPago cliente = new ClienteMetodoPago();
            cliente.Show();
        }

        private void ApartadoProducto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string cantidad = textBox1.Text;
            string idApartado = textBox2.Text;
            string idProducto = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO ApartadoProducto (cantidad, idApartado, idProducto, estatus) values('" + cantidad + "', '" + idApartado + "', '" + idProducto + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string cantidad = textBox1.Text;
            string idApartado = textBox2.Text;
            string idProducto = textBox3.Text;
            string estatus = textBox4.Text;
            int idApartadoProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ApartadoProducto SET cantidad = '" + cantidad + "',idApartado = '" + idApartado + "',idProducto = '" + idProducto + "',estatus = '" + estatus + "' WHERE idApartadoProducto = " + idApartadoProducto.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idApartadoProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ApartadoProducto SET Estatus = 0 WHERE idApartadoProducto = " + idApartadoProducto.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
