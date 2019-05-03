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
    public partial class updategroup : Form
    {
        public updategroup()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Name! ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text !="")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //Insert Statement
                    string cmd = "UPDATE [group] SET [Name] = @GroupName, [Created_On] = @CreatedOn WHERE Name = @Value";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@Value", textBox1.Text);
                    command.Parameters.AddWithValue("@GroupName", textBox2.Text);
                    command.Parameters.AddWithValue("@CreatedOn", dateTimePicker1.Text);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
