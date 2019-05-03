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
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = " Incorrect Designation !";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Title !";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert Statement
                    string cmd = "INSERT INTO Project(Description, Title) Values(@Description, @Title)";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@Description", textBox1.Text);
                    command.Parameters.AddWithValue("@Title", textBox2.Text);
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
    }
}
