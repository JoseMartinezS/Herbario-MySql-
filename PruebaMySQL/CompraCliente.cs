//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class CompraCliente : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public CompraCliente()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM CompraCliente ORDER BY idCompraCliente");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClienteMetodoPago cliente = new ClienteMetodoPago();
            cliente.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpleadoCapacitacion empleado = new EmpleadoCapacitacion();
            empleado.Show();
        }

        private void CompraCliente_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string idCompra = textBox1.Text;
            string idCliente = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO CompraCliente (idCompra, idCliente, estatus) values('" + idCompra + "', '" + idCliente + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string idCompra = textBox1.Text;
            string idCliente = textBox2.Text;
            string estatus = textBox3.Text;
            int idCompraCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE CompraCliente SET idCompra = '" + idCompra + "',idCliente = '" + idCliente + "',estatus = '" + estatus +"' WHERE idCompraCliente = " + idCompraCliente.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idCompraCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE CompraCliente SET Estatus = 0 WHERE idCompraCliente = " + idCompraCliente.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
