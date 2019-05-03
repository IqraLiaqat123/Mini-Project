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
    public partial class mainupdatestudent : Form
    {
        public mainupdatestudent()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new UpdateStudent();
            form1.Closed += (s, args) => this.Close();
            form1.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new UpdateAdviser();
            form1.Closed += (s, args) => this.Close();
            form1.Show();

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
