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

namespace ProjectBD_RIOJAS
{
    public partial class Menu : MaterialSkin.Controls.MaterialForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.BlueGrey900, Primary.BlueGrey900, Accent.Cyan700, TextShade.WHITE);

        }

        private void MRBtnInicio_Click(object sender, EventArgs e)
        {
            Inicio op = new Inicio();
            op.Show();
            Hide();
        }

        private void MRBtnCareer_Click(object sender, EventArgs e)
        {
            Career career = new Career();
            career.Show();
            Hide();
        }

        private void MRBtnCareerService_Click(object sender, EventArgs e)
        {
            CareerService careerService = new CareerService();
            careerService.Show();
            Hide();
        }

        private void MRBtnClass_Click(object sender, EventArgs e)
        {
            Class cl = new Class();
            cl.Show();
            Hide();
        }

        private void MRBtnDocumentRequest_Click(object sender, EventArgs e)
        {
            DocumentRequest dr = new DocumentRequest();
            dr.Show();
            Hide();
        }

        private void MRBtnDocumentType_Click(object sender, EventArgs e)
        {
            DocumentType documentType = new DocumentType();
            documentType.Show();
            Hide();
        }

        private void MRBtnEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            Hide();
        }

        private void MRBtnEmployeeType_Click(object sender, EventArgs e)
        {
            EmployeeType et = new EmployeeType();
            et.Show();
            Hide();
        }

        private void MRBtnCourse_Click(object sender, EventArgs e)
        {
            Course co = new Course();
            co.Show();
            Hide();
        }

        private void MRBtnKardex_Click(object sender, EventArgs e)
        {
            Kardex ka = new Kardex();
            ka.Show();
            Hide();
        }

        private void MRBtnOpportunity_Click(object sender, EventArgs e)
        {
            Opportunity op = new Opportunity();
            op.Show();
            Hide();
        }

        private void MRBtnUsuario_Click(object sender, EventArgs e)
        {
            Usuario op = new Usuario();
            op.Show();
            Hide();
        }
    }
}
