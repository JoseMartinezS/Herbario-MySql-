//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Convenio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Convenio()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Convenio ORDER BY idConvenio");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contrato cont = new Contrato();
            cont.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cotizacion coti = new Cotizacion();
            coti.Show();
        }

        private void Convenio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string cantidad = textBox1.Text;
            string fecha = textBox2.Text;
            string idCliente = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Convenio (cantidad, fecha, idCliente, estatus) values('" + cantidad + "', '" + fecha + "', '" + idCliente + "', '" + estatus + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string cantidad = textBox1.Text;
            string fecha = textBox2.Text;
            string idCliente = textBox3.Text;
            string estatus = textBox4.Text;
            int idConvenio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Convenio SET cantidad = '" + cantidad + "',fecha = '" + fecha + "',idCliente = '" + idCliente + "',estatus = '" + estatus + "' WHERE idConvenio = " + idConvenio.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idConvenio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Convenio SET Estatus = 0 WHERE idConvenio = " + idConvenio.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


        }
    }
}
