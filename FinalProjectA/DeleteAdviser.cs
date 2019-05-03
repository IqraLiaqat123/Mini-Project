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

namespace FinalProjectA
{
    public partial class DeleteAdviser : Form
    {
        public DeleteAdviser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteAdviser_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && comboBox2.Text !="")
            {
                //connection URL
                string conURL = "Data source=ProjectA.sqlite";
                //Connection with DB
                SQLiteConnection conn = new SQLiteConnection(conURL);
                //Insert Statement
                string main = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                //string cmdd= "DELETE FROM Advisor  WHERE (SELECT Id FROM Person WHERE FirstName =  @Value)";
                string cmdd;
                if (main == "Contact")
                {
                    cmdd = "DELETE FROM Advisor WHERE (SELECT Id FROM Person WHERE  [Contact] =  @Value)";
                }
                else
                {
                    cmdd = "DELETE FROM Advisor  WHERE (SELECT Id FROM Person WHERE  [FirstName] =  @Value)";
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();

        }
    }
}
