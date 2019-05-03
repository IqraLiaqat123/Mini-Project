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
    public partial class addprojectadvisor : Form
    {
        public addprojectadvisor()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect FirstName !";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect LastName! ";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect ProjectName! ";
                return false;
            }
            else if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                Error = "Please Checkout one radio button";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new index();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != "" && textBox2.Text != "" && textBox1.Text != "" && textBox3.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert query
                    string cmd = "INSERT INTO ProjectAdvisor(AdvisorId, ProjectId, AdvisorRole, AssignmentDate)" +
                                 "VALUES((SELECT Id FROM Person WHERE FirstName  = @FirstName AND LastName = @LastName),(SELECT Id FROM Project WHERE Title = @ProjectName), " +
                                 "(SELECT Id FROM Lookup WHERE Category = 'ADVISOR_ROLE' AND Value =@AdvisorRole), @AssignmentDate)";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@FirstName", textBox1.Text);
                    command.Parameters.AddWithValue("@LastName", textBox2.Text);
                    command.Parameters.AddWithValue("@ProjectName", textBox3.Text);
                    command.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Text);
                    if (radioButton1.Checked)
                    {
                        command.Parameters.AddWithValue("@AdvisorRole", "Main Advisor");
                    }
                    else if (radioButton2.Checked)
                    {
                        command.Parameters.AddWithValue("@AdvisorRole", "Co-Advisror");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@AdvisorRole", "Industry Advisor");
                    }

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
