using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Globalization;

namespace ProjectBD_RIOJAS
{
    public partial class CareerService : MaterialSkin.Controls.MaterialForm
    {
        public CareerService()
        {
            InitializeComponent();
        }

        private void CareerService_Load(object sender, EventArgs e)
        {
            //Diseño y color del formulario
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.BlueGrey900, Primary.BlueGrey900, Accent.Cyan700, TextShade.WHITE);

            //Crear conexion
            Conexion.Conectar();
            MessageBox.Show("conexion exitosa");

            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM CareerService";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["CareerID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["EmployeeID"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["ServiceDate"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["State"].Value.ToString();
        }

        private void MRBtnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO CareerService (CareerID,EmployeeID,ServiceDate,Description,State)VALUES(@CareerID,@EmployeeID,@ServiceDate,@Description,@State)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CareerID", textBox1.Text);
            cmd1.Parameters.AddWithValue("@EmployeeID", textBox2.Text);
            cmd1.Parameters.AddWithValue("@ServiceDate", textBox3.Text);
            cmd1.Parameters.AddWithValue("@Description", textBox4.Text);
            cmd1.Parameters.AddWithValue("@State", textBox5.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados con exito");

            dataGridView1.DataSource = llenar_grid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE CareerService SET " +
                                 "CareerID=@CareerID, " +
                                 "EmployeeID=@EmployeeID, " +
                                 "Description=@Description, " +
                                 "State=@State " +
                                 "WHERE CareerServiceID=@CareerServiceID"; // Corregí la condición WHERE

            using (SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar()))
            {
                int careerServiceID = ObtenerValorCareerServiceIDDesdeFuenteDeDatos();

                cmd2.Parameters.AddWithValue("@CareerServiceID", careerServiceID);
                cmd2.Parameters.AddWithValue("@CareerID", textBox1.Text);
                cmd2.Parameters.AddWithValue("@EmployeeID", textBox2.Text);
                cmd2.Parameters.AddWithValue("@Description", textBox4.Text);
                cmd2.Parameters.AddWithValue("@State", textBox5.Text);


                cmd2.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con éxito");

                dataGridView1.DataSource = llenar_grid();
            }
        }

        // Función para obtener el valor de EmployeeID desde el DataGridView o cualquier otra fuente
        private int ObtenerValorCareerServiceIDDesdeFuenteDeDatos()
        {
            // Puedes ajustar esto según tu lógica y la fuente de datos que estás utilizando
            if (dataGridView1.CurrentRow != null)
            {
                return Convert.ToInt32(dataGridView1.CurrentRow.Cells["CareerServiceID"].Value);
            }
            else
            {
                // Manejo de error o devolución de un valor predeterminado
                return -1;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM CareerService WHERE CareerServiceID = @CareerServiceID";

            using (SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar()))
            {
                // Obtener el valor de EmployeeID del DataGridView o cualquier otra fuente
                int careerServiceID = ObtenerValorCareerServiceIDDesdeFuenteDeDatos();

                cmd3.Parameters.AddWithValue("@CareerServiceID", careerServiceID);

                cmd3.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron eliminados con éxito");

                dataGridView1.DataSource = llenar_grid();
            }
        }
    }
}
