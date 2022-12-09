//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PruebaMySQL
{
    public partial class Caja : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Caja()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            consulta = "SELECT *FROM Caja";
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Caja ORDER BY idCaja");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bodega bodega = new Bodega();
            bodega.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Capacitacion capa = new Capacitacion();
            capa.Show();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string numer = textBox1.Text;
            string persona = textBox2.Text;
            string computadora = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Caja (numer, persona, computadora, idSucursal, estatus) values('" + numer + "', '" + persona + "', '" + computadora + "', '" + idSucursal+ "' , '" + estatus + "')";
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
            string numer = textBox1.Text;
            string persona = textBox2.Text;
            string computadora = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            int idCaja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Caja SET numer = '" + numer + "',persona = '" + persona + "',computadora = '" + computadora + "', idSucursal = '" + idSucursal + "',estatus = '" + estatus + "' WHERE idCaja = " + idCaja.ToString();
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
            int idCaja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Caja SET Estatus = 0 WHERE idCaja = " + idCaja.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
