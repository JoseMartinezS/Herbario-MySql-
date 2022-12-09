//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Prestacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Prestacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Prestacion ORDER BY idPrestacion");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pedido pedi = new Pedido();
            pedi.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Produccion produ = new Produccion();
            produ.Show();
        }

        private void Prestacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string clasificacion = textBox1.Text;
            string descripcion = textBox2.Text;
            consulta = "INSERT INTO Prestacion (clasificacion, descripcion) values('" + clasificacion + "', '" + descripcion + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string clasificacion = textBox1.Text;
            string descripcion = textBox2.Text;
            int idPrestacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Prestacion SET clasificacion = '" + clasificacion + "',descrpcion = '" + descripcion +"' WHERE idPrestacion = " + idPrestacion.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idPrestacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Prestacion SET Estatus = 0 WHERE idPrestacion = " + idPrestacion.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
