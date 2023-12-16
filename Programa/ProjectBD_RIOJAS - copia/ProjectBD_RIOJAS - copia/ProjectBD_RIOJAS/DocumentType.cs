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
    public partial class DocumentType : MaterialSkin.Controls.MaterialForm
    {
        public DocumentType()
        {
            InitializeComponent();
        }

        private void DocumentType_Load(object sender, EventArgs e)
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
            string consulta = "SELECT * FROM [10.235.242.168].SchoolServices.dbo.DocumentType";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        
        }

        private void MRBtnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO [10.235.242.168].SchoolServices.dbo.DocumentType (Name, Description) VALUES(@Name,@Description)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd1.Parameters.AddWithValue("@Description", textBox3.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados con exito");

            dataGridView1.DataSource = llenar_grid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
            textBox2.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE [10.235.242.168].SchoolServices.dbo.DocumentType SET " +
                                 "Name=@Name, " +
                                 "Description=@Description " +
                                 "WHERE DocumentTypeID=@DocumentTypeID"; // Corregí la condición WHERE

            using (SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar()))
            {
                int documentTypetid = ObtenerValorDocumentTypeIDDesdeFuenteDeDatos();

                cmd2.Parameters.AddWithValue("@DocumentTypeID", documentTypetid);
                cmd2.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd2.Parameters.AddWithValue("@Description", textBox3.Text);

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con éxito");

                dataGridView1.DataSource = llenar_grid();
            }
        }

        // Función para obtener el valor de EmployeeID desde el DataGridView o cualquier otra fuente
        private int ObtenerValorDocumentTypeIDDesdeFuenteDeDatos()
        {
            // Puedes ajustar esto según tu lógica y la fuente de datos que estás utilizando
            if (dataGridView1.CurrentRow != null)
            {
                return Convert.ToInt32(dataGridView1.CurrentRow.Cells["DocumentTypeID"].Value);
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
            string eliminar = "DELETE FROM [10.235.242.168].SchoolServices.dbo.DocumentType WHERE DocumentTypeID = @DocumentTypeID";

            using (SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar()))
            {
                // Obtener el valor de EmployeeID del DataGridView o cualquier otra fuente
                int documentTypetid = ObtenerValorDocumentTypeIDDesdeFuenteDeDatos();

                cmd3.Parameters.AddWithValue("@DocumentTypeID", documentTypetid);

                cmd3.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron eliminados con éxito");

                dataGridView1.DataSource = llenar_grid();
            }
        }
    }
}
