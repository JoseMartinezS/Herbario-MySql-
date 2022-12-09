//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Proveedor : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Proveedor()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Proveedor ORDER BY idProveedor");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Producto producto = new Producto();
            producto.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Puesto puesto = new Puesto();
            puesto.Show();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            consulta = "INSERT INTO Proveedor (nombre, apellidoPaterno, apellidoMaterno, calle, numero, ciudad, telefono) values('" + nombre + "', '" + apellidoPaterno + "', '" + apellidoMaterno + "', '" + calle + "', '" + numero + "', '" + ciudad + "', '" + telefono + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            int idProveedor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Proveedor SET nombre = '" + nombre + "',apellidoPaterno = '" + apellidoPaterno + "',apellidoMaterno = '" + apellidoMaterno + "',calle = '" + calle + "', numero = '" + numero + "', ciudad = '" + ciudad + "', telefono = '" + telefono + "' WHERE idProveedor = " + idProveedor.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idProveedor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Proveedor SET Estatus = 0 WHERE idProveedor = " + idProveedor.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
