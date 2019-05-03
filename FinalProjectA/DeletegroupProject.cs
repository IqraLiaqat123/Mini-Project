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
    public partial class DeletegroupProject : Form
    {
        public DeletegroupProject()
        {
            InitializeComponent();
        }
        //deleting a record form group project
        private void button1_Click(object sender, EventArgs e)
        {
            //connection URL
            string conURL = "Data source=ProjectA.sqlite";
            //Connection with DB
            SQLiteConnection conn = new SQLiteConnection(conURL);
            string main = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string cmdd;
            //DELETE  Statement
            if(main == "Name")
            {
                cmdd = "DELETE FROM GroupProject  WHERE GroupId = (SELECT Id FROM [group] WHERE Name =  @Value)";
            }
            else
            {
                cmdd = "DELETE FROM GroupProject  WHERE ProjectId = (SELECT Id FROM [Project] WHERE Title =  @Value)";
            }
            
            //preparing statement
            SQLiteCommand command = new SQLiteCommand(cmdd, conn);
            command.Parameters.AddWithValue("@Value", textBox1.Text);
            conn.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Hurrah! Record Deleted");
            //close connection
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
