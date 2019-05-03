using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProjectA
{
    public partial class pdf : Form
    {
        public pdf()
        {
            InitializeComponent();
        }

        private void pdf_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream("E:/final.pdf", FileMode.Create));
                document.Open();
                //Paragraph p = new Paragraph("Test");
                PdfPTable table = new PdfPTable(2);
                table.TotalWidth = 216f;
                table.LockedWidth = true;
                float[] widths = new float[] { 2f, 2f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingBefore = 20f;
                PdfPCell cell = new PdfPCell(new Phrase("Project display"));
                // PdfPCell cell = new PdfPCell(new Phrase("Project"));
                cell.Colspan = 2;
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);
                //connection URL
                string conURL = "Data source=ProjectA.sqlite; Trusted_Connection = True;";
                //Connection with DB
                using (SQLiteConnection conn = new SQLiteConnection(conURL))
                {
                    string cmd = "SELECT [Description],[Title] FROM Project ";
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    try
                    {
                        conn.Open();
                        using (SQLiteDataReader rdr = command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                table.AddCell(rdr[0].ToString());
                                table.AddCell(rdr[1].ToString());
                                table.AddCell(rdr[2].ToString());
                            }
                        }
                    }
                    catch 
                    {
                        //Response.Write(ex.Message);
                        //MessageBox.Show("wroooooooong");
                    }
                    document.Add(table);
                }
                document.Add(table);
                document.Close();
            }
            catch
            {

            }
         }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream("E:/final1.pdf", FileMode.Create));
                document.Open();
                Paragraph p = new Paragraph("Test");
                PdfPTable table = new PdfPTable(3);
                table.TotalWidth = 216f;
                table.LockedWidth = true;
                float[] widths = new float[] { 2f, 2f};
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingBefore = 20f;
                PdfPCell cell = new PdfPCell(new Phrase("Display Advisor"));
                // PdfPCell cell = new PdfPCell(new Phrase("Project"));
                cell.Colspan = 2;
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);
                //connection URL
                string conURL = "Data source=ProjectA.sqlite;";
                //Connection with DB
                using (SQLiteConnection conn = new SQLiteConnection(conURL))
                {
                    string cmd = "SELECT [FirstName],[LastName],[Contact],[Email],[DateOfBirth],[Gender],[Designation],[Salary] FROM Person JOIN Advisor ON Person.Id =  Advisor.Id";
                    SQLiteCommand command = new SQLiteCommand(cmd, conn);
                    try
                    {
                        conn.Open();
                        using (SQLiteDataReader rdr = command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                table.AddCell(rdr[0].ToString());
                                table.AddCell(rdr[1].ToString());
                                table.AddCell(rdr[2].ToString());
                            }
                        }
                    }
                    catch 
                    {
                        //Response.Write(ex.Message);
                        //MessageBox.Show("wroooooooong");
                    }
                    document.Add(table);
                }
                document.Add(table);
                document.Close();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new index();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}
