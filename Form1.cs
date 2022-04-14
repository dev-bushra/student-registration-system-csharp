using SLRDbConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationSystem
{
    public partial class Form1 : Form
    {
        DbConnector db;
        public Form1()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.FillCombobox("select name from tblClasses", cmbClass);
            db.fillDataGridView("select * from tblStudents", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string class_id;

            if (isFormValid())
            {
                db.getSingleValue("select id from tblClasses where name = '" + cmbClass.Text.ToString() + "'", out class_id, 0);
               string abc = db.performCRUD("insert into tblStudents(name,father_name,address,date_of_birth,class_id) values('" + txtName.Text+ "','" + txtFatherName.Text + "','" + txtAddress.Text + "','" + dtdob.Text + "','" + class_id + "')");
                this.OnLoad(e);
            }
            else
            {
                MessageBox.Show("Please Fill All Required Fields","Required Fields are Empty",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private bool isFormValid()
        {
            if (txtName.Text.ToString().Trim() == string.Empty 
                || txtFatherName.Text.ToString().Trim() == string.Empty 
                || txtAddress.Text.ToString().Trim() == string.Empty)
            {
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
