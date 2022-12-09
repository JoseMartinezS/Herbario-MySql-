//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class ClienteMetodoPago : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ClienteMetodoPago()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM ClienteMetodoPago ORDER BY idClienteMetodoPago");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApartadoProducto apartado = new ApartadoProducto();
            apartado.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompraCliente compra = new CompraCliente();
            compra.Show();
        }

        private void ClienteMetodoPago_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string idCliente = textBox1.Text;
            string idMetodoPago = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO ClienteMetodoPago (idCliente, idMetodoPago, estatus) values('" + idCliente + "', '" + idMetodoPago + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string idCliente = textBox1.Text;
            string idMetodoPago = textBox2.Text;
            string estatus = textBox3.Text;
            int idClienteMetodoPago = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ClienteMetodoPago SET idCliente = '" + idCliente + "',idMetodoPago = '" + idMetodoPago + "',estatus = '" + estatus + "' WHERE idClienteMetodoPago = " + idClienteMetodoPago.ToString();
            conexion.Open();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idClienteMetodoPago = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ClienteMetodoPago SET Estatus = 0 WHERE idClienteMetodoPago = " + idClienteMetodoPago.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
