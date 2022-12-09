//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Instrumento : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Instrumento()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Instrumento ORDER BY idInstrumento");
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            HorarioTrabajo hor = new HorarioTrabajo();
            hor.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimiento man = new Mantenimiento();
            man.Show();
        }

        private void Instrumento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string tamaño = textBox2.Text;
            string marca = textBox3.Text;
            string idDoctor = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Instrumento (nombre, tamaño, marca, idDoctor, estatus) values('" + nombre + "', '" + tamaño + "', '" + marca + "', '" + idDoctor +"', '" +estatus+ "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string tamaño = textBox2.Text;
            string marca = textBox3.Text;
            string idDoctor = textBox4.Text;
            string estatus = textBox5.Text;
            int idInstrumento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Instrumento SET nombre = '" + nombre + "',tamaño = '" + tamaño + "',marca = '" + marca + "',idDoctor = '" + idDoctor + "', estatus = '"+estatus+"' WHERE idInstrumento = " + idInstrumento.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idInstrumento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Instrumento SET Estatus = 0 WHERE idInstrumento = " + idInstrumento.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
