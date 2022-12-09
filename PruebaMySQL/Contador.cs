//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{

    public partial class Contador : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Contador()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Contador ORDER BY idContador");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Comprobante comp = new Comprobante();
            comp.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contrato cont = new Contrato();
            cont.Show();
        }

        private void Contador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string apellidop = textBox2.Text;
            string apellidom = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            consulta = "INSERT INTO Contador (nombre, apellidop, apellidom, calle, numero, ciudad, telefono) values('" + nombre + "', '" + apellidop + "', '" + apellidom + "', '" + calle + "' , '" +numero+ "', '" + ciudad + "', '" +telefono + "')";
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
            string apellidop = textBox2.Text;
            string apellidom = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            int idContador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Contador SET nombre = '" + nombre + "',apellidop = '" + apellidop + "',apellidom = '" + apellidom + "',calle = '" + calle +"', numero = '" + numero + "', ciudad = '" +ciudad + "', telefono = '" + telefono +  "' WHERE idContador = " + idContador.ToString();
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
            int idContador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Contador SET Estatus = 0 WHERE idContador = " + idContador.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
