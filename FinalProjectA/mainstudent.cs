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
    public partial class mainstudent : Form
    {
        public mainstudent()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox7.Text) && !Regex.IsMatch(textBox7.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect FirstName !";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox6.Text) && !Regex.IsMatch(textBox6.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect LastName!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox5.Text) && !Regex.IsMatch(textBox5.Text, @"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$"))
            {
                Error = "Incorrect registration number!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, @"^[0-9]{4}-[0-9]{7}$"))
            {
                Error = "Incorrect contact!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox4.Text) && !Regex.IsMatch(textBox4.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                Error = "Incorrect email!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[0-9]"))
            {
                Error = "Incorrect Salary! ";
                return false;
            }
            /*else if (!radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                Error = "Please Checkout one radio button";
                return false;
            }*/
            else if (!checkBox1.Checked && !checkBox2.Checked)
            {
                Error = "Please Checkout one checkBox";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (main == "Student")
            {
                label3.Hide();
                label2.Hide();
                textBox1.Hide();
                radioButton2.Hide();
                radioButton3.Hide();
                radioButton4.Hide();
                radioButton5.Hide();
                radioButton6.Hide();
                label11.Show();
                textBox5.Show();
            }
            else
            {
                label3.Show();
                label2.Show();
                radioButton2.Show();
                radioButton3.Show();
                radioButton4.Show();
                radioButton5.Show();
                radioButton6.Show();
                label11.Hide();
                textBox5.Hide();
                textBox1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (main == "Student")
            {
                if (textBox7.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && dateTimePicker1.Text != "")
                {
                    if (Validations())
                    {
                        //connection URL
                        string conURL = "Data source=ProjectA.sqlite";
                        //Connection with DB
                        SQLiteConnection conn = new SQLiteConnection(conURL);
                        //Insert Statement
                        string cmd = "INSERT INTO Person(FirstName, LastName, Contact, Email, DateOfBirth, Gender) Values(@FirstName, @LastName, @Contact, @Email, @DateOfBirth, (SELECT Id FROM Lookup WHERE Category = 'GENDER' AND Value = @Gender));" +
                            "INSERT INTO Student(Id, RegistrationNo) Values((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName = @LastName AND Contact = @Contact AND Email = @Email  AND DateOfBirth = @DateOfBirth), @RegistrationNo)";
                        //preparing statement
                        SQLiteCommand command = new SQLiteCommand(cmd, conn);
                        command.Parameters.AddWithValue("@RegistrationNo", textBox5.Text);
                        command.Parameters.AddWithValue("@FirstName", textBox1.Text);
                        command.Parameters.AddWithValue("@LastName", textBox6.Text);
                        command.Parameters.AddWithValue("@Contact", textBox2.Text);
                        command.Parameters.AddWithValue("@Email", textBox4.Text);
                        command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Text);
                        if (checkBox1.Checked)
                        {
                            command.Parameters.AddWithValue("@Gender", "Male");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Gender", "Female");
                        }
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
                    MessageBox.Show("Enter the required data first");

                }

            }
            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox6.Text != "" && dateTimePicker1.Text != "")
                {
                    if (Validations())
                    {
                        //connection URL
                        string conURL = "Data source=ProjectA.sqlite";
                        //Connection with DB
                        SQLiteConnection conn = new SQLiteConnection(conURL);
                        //Insert Statement
                        string cmd = "INSERT INTO Person(FirstName, LastName, Contact, Email, DateOfBirth, Gender) Values(@FirstName, @LastName, @Contact, @Email, @DateOfBirth, (SELECT Id FROM Lookup WHERE Category = 'GENDER' AND Value = @Gender));" +
                        "INSERT INTO Advisor(Id, Designation, Salary) Values((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName = @LastName AND Contact = @Contact AND Email = @Email  AND DateOfBirth = @DateOfBirth), (SELECT Id FROM Lookup WHERE Category = 'DESIGNATION' AND Value = @Designation),  @Salary)";
                        //preparing statement
                        SQLiteCommand command = new SQLiteCommand(cmd, conn);
                        // command.Parameters.AddWithValue("@RegistrationNo", textBox5.Text);
                        command.Parameters.AddWithValue("@FirstName", textBox7.Text);
                        command.Parameters.AddWithValue("@LastName", textBox6.Text);
                        command.Parameters.AddWithValue("@Contact", textBox2.Text);
                        command.Parameters.AddWithValue("@Email", textBox4.Text);
                        command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Text);
                        command.Parameters.AddWithValue("@Salary", textBox1.Text);
                        if (checkBox1.Checked)
                        {
                            command.Parameters.AddWithValue("@Gender", "Male");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Gender", "Female");
                        }
                        if (radioButton2.Checked)
                        {
                            command.Parameters.AddWithValue("@Designation", "Lecturer");
                        }
                        else if (radioButton3.Checked)
                        {
                            command.Parameters.AddWithValue("@Designation", "Professor");
                        }
                        else if (radioButton4.Checked)
                        {
                            command.Parameters.AddWithValue("@Designation", "Industry Professional");
                        }
                        else if (radioButton5.Checked)
                        {
                            command.Parameters.AddWithValue("@Designation", "Assisstant Professor");
                        }
                        else if (radioButton6.Checked)
                        {
                            command.Parameters.AddWithValue("@Designation", "Associate Professor");
                        }
                        //open connection
                        conn.Open();
                        command.ExecuteNonQuery();
                        //close connection
                        conn.Close();
                        //Display message
                        MessageBox.Show("Hurrah!record inserted");
                        //SQLiteDataReader reader = command.ExecuteReader();
                    }
                    else
                    {
                        MessageBox.Show(Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the rqeuired data");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

