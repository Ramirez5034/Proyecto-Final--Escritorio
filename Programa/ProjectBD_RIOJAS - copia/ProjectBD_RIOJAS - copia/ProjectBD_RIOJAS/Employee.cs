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
    public partial class Employee : MaterialSkin.Controls.MaterialForm
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            //Diseño del formulario y color
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
            string consulta = "SELECT * FROM Employee";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
       

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO Employee (FirstName,LastName,MiddleName,PhoneNumber,Email,Gender,Position,Salary,DateOfBirth,Address,ZipCode,RFC,SocialSecurity,EmployeeTypeID)VALUES(@FirstName,@LastName,@MiddleName,@PhoneNumber,@Email,@Gender,@Position,@Salary,@DateOfBirth,@Address,@ZipCode,@RFC,@SocialSecurity,@EmployeeTypeID)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            
            cmd1.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd1.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd1.Parameters.AddWithValue("@MiddleName", textBox4.Text);
            cmd1.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
            cmd1.Parameters.AddWithValue("@Email", textBox6.Text);
            cmd1.Parameters.AddWithValue("@Gender", textBox7.Text);
            cmd1.Parameters.AddWithValue("@Position", textBox8.Text);
            cmd1.Parameters.AddWithValue("@Salary", textBox9.Text);
            cmd1.Parameters.AddWithValue("@DateOfBirth", textBox10.Text);
            cmd1.Parameters.AddWithValue("@Address", textBox11.Text);
            cmd1.Parameters.AddWithValue("@ZipCode", textBox12.Text);
            cmd1.Parameters.AddWithValue("@RFC", textBox13.Text);
            cmd1.Parameters.AddWithValue("@SocialSecurity", textBox14.Text);
            cmd1.Parameters.AddWithValue("@EmployeeTypeID", textBox15.Text);


            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados con exito");

            dataGridView1.DataSource=llenar_grid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["MiddleName"].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells["PhoneNumber"].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells["Gender"].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells["Position"].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells["Salary"].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells["DateOfBirth"].Value.ToString();
                textBox11.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                textBox12.Text = dataGridView1.CurrentRow.Cells["ZipCode"].Value.ToString();
                textBox13.Text = dataGridView1.CurrentRow.Cells["RFC"].Value.ToString();
                textBox14.Text = dataGridView1.CurrentRow.Cells["SocialSecurity"].Value.ToString();
                textBox15.Text = dataGridView1.CurrentRow.Cells["EmployeeTypeID"].Value.ToString();

            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           Conexion.Conectar();
           string actualizar = "UPDATE Employee SET " +
                        "FirstName=@FirstName, " +
                        "LastName=@LastName, " +
                        "MiddleName=@MiddleName, " +
                        "PhoneNumber=@PhoneNumber, " +
                        "Email=@Email, " +
                        "Gender=@Gender, " +
                        "Position=@Position, " +
                        "Salary=@Salary, " +
                        "Address=@Address, " +
                        "ZipCode=@ZipCode, " +
                        "RFC=@RFC, " +
                        "SocialSecurity=@SocialSecurity, " +
                        "EmployeeTypeID=@EmployeeTypeID " +
                        "WHERE EmployeeID=@EmployeeID";

            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            int employeeID = ObtenerValorEmployeeIDDesdeFuenteDeDatos();

            cmd2.Parameters.AddWithValue("@EmployeeID", employeeID);
            cmd2.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd2.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd2.Parameters.AddWithValue("@MiddleName", textBox4.Text);
            cmd2.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
            cmd2.Parameters.AddWithValue("@Email", textBox6.Text);
            cmd2.Parameters.AddWithValue("@Gender", textBox7.Text);
            cmd2.Parameters.AddWithValue("@Position", textBox8.Text);
            cmd2.Parameters.AddWithValue("@Salary", textBox9.Text);
            cmd2.Parameters.AddWithValue("@DateOfBirth", textBox10.Text);
            cmd2.Parameters.AddWithValue("@Address", textBox11.Text);
            cmd2.Parameters.AddWithValue("@ZipCode", textBox12.Text);
            cmd2.Parameters.AddWithValue("@RFC", textBox13.Text);
            cmd2.Parameters.AddWithValue("@SocialSecurity", textBox14.Text);
            cmd2.Parameters.AddWithValue("@EmployeeTypeID", textBox15.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados con exito");

            dataGridView1.DataSource = llenar_grid();
        }

        // Función para obtener el valor de EmployeeID desde el DataGridView o cualquier otra fuente
        private int ObtenerValorEmployeeIDDesdeFuenteDeDatos()
        {
            // Puedes ajustar esto según tu lógica y la fuente de datos que estás utilizando
            if (dataGridView1.CurrentRow != null)
            {
                return Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmployeeID"].Value);
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
            string eliminar = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

            using (SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar()))
            {
                // Obtener el valor de EmployeeID del DataGridView o cualquier otra fuente
                int employeeID = ObtenerValorEmployeeIDDesdeFuenteDeDatos();

                cmd3.Parameters.AddWithValue("@EmployeeID", employeeID);

                cmd3.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron eliminados con éxito");

                dataGridView1.DataSource = llenar_grid();
            }
        }

        private void MRBtnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }
    }
}
