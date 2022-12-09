//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Produccion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Produccion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Produccion ORDER BY idProduccion");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Prestacion pre = new Prestacion();
            pre.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Producto produ = new Producto();
            produ.Show();
        }

        private void Produccion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string cantidadFinal = textBox1.Text;
            string ingresos = textBox2.Text;
            consulta = "INSERT INTO Produccion (cantidadFinal, ingresos) values('" + cantidadFinal + "', '" + ingresos +  "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string cantidadFinal = textBox1.Text;
            string ingresos = textBox2.Text;
            int idProduccion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Produccion SET cantidadFinal = '" + cantidadFinal + "',ingresos = '" + ingresos + "' WHERE idProduccion = " + idProduccion.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idProduccion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Produccion SET Estatus = 0 WHERE idProduccion = " + idProduccion.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
