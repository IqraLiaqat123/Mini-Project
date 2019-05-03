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
    public partial class AddEvaluation : Form
    {
        public AddEvaluation()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Name! ";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, @"^[0-9]{2}$"))
            {
                Error = "Incorrect TotalMarks!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, @"^[0-9]{2}$"))
            {
                Error = "Incorrect TotalWeightage!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert Statement
                    string cmd = "INSERT INTO Evaluation(Name, TotalMarks, TotalWeightage) Values(@Name, @TotalMarks, @TotalWeightage)";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@Name", textBox1.Text);
                    command.Parameters.AddWithValue("@TotalMarks", textBox2.Text);
                    command.Parameters.AddWithValue("@TotalWeightage", textBox2.Text);
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
                MessageBox.Show("Please Enter data first");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddEvaluation_Load(object sender, EventArgs e)
        {

        }
    }
}
