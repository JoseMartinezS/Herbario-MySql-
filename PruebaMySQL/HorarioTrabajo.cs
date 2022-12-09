//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class HorarioTrabajo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public HorarioTrabajo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM HorarioTrabajo ORDER BY idHorarioTrabajo");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacturaProveedor fac = new FacturaProveedor();
            fac.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instrumento ins = new Instrumento();
            ins.Show();
        }

        private void HorarioTrabajo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string entrada = textBox1.Text;
            string salida = textBox2.Text;
            string horasextras = textBox3.Text;
            string idEmpleado = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO HorarioTrabajo (entrada, salida, horasextras, idEmpleado, estatus) values('" + entrada + "', '" + salida + "', '" + horasextras + "', '" + idEmpleado + "', '" +estatus+ "')";
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
            string entrada = textBox1.Text;
            string salida = textBox2.Text;
            string horasextras = textBox3.Text;
            string idEmpleado = textBox4.Text;
            string estatus = textBox5.Text;
            int idHorarioTrabajo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE HorarioTrabajo SET entrada = '" + entrada + "',salida = '" + salida + "',horasextras = '" + horasextras + "',idEmpleado = '" + idEmpleado + "', estatus = '" +estatus + "'' WHERE idHorarioTrabajo = " + idHorarioTrabajo.ToString();
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
            int idHorarioTrabajo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE HorarioTrabajo SET Estatus = 0 WHERE idHorarioTrabajo = " + idHorarioTrabajo.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
