//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PruebaMySQL
{
    public partial class Envio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Envio()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Envio ORDER BY idEnvio");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empresa emp = new Empresa();
            emp.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Estacionamiento est = new Estacionamiento();
            est.Show();
        }

        private void Envio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string fechasalida = textBox1.Text;
            string fechallegada = textBox2.Text;
            string productos = textBox3.Text;
            string cantidad = textBox4.Text;
            consulta = "INSERT INTO Envio (fechasalida, fechallegada, productos, cantidad) values('" + fechasalida + "', '" + fechallegada + "', '" + productos + "', '" + cantidad + "')";
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
            string fechasalida = textBox1.Text;
            string fechallegada = textBox2.Text;
            string productos = textBox3.Text;
            string cantidad = textBox4.Text;
            int idEnvio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Envio SET fechasalida = '" + fechasalida + "',fechallegada = '" + fechallegada + "',productos = '" + productos + "',cantidad = '" + cantidad + "' WHERE idEnvio = " + idEnvio.ToString();
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
            int idEnvio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Envio SET Estatus = 0 WHERE idEnvio = " + idEnvio.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
