//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Delivery : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Delivery()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Delivery ORDER BY idDelivery");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Credito credi = new Credito();
            credi.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Departamento deli = new Departamento();
            deli.Show();
        }

        private void Delivery_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cantidad = textBox1.Text;
            string producto = textBox2.Text;
            string direccion = textBox3.Text;
            string horasalida = textBox4.Text;
            string horallegada = textBox5.Text;
            string idSucursal = textBox6.Text;
            string estatus = textBox7.Text;
            consulta = "INSERT INTO Delivery (antidad, producto, direccion, horasalida, horallegada, idSucursal, estatus) values('" + cantidad + "', '" + producto + "', '" + direccion + "', '" + horasalida + "' , '" + horallegada + "', '" + idSucursal + "', '" + estatus + "')";
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
            string cantidad = textBox1.Text;
            string producto = textBox2.Text;
            string direccion = textBox3.Text;
            string horasalida = textBox4.Text;
            string horallegada = textBox5.Text;
            string idSucursal = textBox6.Text;
            string estatus = textBox7.Text;
            int idDelivery = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Delivery SET cantidad = '" + cantidad + "',producto = '" + producto + "',direccion = '" + direccion + "',horasalida = '" + horasalida + "', horallegada = '" + horallegada + "', idSucursal = '" + idSucursal + "', estatus = '" + estatus + "' WHERE idContador = " + idDelivery.ToString();
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
            int idDelivery = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Delivery SET Estatus = 0 WHERE idDelivery = " + idDelivery.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
