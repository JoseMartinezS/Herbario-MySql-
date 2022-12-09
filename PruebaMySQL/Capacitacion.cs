//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Capacitacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Capacitacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            consulta = "SELECT *FROM Capacitacion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Capacitacion");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Capacitacion"];
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Caja caja = new Caja();
            caja.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cita cita = new Cita();
            cita.Show();
        }

        private void Capacitacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string tipo = textBox2.Text;
            string numero = textBox3.Text;
            consulta = "INSERT INTO Capacitacion (nombre, tipo, numero) values('" + nombre + "', '" + tipo + "', '" + numero + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string tipo = textBox2.Text;
            string numero = textBox3.Text;
            int idCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Capacitacion SET nombre = '" + nombre + "',tipo = '" + tipo + "',numero = '" + numero + "' WHERE idCapacitacion = " + idCapacitacion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Capacitacion SET Estatus = 0 WHERE idCapacitacion = " + idCapacitacion.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }
    }
}
