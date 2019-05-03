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
    public partial class displayprojectadvisor : Form
    {
        public displayprojectadvisor()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter sdq;
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new index();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connection URL
            string conURL = "Data source=ProjectA.sqlite";
            //Connection with DB
            SQLiteConnection conn = new SQLiteConnection(conURL);
            //Insert Statement
            string cmd = "SELECT [FirstName]||[LastName] AS [Advisor],[Title],[AdvisorRole],[AssignmentDate] FROM Person JOIN ProjectAdvisor ON Person.Id = ProjectAdvisor.AdvisorId JOIN Project ON ProjectAdvisor.ProjectId = Project.Id";
                /*ProjectAdvisor JOIN Advisor  ON Advisor.Id = ProjectAdvisor.AdvisorId JOIN [Project] "+
                 "ON  Project.Id =Advisor.Id JOIN Person ON Person.Id = Advisor.Id";*/
            //preparing statement
            SQLiteCommand command = new SQLiteCommand(cmd, conn);
            //open connection
            conn.Open();
            command.Connection = conn;
            DataTable dt1 = new DataTable();
            sdq = new SQLiteDataAdapter("SELECT [FirstName]|| [LastName] AS [Advisor],[Title],[AdvisorRole],[AssignmentDate] FROM Person JOIN ProjectAdvisor ON Person.Id = ProjectAdvisor.AdvisorId JOIN Project ON ProjectAdvisor.ProjectId = Project.Id", conn);
            sdq.Fill(dt1);
            dataGridView1.DataSource = dt1;
            MessageBox.Show("Hurrah!Its work");
        }
    }
}
