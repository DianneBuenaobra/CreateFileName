using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateFileName
{
    public partial class FrmRegistration : Form
    {
        string studNo, name, program, gender, age, birthday, contactNo;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmFileName frm = new FrmFileName();
            frm.ShowDialog();

            studNo = txtStudentNo.Text;name = txtLastName.Text + ", " + txtFirstName.Text + " " + txtMI.Text + ".";
            program = CBProgram.SelectedItem.ToString();gender = CBGender.SelectedItem.ToString();age = txtAge.Text;
            birthday = DateTimeBday.Text; contactNo = txtContacTNo.Text;

            string[] display = {"Student No.: "+ studNo,"Full Name: " + name,"Program: " + program,"Gender: "+gender,"Age: "+ age,"Birthday: "
            + birthday,"Contact No.: "+ contactNo};

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, frm.SetFileName)))
            {
                foreach(string d in display)
                {
                    outputFile.WriteLine(d);
                }
                MessageBox.Show("Successfully saved!","Notification",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Clear();txtContacTNo.Clear();txtFirstName.Clear();txtLastName.Clear();txtMI.Clear();txtStudentNo.Clear();CBGender.Items.Clear();
                CBGender.Items.Clear();
                
            }

        }
        public FrmRegistration()
        {
            InitializeComponent();

            string []programs = {"Bachelor of Science in Accountancy","Bachelor of Science in Business Administration", "Bachelor of Science in Computer Science",
            "Bachelor of Science in Information Systems","Bachelor of Science in Information Technology"};

            string[] gender = {"Male","Female" };

            foreach (string program in programs)
            {
                CBProgram.Items.Add(program);
            }
            foreach (string genderss in gender)
            {
                CBGender.Items.Add(genderss);
            }  
        }
    }
}
