﻿using System;
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
    public partial class UpdateProject : Form
    {
        public UpdateProject()
        {
            InitializeComponent();
        }
        public String Error;
        public bool Validations()
        {
            if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = " Incorrect Designation !";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Title !";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox2.Text != "")
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
                    if (main == "Description")
                    {
                        cmd = "UPDATE Project SET [Description] = @Description, [Title] = @Title  WHERE Description = @Value";
                    }
                    else
                    {
                        cmd = "UPDATE Project SET [Description] = @Description, [Title] = @Title  WHERE Title = @Value";
                    }
                    //preparing statement
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    command.Parameters.AddWithValue("@Value", textBox1.Text);
                    command.Parameters.AddWithValue("@Description", textBox3.Text);
                    command.Parameters.AddWithValue("@Title", textBox2.Text);
                    //command.Parameters.AddWithValue("@NewTotalWeightage", textBox3.Text);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hurrah! Record Updated");
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
                MessageBox.Show("Please Enter Data");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        
    }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
