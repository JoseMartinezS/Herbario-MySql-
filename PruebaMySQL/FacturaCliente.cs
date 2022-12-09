//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class FacturaCliente : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public FacturaCliente()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM FacturaCliente ORDER BY idFacturaCliente");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Estacionamiento est = new Estacionamiento();
            est.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacturaProveedor fac = new FacturaProveedor();
            fac.Show();
        }

        private void FacturaCliente_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string fecha = textBox1.Text;
            string remitente = textBox2.Text;
            string cantidad = textBox3.Text;
            string idContador = textBox4.Text;
            string idCliente = textBox5.Text;
            string estatus = textBox6.Text;
            consulta = "INSERT INTO FacturaCliente (fecha, remitente, cantidad, idContador, idCliente, estatus) values('" + fecha + "', '" + remitente + "', '" + cantidad + "', '" + idContador + "' , '" + idCliente + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string fecha = textBox1.Text;
            string remitente = textBox2.Text;
            string cantidad = textBox3.Text;
            string idContador = textBox4.Text;
            string idCliente = textBox5.Text;
            string estatus = textBox6.Text;
            int idFacturaCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE FacturaCliente SET fecha = '" + fecha + "',remitente = '" + remitente + "',cantidad = '" + cantidad + "',idContador = '" + idContador + "', idCliente = '" + idCliente + "', estatus = '" + estatus + "' WHERE idFacturaCliente = " + idFacturaCliente.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idFacturaCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE FacturaCliente SET Estatus = 0 WHERE idFacturaCliente = " + idFacturaCliente.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
