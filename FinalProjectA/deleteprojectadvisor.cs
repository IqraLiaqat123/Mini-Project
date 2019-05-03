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
    public partial class deleteprojectadvisor : Form
    {
        public deleteprojectadvisor()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect GroupName !";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new index();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (Validations())
                {
                    //connection URL
                    string conURL = "Data source=ProjectA.sqlite";
                    //Connection with DB
                    SQLiteConnection conn = new SQLiteConnection(conURL);
                    //DELETE  Statement
                    string cmdd = "DELETE FROM ProjectAdvisor  WHERE ProjectId = (SELECT Id FROM Project WHERE Title =  @ProjectName)";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmdd, conn);
                    command.Parameters.AddWithValue("@ProjectName", textBox1.Text);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hurrah! Record Deleted");
                    //close connection
                    conn.Close();
                }
                else
                {
                    MessageBox.Show(Error);
                }
            }
            else
            {
                MessageBox.Show("Please insert data first!");
            }
           
        }
    }
}
