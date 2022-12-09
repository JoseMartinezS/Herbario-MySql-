//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Departamento : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Departamento()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Departamento ORDER BY idDepartamento");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery deli = new Delivery();
            deli.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Devolucion devo = new Devolucion();
            devo.Show();
        }

        private void Departamento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string numero = textBox2.Text;
            string cantidad = textBox3.Text;
            consulta = "INSERT INTO Departamento (nombre, numero, cantidad) values('" + nombre + "', '" + numero + "', '" + cantidad + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string numero = textBox2.Text;
            string cantidad = textBox3.Text;
            int idDepartamento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Departamento SET nombre = '" + nombre + "',numero = '" + numero + "',cantidad = '" + cantidad + "' WHERE idDepartamento = " + idDepartamento.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idDepartamento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Departamento SET Estatus = 0 WHERE idDepartamento = " + idDepartamento.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


        }
    }
}
