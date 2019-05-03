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
    public partial class addgroupProject : Form
    {
        public addgroupProject()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //inserting record in group project
        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text !="")
            {
                //connection URL
                string conURL = "Data source=ProjectA.sqlite";
                //Connection with DB
                SQLiteConnection conn = new SQLiteConnection(conURL);
                //Insert query
                // string cmd = "ALTER TABLE [group] ADD  Name VARCHAR(20)";
                string cmd = "INSERT INTO GroupProject (ProjectId, GroupId, AssignmentDate) "+
                             "VALUES((SELECT Id FROM Project WHERE Title = @ProjectName), (SELECT Id FROM [group] WHERE Name = @GroupName), @AssignmentDate)";
                //preparing statement
                SQLiteCommand command = new SQLiteCommand(cmd, conn);
                command.Parameters.AddWithValue("@GroupName", textBox1.Text);
                command.Parameters.AddWithValue("@ProjectName", textBox2.Text);
                command.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Text);
                //open connection
                conn.Open();
                command.ExecuteNonQuery();
                //close connection
                conn.Close();
                //Display message
                MessageBox.Show("Hurrah!Its work");
            }
            else
            {
                MessageBox.Show("Please enter the data first");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

