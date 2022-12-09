//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Puesto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Puesto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Puesto ORDER BY idPuesto");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Proveedor provee = new Proveedor();
            provee.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receta rece = new Receta();
            rece.Show();
        }

        private void Puesto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string puesto = textBox1.Text;
            string numero = textBox2.Text;
            string idEmpleado = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Puesto (puesto, numero, idEmpleado, estatus) values('" + puesto + "', '" + numero + "', '" + idEmpleado + "', '" + estatus + "')";
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
            string puesto = textBox1.Text;
            string numero = textBox2.Text;
            string idEmpleado = textBox3.Text;
            string estatus = textBox4.Text;
            int idPuesto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Puesto SET puesto = '" + puesto + "',numero = '" + numero + "',idEmpleado = '" + idEmpleado + "',estatus = '" + estatus + "' WHERE idPuesto = " + idPuesto.ToString();
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
            int idPuesto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Puesto SET Estatus = 0 WHERE idPuesto = " + idPuesto.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
