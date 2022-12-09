//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Mobiliario : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Mobiliario()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Mobiliario ORDER BY idMobiliario");
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nomina nomi = new Nomina();
            nomi.Show();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            MetodoPago met = new MetodoPago();
            met.Show();
        }

        private void Mobiliario_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string cantidad = textBox2.Text;
            string material = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Mobiliario (nombre, cantidad, material, idSucursal, estatus) values('" + nombre + "', '" + cantidad + "', '" + material + "', '" + idSucursal + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string cantidad = textBox2.Text;
            string material = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            int idMobiliario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mobiliario SET nombre = '" + nombre + "',cantidad = '" + cantidad + "',material = '" + material + "',idSucursal = '" + idSucursal + "'. estatus = '" + estatus + "' WHERE idMobiliario = " + idMobiliario.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            //Borrar
            int idMobiliario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Mobiliario SET Estatus = 0 WHERE idMobiliario = " + idMobiliario.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
