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
    public partial class maindeletestudent : Form
    {
        public maindeletestudent()
        {
            InitializeComponent();
        }

        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$"))
            {
                Error = "Incorrect registration number!";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (main == "Student")
            {
                textBox1.Show();    /// reg textbox
                label3.Show();     //registration label
                label4.Hide();
                label5.Hide();
                comboBox2.Hide();
                textBox2.Show();
            }
            else
            {
                textBox1.Hide();    /// reg textbox
                label3.Hide();     //registration label
                label4.Show();
                label5.Show();
                comboBox2.Show();
                textBox2.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (main == "Student")
            {
                if (textBox1.Text != "")
                {
                    if (Validations())
                    {

                        //connection URL
                        string conURL = "Data source=ProjectA.sqlite";
                        //Connection with DB
                        SQLiteConnection conn = new SQLiteConnection(conURL);
                        //delete Statement
                        /*string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                        string cmdd;
                        if (main == "RegistrationNo")
                        {
                            cmdd = "DELETE FROM Student  WHERE RegistrationNo =  @Value";
                        }
                        else
                        {
                            cmdd = "DELETE FROM Student  WHERE (SELECT Id from Person WHERE FirstName =  @Value)";
                        }*/
                        //preparing statement
                        string cmd = "DELETE FROM Student  WHERE RegistrationNo =  @RegistrationNo";
                        SQLiteCommand command = new SQLiteCommand(cmd, conn);
                        command.Parameters.AddWithValue("@RegistrationNo", textBox1.Text);
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Hurrah! Record Deleted");
                        conn.Close();
                        //close connection
                    }
                    else
                    {
                        MessageBox.Show(Error);
                    }
                }
                else
                {
                    MessageBox.Show("First Insert the data");
                }

            }
            else
            {
                if (textBox2.Text != "" && comboBox2.Text != "")
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert Statement
                    string mainn = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                    //string cmdd= "DELETE FROM Advisor  WHERE (SELECT Id FROM Person WHERE FirstName =  @Value)";
                    string cmdd;
                    if (mainn == "Contact")
                    {
                        cmdd = "DELETE FROM Person WHERE Contact = @Value ;" +
                            "DELETE FROM Advisor WHERE Id = (SELECT Id FROM Person WHERE  [Contact] =  @Value)";
                    }
                    else
                    {
                        cmdd = "DELETE FROM Person WHERE FirstName = @Value ;" +
                            "DELETE FROM Advisor WHERE Id = (SELECT Id FROM Person WHERE  [FirstName] =  @Value)";
                    }
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmdd, conn);
                    command.Parameters.AddWithValue("@Value", textBox2.Text);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hurrah! Record Deleted");
                    conn.Close();
                    //close connection
                }
                else
                {
                    MessageBox.Show("First Insert data");
                }
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
