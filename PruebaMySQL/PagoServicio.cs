//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class PagoServicio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public PagoServicio()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM PagoServicio ORDER BY idPagoServicio");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paciente pacie = new Paciente();
            pacie.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paquete paque = new Paquete();
            paque.Show();
        }

        private void PagoServicio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string cantidad = textBox1.Text;
            string servicio = textBox2.Text;
            string fecha = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO PagoServicio (cantidad, servicio, fecha, idSucursal, estatus) values('" + cantidad + "', '" + servicio + "', '" + fecha + "', '" + idSucursal + "', '" +estatus+ "')";
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
            string servicio = textBox2.Text;
            string fecha = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            int idPagoServicio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PagoServicio SET cantidad = '" + cantidad + "',servicio = '" + servicio + "',fecha = '" + fecha + "',idSucursal = '" + idSucursal + "', estatus = '" +estatus + "' WHERE idPagoServicio = " + idPagoServicio.ToString();
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
            int idPagoServicio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE PagoServicio SET Estatus = 0 WHERE idPagoServicio = " + idPagoServicio.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
