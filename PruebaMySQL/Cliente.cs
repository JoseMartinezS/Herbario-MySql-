//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Cliente : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Cliente()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Cliente ORDER BY idCliente");
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cita cita = new Cita();
            cita.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Compra Compra = new Compra();
            Compra.Show();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string curp = textBox4.Text;
            string calle = textBox5.Text;
            string numero = textBox6.Text;
            string estado = textBox7.Text;
            string telefono = textBox8.Text;
            string idCredito = textBox9.Text;
            string estatus = textBox10.Text;
            consulta = "INSERT INTO Cliente (nombre, apellidoPaterno, apellidoMaterno, curp, calle, numero, estado, telefono, idCredito, estatus) values('" + nombre + "', '" + apellidoPaterno + "', '" + apellidoMaterno + "', '" + curp + "', '" + calle + "', '" +numero +"', '" +estado + "', '" + telefono + "', '" +idCredito+ "', '" +estado+"')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string curp = textBox4.Text;
            string calle = textBox5.Text;
            string numero = textBox6.Text;
            string estado = textBox7.Text;
            string telefono = textBox8.Text;
            string idCredito = textBox9.Text;
            string estatus = textBox10.Text;
            int idCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Cliente SET nombre = '" + nombre + "',apellidoPaterno = '" + apellidoPaterno + "',apellidoMaterno = '" + apellidoMaterno + "',curp = '" + curp + "', calle = '" +calle + "', numero = '" +numero + "', estado = '" + estado +"', telefono = '" +telefono + "', idCredito = '" + idCredito + "', estatus = '" +estatus+  "' WHERE idCliente = " + idCliente.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
