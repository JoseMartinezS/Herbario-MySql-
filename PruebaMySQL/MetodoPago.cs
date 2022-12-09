//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class MetodoPago : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public MetodoPago()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM MetodoPago ORDER BY idMetodoPago");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicamento medi = new Medicamento();
            medi.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mobiliario mobi = new Mobiliario();
            mobi.Show();
        }

        private void MetodoPago_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string tipo = textBox1.Text;
            consulta = "INSERT INTO MetodoPago (tipo) values('" + tipo + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string tipo = textBox1.Text;
            int idMetodoPago = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MetodoPago SET tipo = '" + tipo + "' WHERE idMetodoPago = " + idMetodoPago.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idMetodoPago = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE MetodoPago SET Estatus = 0 WHERE idMetodoPago = " + idMetodoPago.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
