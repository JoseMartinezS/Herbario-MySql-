//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Transporte : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Transporte()
        {
            InitializeComponent();
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Transporte ORDER BY idTransporte");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Representante repre = new Representante();
            repre.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sucursal sucu = new Sucursal();
            sucu.Show();
        }

        private void Transporte_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string marca = textBox1.Text;
            string matricula = textBox2.Text;
            string cilindros = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Agenda (marca, matricula, cilindros, estatus) values('" + marca + "', '" + matricula + "', '" + cilindros + "', '" + estatus + "')";
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
            string marca = textBox1.Text;
            string matricula = textBox2.Text;
            string cilindros = textBox3.Text;
            string estatus = textBox4.Text;
            int idAgenda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Agenda SET marca = '" + marca + "',matricula = '" + matricula + "',cilindros = '" + cilindros + "',estatus = '" + estatus + "' WHERE idAgenda = " + idAgenda.ToString();
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
            int idAgenda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Agenda SET Estatus = 0 WHERE idAgenda = " + idAgenda.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
