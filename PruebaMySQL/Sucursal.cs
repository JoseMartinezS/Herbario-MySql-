//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Sucursal : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Sucursal()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Sucursal ORDER BY idSucursal");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transporte trans = new Transporte();
            trans.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venta venta = new Venta();
            venta.Show();
        }

        private void Sucursal_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string calle = textBox2.Text;
            string estado = textBox3.Text;
            string colonia = textBox4.Text;
            string ciudad = textBox5.Text;
            string telefono = textBox6.Text;
            consulta = "INSERT INTO Sucursal (nombre, calle, estado, colonia, ciudad, telefono) values('" + nombre + "', '" + calle + "', '" + estado + "', '" + colonia + "', '" + ciudad + "', '" + telefono + "')";
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
            string nombre = textBox1.Text;
            string calle = textBox2.Text;
            string estado = textBox3.Text;
            string colonia = textBox4.Text;
            string ciudad = textBox5.Text;
            string telefono = textBox6.Text;
            int idSucursal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Sucursal SET nombre = '" + nombre + "',calle = '" + calle + "',estado = '" + estado + "',colonia = '" + colonia + "', ciudad = '" + ciudad + "', telefono = '" + telefono +"' WHERE idSucursal = " + idSucursal.ToString();
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
            int idSucursal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Sucursal SET Estatus = 0 WHERE idSucursal = " + idSucursal.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
