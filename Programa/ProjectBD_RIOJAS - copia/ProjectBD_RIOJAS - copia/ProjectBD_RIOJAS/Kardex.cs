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
    public partial class Kardex : MaterialSkin.Controls.MaterialForm
    {
        public Kardex()
        {
            InitializeComponent();
        }

        private void Kardex_Load(object sender, EventArgs e)
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
            string consulta = "SELECT * FROM Kardex";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void MRBtnMenú_Click(object sender, EventArgs e)
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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["ClassID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["OpportunityID"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["StudentID"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Grade"].Value.ToString();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO Kardex (ClassID,OpportunityID,StudentID,Grade)VALUES(@ClassID,@OpportunityID,@StudentID,@Grade)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@ClassID", textBox1.Text);
            cmd1.Parameters.AddWithValue("@OpportunityID", textBox2.Text);
            cmd1.Parameters.AddWithValue("@StudentID", textBox3.Text);
            cmd1.Parameters.AddWithValue("@Grade", textBox4.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados con exito");

            dataGridView1.DataSource = llenar_grid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE Kardex SET " +
                                 "ClassID=@ClassID, " +
                                 "OpportunityID=@OpportunityID, " +
                                 "StudentID=@StudentID, " +
                                 "Grade=@Grade " +
                                 "WHERE KardexID=@KardexID"; // Corregí la condición WHERE

            using (SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar()))
            {
                int kardexID = ObtenerValorKardexIDDesdeFuenteDeDatos();

                cmd2.Parameters.AddWithValue("@KardexID", kardexID);
                cmd2.Parameters.AddWithValue("@ClassID", textBox1.Text);
                cmd2.Parameters.AddWithValue("@OpportunityID", textBox2.Text);
                cmd2.Parameters.AddWithValue("@StudentID", textBox3.Text);
                cmd2.Parameters.AddWithValue("@Grade", textBox4.Text);


                cmd2.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con éxito");

                dataGridView1.DataSource = llenar_grid();
            }
        }

        // Función para obtener el valor de EmployeeID desde el DataGridView o cualquier otra fuente
        private int ObtenerValorKardexIDDesdeFuenteDeDatos()
        {
            // Puedes ajustar esto según tu lógica y la fuente de datos que estás utilizando
            if (dataGridView1.CurrentRow != null)
            {
                return Convert.ToInt32(dataGridView1.CurrentRow.Cells["KardexID"].Value);
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
            string eliminar = "DELETE FROM Kardex WHERE KardexID = @KardexID";

            using (SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar()))
            {
                // Obtener el valor de EmployeeID del DataGridView o cualquier otra fuente
                int kardexID = ObtenerValorKardexIDDesdeFuenteDeDatos();

                cmd3.Parameters.AddWithValue("@KardexID", kardexID);

                cmd3.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron eliminados con éxito");

                dataGridView1.DataSource = llenar_grid();
            }
        }

        
    }
}
