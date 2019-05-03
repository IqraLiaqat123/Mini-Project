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
    public partial class deletegroupstudent : Form
    {
        public deletegroupstudent()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect GroupName !";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    string cmdd;
                    //DELETE  Statement
                    if (main == "RegistrationNo")
                    {
                        cmdd = "UPDATE GroupStudent SET Status = (SELECT Id FROM Lookup WHERE Category = 'STATUS' AND Value = 'InActive') " +
                               "WHERE StudentId = (SELECT Id FROM Student wHERE RegistrationNo = @Value)";
                    }
                    else
                    {
                        cmdd = "UPDATE GroupStudent SET Status = (SELECT Id FROM Lookup WHERE Category = 'STATUS' AND Value = 'InActive') " +
                               "WHERE StudentId = (SELECT Id FROM Person wHERE Contact = @Value)";
                    }

                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmdd, conn);
                    command.Parameters.AddWithValue("@Value", textBox1.Text);
                    command.Parameters.AddWithValue("@GroupName", textBox2.Text);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hurrah! Record Deleted");
                    //close connection
                }
                else
                {
                    MessageBox.Show(Error);
                }
            }
            else
            {
                MessageBox.Show("Please insert data first");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
