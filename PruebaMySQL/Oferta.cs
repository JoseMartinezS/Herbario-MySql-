//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Oferta : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Oferta()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Oferta ORDER BY idOferta");
        }



        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paciente paciente = new Paciente();
            paciente.Show();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nomina nomi = new Nomina();
            nomi.Show();
        }

        private void Oferta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string producto = textBox1.Text;
            string precio = textBox2.Text;
            string precioanterior = textBox3.Text;
            string fecha = textBox4.Text;
            consulta = "INSERT INTO Oferta (producto, precio, precioanterior, fecha) values('" + producto + "', '" + precio + "', '" + precioanterior + "', '" + fecha + "')";
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
            string producto = textBox1.Text;
            string precio = textBox2.Text;
            string precioanterior = textBox3.Text;
            string fecha = textBox4.Text;
            int idOferta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Oferta SET producto = '" + producto + "',precio = '" + precio + "',precioanterior = '" + precioanterior + "',fecha = '" + fecha + "' WHERE idOferta = " + idOferta.ToString();
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
            int idOferta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Oferta SET Estatus = 0 WHERE idOferta = " + idOferta.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
