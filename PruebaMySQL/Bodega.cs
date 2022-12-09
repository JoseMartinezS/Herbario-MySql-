//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Bodega : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Bodega()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Bodega ORDER BY idBodega");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Apartado apartado = new Apartado();
            apartado.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Caja caja = new Caja();
            caja.Show();
        }

        private void Bodega_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string calle = textBox2.Text;
            string numero = textBox3.Text;
            string ciudad = textBox4.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Bodega (nombre, calle, numero, ciudad, idSucursal, estatus) values('" + nombre + "', '" + calle + "', '" + numero + "', '"+ciudad +"', '"+ idSucursal +"', '" + estatus + "')";
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
            string nombre = textBox1.Text;
            string calle = textBox2.Text;
            string numero = textBox3.Text;
            string ciudad = textBox4.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox4.Text;
            int idBodega = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Bodega SET nombre = '" + nombre + "',calle = '" + calle + "',numero = '" + numero + "', ciudad '" + ciudad + "', idSucursal '" + idSucursal + "',estatus = '" + estatus + "' WHERE idBodega = " + idBodega.ToString();
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
            int idBodega = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Bodega SET Estatus = 0 WHERE idBodega = " + idBodega.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
