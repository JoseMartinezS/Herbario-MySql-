//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Representante : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Representante()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();;
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Representante ORDER BY idRepresentante");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receta rece = new Receta();
            rece.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transporte trans = new Transporte();
            trans.Show();
        }

        private void Representante_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            string idEmpresa = textBox8.Text;
            string estatus = textBox9.Text;
            consulta = "INSERT INTO Representante (nombre, apellidoPaterno, apellidoMaterno, calle, numero, ciudad, telefono, idEmpresa, estatus) values('" + nombre + "', '" + apellidoPaterno + "', '" + apellidoMaterno + "', '" + calle + "', '" + numero + "', '" + ciudad + "', '" + telefono + "', '" + idEmpresa +"', '"+ estatus +"')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            string idEmpresa = textBox8.Text;
            string estatus = textBox9.Text;
            int idRepresentante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Representante SET nombre = '" + nombre + "',apellidoPaterno = '" + apellidoPaterno + "',apellidoMaterno = '" + apellidoMaterno + "',calle = '" + calle + "', numero = '" + numero + "', ciudad = '" + ciudad + "', telefono = '" + telefono + "', idEmpresa = '" + idEmpresa + "', estatus = '" +estatus+ "' WHERE idRepresentante = " + idRepresentante.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idRepresentante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Representante SET Estatus = 0 WHERE idRepresentante = " + idRepresentante.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
