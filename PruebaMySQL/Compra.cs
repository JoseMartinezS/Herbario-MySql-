//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Compra : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Compra()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Compra ORDER BY idCompra");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cliente cliente = new Cliente();
            cliente.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta consulta = new Consulta();
            consulta.Show();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cantidad = textBox1.Text;
            string fecha = textBox2.Text;
            string idComprobante = textBox3.Text;
            string idCotizacion = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Compra (cantidad, fecha, idComprobante, idCotizacion, estatus) values('" + cantidad + "', '" + fecha + "', '" + idComprobante + "', '" + idCotizacion + "', '"+ estatus+ "')";
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
            string cantidad = textBox1.Text;
            string fecha = textBox2.Text;
            string idComprobante = textBox3.Text;
            string idCotizacion = textBox4.Text;
            string estatus = textBox5.Text;
            int idCompra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Compra SET cantidad = '" + cantidad + "',fecha = '" + fecha + "',idComprobante = '" + idComprobante + "',idCotizacion = '" + idCotizacion + "', estatus = '" + estatus+ "' WHERE idCompra = " + idCompra.ToString();
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
            int idCompra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Compra SET Estatus = 0 WHERE idCompra = " + idCompra.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
