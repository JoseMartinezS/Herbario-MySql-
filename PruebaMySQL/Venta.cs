//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Venta : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Venta()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Venta ORDER BY idVenta");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sucursal sucu = new Sucursal();
            sucu.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApartadoProducto apar = new ApartadoProducto();
            apar.Show();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string fecha = textBox1.Text;
            string cantidad = textBox2.Text;
            consulta = "INSERT INTO Venta (fecha, cantidad) values('" + fecha + "', '" + cantidad +"')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string fecha = textBox1.Text;
            string cantidad = textBox2.Text;
            int idVenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Venta SET fecha = '" + fecha + "',cantidad = '" + cantidad +"' WHERE idVenta = " + idVenta.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idVenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Venta SET Estatus = 0 WHERE idVenta = " + idVenta.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
