//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Empleado : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Empleado()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Empleado ORDER BY idEmpleado");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor doc = new Doctor();
            doc.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empresa emp = new Empresa();
            emp.Show();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string puesto = textBox1.Text;
            string sueldo = textBox2.Text;
            string nombre = textBox3.Text;
            string apellidop = textBox4.Text;
            string apellidom = textBox5.Text;
            string calle = textBox6.Text;
            string numero = textBox7.Text;
            string ciudad = textBox8.Text;
            string telefono = textBox9.Text;
            consulta = "INSERT INTO Empleado (puesto, sueldo, nombre, apellidop, apellidom, calle, numero, ciudad, telefono) values('" + puesto + "', '" + sueldo + "', '" + nombre + "', '" + apellidop + "' , '" + apellidom + "', '" + calle + "', '" + numero + "', '" +ciudad + "', '"+telefono +"')";
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
            string puesto = textBox1.Text;
            string sueldo = textBox2.Text;
            string nombre = textBox3.Text;
            string apellidop = textBox4.Text;
            string apellidom = textBox5.Text;
            string calle = textBox6.Text;
            string numero = textBox7.Text;
            string ciudad = textBox8.Text;
            string telefono = textBox9.Text;
            int idEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Empleado SET puesto = '" + puesto + "',sueldo = '" + sueldo + "',nombre = '" + nombre + "',apellidop = '" + apellidop + "', apellidom = '" + apellidom + "', calle = '" + calle + "', numero = '" + numero + "', ciudad = '" + ciudad + "', telefono ='" + telefono+ "' WHERE idEmpleado = " + idEmpleado.ToString();
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
            int idEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Empleado SET Estatus = 0 WHERE idEmpleado = " + idEmpleado.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


        }
    }
}
