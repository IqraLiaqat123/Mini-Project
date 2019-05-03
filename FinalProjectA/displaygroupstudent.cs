using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FinalProjectA
{
    public partial class displaygroupstudent : Form
    {
        public displaygroupstudent()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter sdq;
        private void button2_Click(object sender, EventArgs e)
        {
            //connection URL
            string conURL = "Data source=ProjectA.sqlite";
            //Connection with DB
            SQLiteConnection conn = new SQLiteConnection(conURL);
            //Insert Statement
            string cmd = "SELECT [RegistrationNo],[Status],[AssignmentDate],[Name] FROM Student JOIN  GroupStudent ON GroupStudent.StudentId = Student.Id JOIN [group] ON [group].Id = GroupStudent.GroupId ";
            //preparing statement
            SQLiteCommand command = new SQLiteCommand(cmd, conn);
            //open connection
            conn.Open();
            command.Connection = conn;
            DataTable dt1 = new DataTable();
            sdq = new SQLiteDataAdapter("SELECT [RegistrationNo],[Status],[AssignmentDate],[Name] FROM Student JOIN  GroupStudent ON GroupStudent.StudentId = Student.Id JOIN [group] ON [group].Id = GroupStudent.GroupId", conn);
            sdq.Fill(dt1);
            dataGridView1.DataSource = dt1;
            MessageBox.Show("Hurrah!Its work");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new index();
            index.Closed += (s, args) => this.Close();
            index.Show();

        }
    }
}
