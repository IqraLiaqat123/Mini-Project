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
    public partial class addgroupevaluation : Form
    {
        public addgroupevaluation()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox4.Text) && !Regex.IsMatch(textBox4.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect GroupName! ";
                return false;
            }
            if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect EvaluationName! ";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{2}$"))
            {
                Error = "Incorrect ObtaiinedMarks!";
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
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox4.Text != "" && dateTimePicker1.Text != "" && textBox2.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert query
                    // string cmd = "ALTER TABLE [group] ADD  Name VARCHAR(20)";
                    string cmd = "INSERT INTO GroupEvaluation (GroupId, EvaluationId, ObtainedMarks, EvaluationDate) " +
                                 "VALUES((SELECT Id FROM [group] WHERE Name = @GroupName),(SELECT Id FROM [Evaluation] WHERE Name = @EvaluationName ), @ObtainedMarks, @EvaluationDate)";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@GroupName", textBox4.Text);
                    command.Parameters.AddWithValue("@ObtainedMarks", textBox1.Text);
                    command.Parameters.AddWithValue("@EvaluationName", textBox2.Text);
                    command.Parameters.AddWithValue("@EvaluationDate", dateTimePicker1.Text);
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
                    MessageBox.Show(Error);
                }
               
            }
            else
            {
                MessageBox.Show("Please enter the data first");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
