//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Empresa : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Empresa()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Empresa ORDER BY idEmpresa");
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empleado emp = new Empleado();
            emp.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Envio env = new Envio();
            env.Show();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;
            string calle = textBox3.Text;
            string estado = textBox4.Text;
            string numero = textBox5.Text;
            string colonia = textBox6.Text;
            string ciudad = textBox7.Text;
            consulta = "INSERT INTO Empresa(nombre, telefono, calle, estado, numero, colonia, ciudad) values('" + nombre + "', '" + telefono + "', '" + calle + "', '" + estado + "' , '" + numero + "', '" + colonia + "', '" + ciudad + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;
            string calle = textBox3.Text;
            string estado = textBox4.Text;
            string numero = textBox5.Text;
            string colonia = textBox6.Text;
            string ciudad = textBox7.Text;
            int idEmpresa = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Empresa SET nombre = '" + nombre + "',telefono = '" + telefono + "',calle = '" + calle + "',estado = '" + estado + "', numero = '" + numero + "', colonia = '" + colonia + "', ciudad = '" + ciudad + "' WHERE idEmpresa = " + idEmpresa.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            //Borrar
            int idEmpresa = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Empresa SET Estatus = 0 WHERE idEmpresa = " + idEmpresa.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
