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
    public partial class updategroupProject : Form
    {
        public updategroupProject()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Title !";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect GroupName! ";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect ProjectName! ";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "" && comboBox1.Text != "" )
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert Statement
                    string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    string cmdd;
                    if (main == "Name")
                    {
                        cmdd = "UPDATE GroupProject SET [ProjectId] = (SELECT Id FROM [Project] WHERE Title = @ProjectName), "+
                                "[GroupId] = (SELECT Id FROM [group] WHERE Name = @GroupName), [AssignmentDate] = @AssignmentDate " +
                                "WHERE GroupId = (SELECT Id FROM [group] WHERE Name = @Value)";
                   }
                   else
                    {
                        cmdd = "UPDATE GroupProject SET [ProjectId] = (SELECT Id FROM [Project] WHERE Title = @ProjectName), " +
                                "[GroupId] = (SELECT Id FROM [group] WHERE Name = @GroupName), [AssignmentDate] = @AssignmentDate " +
                                "WHERE ProjectId = (SELECT Id FROM [Project] WHERE Title = @Value)"; 
                    }
                    /*string cmdd = "UPDATE GroupProject SET [ProjectId] = (SELECT Id FROM [Project] WHERE Title = @ProjectName), " +
                                "[GroupId] = (SELECT Id FROM [group] WHERE Name = @GroupName), [AssignmentDate] = @AssignmentDate " +
                                "WHERE ProjectId = (SELECT Id FROM [Project] WHERE Title = @Title)";*/
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmdd, conn);
                    command.Parameters.AddWithValue("@Value", textBox1.Text);
                    command.Parameters.AddWithValue("@GroupName", textBox2.Text);
                    command.Parameters.AddWithValue("@ProjectName", textBox3.Text);
                    command.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Text);
                    conn.Open();
                    command.ExecuteNonQuery();
                    //display message
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
                //display message
                MessageBox.Show("Please Enter the Data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new index();
            index.Closed += (s, args) => this.Close();
            index.Show();

        }
    }
}
