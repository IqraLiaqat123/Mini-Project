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

namespace FinalProjectA
{
    public partial class DisplayEvaluation : Form
    {
        public DisplayEvaluation()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter sdq;
        //display record
        private void button1_Click(object sender, EventArgs e)
        {
            //connection URL
            string conURL = "Data source=ProjectA.sqlite";
            //Connection with DB
            SQLiteConnection conn = new SQLiteConnection(conURL);
            //Insert Statement
            string cmd = "SELECT [Name],[TotalMarks], [TotalWeightage] FROM Evaluation ";
            //preparing statement
            SQLiteCommand command = new SQLiteCommand(cmd, conn);
            //open connection
            conn.Open();
            command.Connection = conn;
            DataTable dt1 = new DataTable();
            sdq = new SQLiteDataAdapter("SELECT [Name],[TotalMarks], [TotalWeightage] FROM Evaluation", conn);
            sdq.Fill(dt1);
            dataGridView1.DataSource = dt1;
            MessageBox.Show("Hurrah!Evaluation Displayed");
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
