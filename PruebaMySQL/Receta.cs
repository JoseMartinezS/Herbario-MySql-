//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Receta : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Receta()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Receta ORDER BY idReceta");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Puesto puesto = new Puesto();
            puesto.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Representante repre = new Representante();
            repre.Show();
        }

        private void Receta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string descripcion = textBox1.Text;
            string medicamento = textBox2.Text;
            string cantidad = textBox3.Text;
            string idDoctor = textBox4.Text;
            string idPaciente = textBox5.Text;
            string estatus = textBox6.Text;
            consulta = "INSERT INTO Receta (descripcion, medicamento, cantidad, idDoctor, idPaciente, estatus) values('" + descripcion + "', '" + medicamento + "', '" + cantidad + "', '" + idDoctor + "', '" + idPaciente + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string descripcion = textBox1.Text;
            string medicamento = textBox2.Text;
            string cantidad = textBox3.Text;
            string idDoctor = textBox4.Text;
            string idPaciente = textBox5.Text;
            string estatus = textBox6.Text;
            int idReceta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Receta SET descripcion = '" + descripcion + "',medicamento = '" + medicamento + "',cantidad = '" + cantidad + "',idDoctor = '" + idDoctor + "', idPaciente = '" + idPaciente + "', estatus = '" + estatus + "' WHERE idReceta = " + idReceta.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idReceta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Receta SET Estatus = 0 WHERE idReceta = " + idReceta.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
