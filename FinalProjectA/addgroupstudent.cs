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
using System.Text.RegularExpressions;

namespace FinalProjectA
{
    public partial class addgroupstudent : Form
    {
        public addgroupstudent()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox4.Text) && !Regex.IsMatch(textBox4.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect GroupName !";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$"))
            {
                Error = "Incorrect registration number!";
                return false;
            }
           
            else
            {
                return true;
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != "" && textBox4.Text != "" && textBox1.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert query
                    string cmd = "INSERT INTO GroupStudent(GroupId, StudentId, Status, AssignmentDate)" +
                                 "VALUES((SELECT Id FROM [group] WHERE Name = @GroupName), (SELECT Id FROM Student WHERE RegistrationNo = @RegistrationNo)," +
                                 "(SELECT Id FROM Lookup WHERE Category = 'STATUS' AND Value = 'Active'), @AssignmentDate)";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Text);
                    command.Parameters.AddWithValue("@GroupName", textBox4.Text);
                    command.Parameters.AddWithValue("@RegistrationNo", textBox1.Text);
                    //open connection
                    conn.Open();
                    command.ExecuteNonQuery();
                    //close connection
                    conn.Close();
                    //Display message
                    MessageBox.Show("Hurrah!Record inserted");
                }
                else
                {
                    MessageBox.Show(Error);
                }  
            }
            else
            {
                //display message
                MessageBox.Show("Please enter the data first");
            }
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
