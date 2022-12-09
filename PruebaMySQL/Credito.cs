//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Credito : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Credito()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Credito ORDER BY idCredito");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cotizacion coti = new Cotizacion();
            coti.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery deli = new Delivery();
            deli.Show();
        }

        private void Credito_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string creditoDisponible = textBox1.Text;
            string creditoDebe = textBox2.Text;
            string fecha = textBox3.Text;
            consulta = "INSERT INTO Credito (creditoDisponible, creditoDebe, fecha) values('" + creditoDisponible + "', '" + creditoDebe + "', '" + fecha +  "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string creditoDisponible = textBox1.Text;
            string creditoDebe = textBox2.Text;
            string fecha = textBox3.Text;
            int idCredito = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Credito SET creditoDisponible = '" + creditoDisponible + "',creditoDebe = '" + creditoDebe + "',fecha = '" + fecha +  "' WHERE idCredito = " + idCredito.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idCredito = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Credito SET Estatus = 0 WHERE idCredito = " + idCredito.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
