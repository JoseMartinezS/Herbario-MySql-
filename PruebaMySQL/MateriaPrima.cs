//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class MateriaPrima : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public MateriaPrima()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM MateriaPrima ORDER BY idMateriaPrima");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marketing mar = new Marketing();
            mar.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicamento medi = new Medicamento();
            medi.Show();
        }

        private void MateriaPrima_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string material = textBox1.Text;
            string nombre = textBox2.Text;
            string cantidad = textBox3.Text;
            consulta = "INSERT INTO MateriaPrima (material, nombre, cantidad) values('" + material + "', '" + nombre + "', '" + cantidad + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string material = textBox1.Text;
            string nombre = textBox2.Text;
            string cantidad = textBox3.Text;
            int idMateriaPrima = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MateriaPrima SET material = '" + material + "',nombre = '" + nombre + "',cantidad = '" + cantidad + "' WHERE idMateriaPrima = " + idMateriaPrima.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
          
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idMateriaPrima = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE MateriaPrima SET Estatus = 0 WHERE idMateriaPrima = " + idMateriaPrima.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
