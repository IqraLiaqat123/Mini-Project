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
    public partial class deletegroup : Form
    {
        public deletegroup()
        {
            InitializeComponent();
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
                    string cmd = "DELETE FROM [group] WHERE Name = @GroupName";
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@GroupName", textBox1.Text);
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
                MessageBox.Show("First insert data");
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
