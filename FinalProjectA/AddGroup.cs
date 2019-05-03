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
    public partial class AddGroup : Form
    {
        public AddGroup()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Name! ";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dateTimePicker1.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert query
                    //string cmd = "ALTER TABLE [group] ADD  Name VARCHAR(20)";
                    string cmd = "INSERT INTO [group] (Name, Created_On) VALUES(@GroupName, @CreatedOn)";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@GroupName", textBox1.Text);
                    command.Parameters.AddWithValue("@CreatedOn", dateTimePicker1.Text);
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
    }
}
