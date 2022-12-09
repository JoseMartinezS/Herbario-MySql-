//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Medicamento : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Medicamento()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Medicamento ORDER BY idMedicamento");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            MateriaPrima mat = new MateriaPrima();
            mat.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            MetodoPago met = new MetodoPago();
            met.Show();
        }

        private void Medicamento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string existencia = textBox2.Text;
            string salida = textBox3.Text;
            string idDoctor = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Medicamento (nombre, existencia, salida, idDoctor, estatus) values('" + nombre + "', '" + existencia + "', '" + salida + "', '" + idDoctor + "', '"+estatus +"')";
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
            string existencia = textBox2.Text;
            string salida = textBox3.Text;
            string idDoctor = textBox4.Text;
            string estatus = textBox5.Text;
            int idMedicamento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Medicamento SET nombre = '" + nombre + "',existencia = '" + existencia + "',salida = '" + salida + "',idDoctor = '" + idDoctor + "' , estatus = '" +estatus+ "' WHERE idMedicamento = " + idMedicamento.ToString();
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
            int idMedicamento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Medicamento SET Estatus = 0 WHERE idMedicamento = " + idMedicamento.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
