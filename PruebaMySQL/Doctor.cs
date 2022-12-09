//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Doctor : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Doctor()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Doctor ORDER BY idDoctor");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Devolucion devo = new Devolucion();
            devo.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empleado emp = new Empleado();
            emp.Show();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string apellidop = textBox2.Text;
            string apellidom = textBox3.Text;
            consulta = "INSERT INTO Doctor (nombre, apellidop, apellidom, estatus) values('" + nombre + "', '" + apellidop + "', '" + apellidom +  "')";
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
            string apellidop = textBox2.Text;
            string apellidom = textBox3.Text;
            int idDoctor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Doctor SET nombre = '" + nombre + "',apellidop = '" + apellidop + "',apellidom = '" + apellidom +  "' WHERE idDoctor = " + idDoctor.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idDoctor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Doctor SET Estatus = 0 WHERE idDoctor = " + idDoctor.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
