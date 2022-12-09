//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Consulta : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Consulta()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Consulta ORDER BY idConsulta");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Compra compra = new Compra();
            compra.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Comprobante comp = new Comprobante();
            comp.Show();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string precio = textBox2.Text;
            string fecha = textBox3.Text;
            string idPaciente = textBox4.Text;
            string idDoctor = textBox5.Text;
            string estatus = textBox6.Text;
            consulta = "INSERT INTO Consulta (nombre, precio, fecha, idPaciente, idDoctor, estatus) values('" + nombre + "', '" + precio + "', '" + fecha + "', '" + idPaciente + "', '" +idDoctor + "', '"+estatus + "')";
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
            string nombre = textBox1.Text;
            string precio = textBox2.Text;
            string fecha = textBox3.Text;
            string idPaciente = textBox4.Text;
            string idDoctor = textBox5.Text;
            string estatus = textBox6.Text;
            int idConsulta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Consulta SET nombre = '" + nombre + "',precio = '" + precio + "',fecha = '" + fecha + "',idPaciente = '" + idPaciente + "', idDoctor = '" +idDoctor + "', estatus = '" +estatus + "' WHERE idConsulta = " + idConsulta.ToString();
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
            int idConsulta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Consulta SET Estatus = 0 WHERE idConsulta = " + idConsulta.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
