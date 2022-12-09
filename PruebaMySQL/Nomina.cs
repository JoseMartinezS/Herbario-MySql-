//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Nomina : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Nomina()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Nomina ORDER BY idNomina");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mobiliario mob = new Mobiliario();
            mob.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Oferta oferta = new Oferta();
            oferta.Show();
        }

        private void Nomina_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string numero = textBox1.Text;
            string persona = textBox2.Text;
            string fecha = textBox3.Text;
 
            consulta = "INSERT INTO Nomina (numero, persona, fecha) values('" + numero + "', '" + persona
                + "', '" + fecha + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string numero = textBox1.Text;
            string persona = textBox2.Text;
            string fecha = textBox3.Text;
            int idNomina = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Nomina SET numero = '" + numero + "',persona = '" + persona + "',fecha = '" + fecha + "' WHERE idNomina = " + idNomina.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idNomina = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Nomina SET Estatus = 0 WHERE idNomina = " + idNomina.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
