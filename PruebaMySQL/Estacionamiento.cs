//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Estacionamiento : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Estacionamiento()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Estacionamiento ORDER BY idEstacionamiento");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Envio env = new Envio();
            env.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacturaCliente fac = new FacturaCliente();
            fac.Show();
        }

        private void Estacionamiento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string numero = textBox1.Text;
            string numerodiscapacitados = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Estacionamiento (numero, numerodiscapacitados, idSucursal, estatus) values('" + numero + "', '" + numerodiscapacitados + "', '" + idSucursal + "', '" + estatus + "')";
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
            string numero = textBox1.Text;
            string numerodiscapacitados = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            int idEstacionamiento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Estacionamiento SET numero = '" + numero + "',numerodiscapacitados = '" + numerodiscapacitados + "',idSucursal = '" + idSucursal + "',estatus = '" + estatus + "' WHERE idEstacionamiento = " + idEstacionamiento.ToString();
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
            int idEstacionamiento = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Estacionamiento SET Estatus = 0 WHERE idEstacionamiento = " + idEstacionamiento.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
