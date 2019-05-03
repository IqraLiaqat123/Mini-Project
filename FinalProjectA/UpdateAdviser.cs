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
    public partial class UpdateAdviser : Form
    {
        public UpdateAdviser()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

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
                Error = "Incorrect LastName! ";
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
            else if (!String.IsNullOrEmpty(textBox5.Text) && !Regex.IsMatch(textBox5.Text, "^[0-9]"))
            {
                Error = "Incorrect Salary! ";
                return false;
            }
            else if (!checkBox1.Checked && !checkBox2.Checked)
            {
                Error = "Please Checkout one checkBox";
                return false;
            }
            else if (!radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                Error = "Please Checkout one radio button";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox6.Text !="" && textBox5.Text != "" && textBox2.Text !="" && dateTimePicker1.Text !="" && textBox1.Text !="" && textBox4.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert Statement
                    //string cmd = "UPDATE Evaluation SET Name = @Name, TotalMarks = @TotalMarks, TotalWeightage = @TotalWeightage WHERE Name = @Value ";
                    string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    string cmdd;
                    if (main == "FirstName")
                    {
                        cmdd = "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact, [Email] = @Email, [DateOfBirth] = @DateOfBirth, " +
                            "[GENDER] = (SELECT Id FROM Lookup WHERE Category = 'GENDER' AND Value = @Gender)  WHERE FirstName = @Value;" +
                            " UPDATE Advisor SET [Designation] = @Designation, [Salary] = @Salary  WHERE Id = (SELECT Id FROM Person WHERE FirstName =  @Value)";
                    }
                    else if (main == "LastName")
                    {
                        cmdd = "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact , [Email] = @Email, [DateOfBirth] = @DateOfBirth, " +
                            "[GENDER] = (SELECT Id FROM Lookup WHERE Category = 'GENDER'  AND Value= @Gender)  WHERE LastName = @Value; " +
                            " UPDATE Advisor SET [Designation] = @Designation, [Salary] = @Salary  WHERE Id = (SELECT Id FROM Person WHERE LastName =  @Value)";

                    }
                    else
                    {
                        cmdd = "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact , [Email] = @Email, [DateOfBirth] = @DateOfBirth, " +
                               "[GENDER] = (SELECT Id FROM Lookup WHERE Category = 'GENDER' AND Value = @Gender)  WHERE Contact = @Value;" +
                               " UPDATE Advisor SET [Designation] = @Designation, [Salary] = @Salary  WHERE Id = (SELECT Id FROM Person WHERE Contact =  @Value)";
                    }

                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmdd, conn);
                    command.Parameters.AddWithValue("@Value", textBox1.Text);
                    //command.Parameters.AddWithValue("@RegistrationNo", textBox5.Text);
                    command.Parameters.AddWithValue("@FirstName", textBox7.Text);
                    command.Parameters.AddWithValue("@LastName", textBox6.Text);
                    command.Parameters.AddWithValue("@Contact", textBox2.Text);
                    command.Parameters.AddWithValue("@Email", textBox4.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Text);
                    command.Parameters.AddWithValue("@Salary", textBox5.Text);

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
                        command.Parameters.AddWithValue("@Designation", "Litraturer");
                    }
                    else if (radioButton3.Checked)
                    {
                        command.Parameters.AddWithValue("@Designation", "Professor");
                    }
                    else if (radioButton4.Checked)
                    {
                        command.Parameters.AddWithValue("@Designation", "Industry Professor");
                    }
                    else if (radioButton5.Checked)
                    {
                        command.Parameters.AddWithValue("@Designation", "Assisstant Professor");
                    }
                    else if (radioButton6.Checked)
                    {
                        command.Parameters.AddWithValue("@Designation", "Associate Professor");
                    }
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hurrah! Record Updated");
                    conn.Close();
                    //close connection
                    //close connection*/
                }
                else
                {
                    MessageBox.Show(Error);
                }

            }
            else
            {
                MessageBox.Show("Please enetr the data");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            var form1 = new mainupdatestudent();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
