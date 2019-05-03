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
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text !="" && textBox7.Text !="" && textBox6.Text !="" && textBox4.Text != "" && dateTimePicker1.Text != "" && textBox2.Text !="" && textBox1.Text != "")
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
                    string cmd;
                    if (main == "RegistratioNo")
                    {
                        cmd = "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact , [Email] = @Email, [DateOfBirth] = @DateOfBirth, " +
                            "[GENDER] = (SELECT Id FROM Lookup WHERE Category = 'GENDER' AND Value = @Gender)  WHERE Id = (SELECT Id FROM Student  WHERE RegistrationNo = @Value);" +
                            " UPDATE Student SET [RegistrationNo] = @RegistrationNo WHERE  RegistrationNo= @Value)";
                    }
                    else if (main == "FirstName")
                    {
                        cmd = "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact , [Email] = @Email, [DateOfBirth] = @DateOfBirth, " +
                            "[GENDER] = (SELECT Id FROM Lookup WHERE Category = 'GENDER' AND Value = @Gender)  WHERE FirstName = @Value ;" +
                            " UPDATE Student SET [RegistrationNo] = @RegistrationNo WHERE Id = (SELECT Id FROM Person WHERE FirstName =  @Value)";
                    }
                    else
                    {
                        cmd = "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact , [Email] = @Email, [DateOfBirth] = @DateOfBirth," +
                            "[GENDER] = (SELECT Id FROM Lookup WHERE Category = 'GENDER' AND Value = @Gender) WHERE Contact = @Value;" +
                            " UPDATE Student SET [RegistrationNo] = @RegistrationNo WHERE  Id = (SELECT Id FROM Person WHERE Contact = @Value)";
                    }
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@Value", textBox1.Text);
                    command.Parameters.AddWithValue("@RegistrationNo", textBox5.Text);
                    command.Parameters.AddWithValue("@FirstName", textBox7.Text);
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
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hurrah! Record Updated");
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
                MessageBox.Show("Please Enter the Data");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new mainupdatestudent();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
