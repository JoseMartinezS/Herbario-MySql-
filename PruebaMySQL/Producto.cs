//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{

    public partial class Producto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Producto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM Producto ORDER BY idProducto");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Produccion produ = new Produccion();
            produ.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Proveedor provee = new Proveedor();
            provee.Show();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string precio = textBox2.Text;
            string cantidad = textBox3.Text;
            string idPedido = textBox4.Text;
            string idMateriaPrima = textBox5.Text;
            string idApartado = textBox6.Text;
            string idEnvio = textBox7.Text;
            string idDevolucion = textBox8.Text;
            string idCompra = textBox9.Text;
            string estatus = textBox10.Text;
            consulta = "INSERT INTO Producto (nombre, precio, cantidad, idPedido, idMateriaPrima, idApartado, idEnvio, idDevolucion, idCompra, estatus) values('" + nombre + "', '" + precio + "', '" + cantidad + "', '" + idPedido + "', '" + idEnvio + "', '" + idMateriaPrima + "', '" + idApartado + "', '" + idEnvio + "', '" + idDevolucion+ "', '" + idCompra+ "', '" + estatus+ "')";
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
            string precio = textBox2.Text;
            string cantidad = textBox3.Text;
            string idPedido = textBox4.Text;
            string idMateriaPrima = textBox5.Text;
            string idApartado = textBox6.Text;
            string idEnvio = textBox7.Text;
            string idDevolucion = textBox8.Text;
            string idCompra = textBox9.Text;
            string estatus = textBox10.Text;
            int idProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Producto SET nombre = '" + nombre + "',precio = '" + precio + "',cantidad = '" + cantidad + "',idPedido = '" + idPedido + "', idMateriaPrima = '" + idMateriaPrima + "', idApartado = '" + idApartado + "', idEnvio = '" + idEnvio + "', idDevolucion = '" + idDevolucion + "', idCompra = '" + idCompra + "', estatus = '" + estatus +"' WHERE idProducto = " + idProducto.ToString();
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
            int idProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Producto SET Estatus = 0 WHERE idProducto = " + idProducto.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
