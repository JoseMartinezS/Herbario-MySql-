//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Contrato : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Contrato()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Contrato ORDER BY idContrato");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contador cont = new Contador();
            cont.Show();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Convenio conv = new Convenio();
            conv.Show();
        }

        private void Contrato_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string servicio = textBox2.Text;
            string fecha = textBox3.Text;
            string idEmpleado = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Contrato (nombre, servicio, fecha, idEmpleado, estatus) values('" + nombre + "', '" + servicio + "', '" + fecha + "', '" + idEmpleado + "', '" +estatus +"')";
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
            string servicio = textBox2.Text;
            string fecha = textBox3.Text;
            string idEmpleado = textBox4.Text;
            string estatus = textBox5.Text;
            int idContrato = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Contrato SET nombre = '" + nombre + "',servicio = '" + servicio + "',fecha = '" + fecha + "',idEmpleado = '" + idEmpleado + "', estatus = '" +estatus+ "' WHERE idContrato = " + idContrato.ToString();
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
            int idContrato = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Contrato SET Estatus = 0 WHERE idContrato = " + idContrato.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
