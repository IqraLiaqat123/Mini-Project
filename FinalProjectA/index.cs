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
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
 
        private void index_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
           
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new DisplayStudent();
            student.Closed += (s, args) => this.Close();
            student.Show();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
           
        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new DisplayAdviser();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new UpdateAdviser();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new DeleteAdviser();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new AddProject();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new DisplayProject();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new UpdateProject();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new DeleteProject();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new AddEvaluation();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new DisplayEvaluation();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new UpdateEvaluation();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.Hide();
            var student = new DeleteEvaluation();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new Main();
            index.Closed += (s, args) => this.Close();
            index.Show();

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new addgroupProject();
            index.Closed += (s, args) => this.Close();
            index.Show();

        }

        private void button36_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new displaygroupProject();
            index.Closed += (s, args) => this.Close();
            index.Show();

        }

        private void button35_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new updategroupProject();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new DeletegroupProject();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new AddGroup();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new displaygroup();
            index.Closed += (s, args) => this.Close();
            index.Show();

        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new deletegroup();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new updategroup();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new addgroupstudent();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new displayevaluationproject();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button43_Click(object sender, EventArgs e)
        {
           /* this.Hide();
            var index = new updategroupstudent();
            index.Closed += (s, args) => this.Close();
            index.Show();*/
        }

        private void button42_Click(object sender, EventArgs e)
        {

            this.Hide();
            var index = new deletegroupstudent();
            index.Closed += (s, args) => this.Close();
            index.Show();

        }

        private void button44_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new displaygroupstudent();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var index = new maindisplaystudent();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new addgroupevaluation();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new deletegroupevaluation();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new addprojectadvisor();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = new displayprojectadvisor();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button43_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var index = new deleteprojectadvisor();
            index.Closed += (s, args) => this.Close();
            index.Show();
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var student = new mainstudent();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var student = new mainupdatestudent();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var student = new maindeletestudent();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var student = new pdf();
            student.Closed += (s, args) => this.Close();
            student.Show();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            /*this.Hide();
            var student = new Lab9();
            student.Closed += (s, args) => this.Close();
            student.Show();*/

        }
    }
}
