using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Doctor_Window
{
    public partial class Doctor_frm : Form
    {
        public Doctor_frm()
        {
            InitializeComponent();
            queue();
            prevVisits();
        }

        string str ="Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medical_Records;Integrated Security=True";
        string curr_listbox_item="";
        string img_path="";

        
        private void queue()
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM Pt_entry_per_day";
                SqlCommand cmd = new SqlCommand(query, conn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    listBox_patients.Items.Add(id);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void prevVisits()
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM '"+curr_listbox_item+"';";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string date_time = reader.GetString(0);
                    listBox_patients.Items.Add(date_time);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
        private void changeUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
          
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter write = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\SONY\\Desktop\\Test.pdf", FileMode.Create));
                doc.Open();

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("logo.png");
                img.ScalePercent(25f);
                img.SetAbsolutePosition(75, 650);
                doc.Add(img);


                PdfContentByte cb = write.DirectContent;
                // Bottom left coordinates x & y, followed by width, height and radius of corners.
                cb.RoundRectangle(50f, 640f, 520f, 0f, 0f);
                cb.Stroke();

                PdfContentByte cbb = write.DirectContent;
                // Bottom left coordinates x & y, followed by width, height and radius of corners.
                cbb.RoundRectangle(50f, 550f, 520f, 70f, 2f);
                cbb.Stroke();

                PdfContentByte cbp = write.DirectContent;
                // Bottom left coordinates x & y, followed by width, height and radius of corners.
                cbp.RoundRectangle(30f, 15f, 540f, 0f, 0f);
                cbp.Stroke();

                Paragraph par = new Paragraph("\n\n\n\n\n\n\nFirst Name : Nitish                                                                                                Gender: Male\nMiddle Name: Kumar                                                                                        Blood group: O+\nLast Name: Bharti                                                                                               Date:19/02/2014");
                par.IndentationLeft = 50f;
                doc.Add(par);

                // Medicines here.
                /*PdfPTable tab = new PdfPTable(dataGridView1.Columns.Count);
                // Adding header of the datagrid view
                for (int i = 0; i < DataGridView1.Columns.Count; i++)
                {
                    tab.AddCell(new Phrase(DataGridView1.Columns[i].HeaderText));
                }
                // flag the first row as header
                tab.HeaderRows = 1;

                // Add the actual rows
                for (int i = 0; i < DataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < DataGridView1.Columns.Count; j++)
                    {
                        if (DataGridView1[j, i].value != null)
                        {
                            tab.AddCell(new Phrase(DataGridView1[KeyDown, i].Value.ToString()));
                        }
                    }
                }
                doc.Add(tab); */


                Paragraph footer = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n                                          Thank you for choosing IIT Indore Hospital Service.");
                footer.Alignment = Element.ALIGN_BOTTOM;
                doc.Add(footer);


        

                


                doc.Close();
                MessageBox.Show("PDF created successfully");

                System.Diagnostics.Process.Start("C:\\Users\\SONY\\Desktop\\Test.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime now = DateTime.Now;
                string date_time = now.ToString();

                string generic = "", brand = "", doses = "", frequncy = "", days = "", exp = "";
                for (int i = 0; i < dataGridView_new_visit.Rows.Count - 1; i++)
                {
                    generic = generic + dataGridView_new_visit.Rows[i].Cells[0].Value+",";
                    brand = brand + dataGridView_new_visit.Rows[i].Cells[1].Value+",";
                    doses = doses + dataGridView_new_visit.Rows[i].Cells[2].Value+",";
                    frequncy = frequncy + dataGridView_new_visit.Rows[i].Cells[3].Value+",";
                    days = days + dataGridView_new_visit.Rows[i].Cells[4].Value+",";
                    exp = exp + dataGridView_new_visit.Rows[i].Cells[5].Value+",";
                }

                byte[] img = null;
                FileStream fstream = new FileStream(img_path,FileMode.Open,FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                img = br.ReadBytes((int)fstream.Length);

                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "INSERT INTO " + curr_listbox_item + "(Date_Time,Chief_Complaint,Diagnosis,Observation,Image_docs,Generic_Name,Brands_Name,Doses,Frequency,Days,Exp)VALUES('" + date_time + "','" + this.richTextBox_new_chief_complaint.Text + "','" + this.richTextBox_next_diagnosis.Text + "','" + this.richTextBox_next_observation.Text + "',@IMG,'" + generic + "','" + brand + "','" + doses + "','" + frequncy + "','" + days + "','" + exp + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@IMG",img));
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listBox_patients_SelectedIndexChanged(object sender, EventArgs e)
        {
            curr_listbox_item = listBox_patients.SelectedItem.ToString();

            try
            {
                string query = "SELECT * FROM Student_Profile WHERE ID='"+curr_listbox_item+"';";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBox_fname.Text = reader.GetString(0);
                    textBox_mname.Text = reader.GetString(1);
                    textBox_lname.Text = reader.GetString(2);
                    textBox5_dob.Text = reader.GetString(3);
                    textBox_education.Text = reader.GetString(4);
                    textBox_branch.Text = reader.GetString(5);
                    textBox_Y_of_joining.Text = reader.GetString(6);
                    textBox_roll_no.Text = reader.GetString(7);
                    textBox_gender.Text = reader.GetString(8);
                    richTextBox_permanent_Add.Text = reader.GetString(10);
                    richTextBox_local_add.Text = reader.GetString(11);
                    textBox_pt_record.Text = reader.GetString(12);
                    textBox_gud_contact.Text = reader.GetString(13);
                    textBox_martial_status.Text=reader.GetString(14);
                    textBox_blood.Text = reader.GetString(15);

                    byte[] imgg = (byte[])(reader["Image"]);
                    if (imgg == null)
                    {
                        pictureBox_roll_no.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        pictureBox_roll_no.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("Data not present");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void new_img_up_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files(*.jpg|*.jpg|PNG Files(*.PNG|*.png|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                string PicLoc = op.FileName.ToString();
                img_path = PicLoc;
                pictureBox_new_visit.ImageLocation = PicLoc;
            }
        }

        private void listBox_prevvisits_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = listBox_prevvisits.SelectedIndex.ToString();

            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM '"+curr_listbox_item+"' WHERE Date_Time = '"+date+"';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    richTextBox_prev_chief_complaint.Text = reader.GetString(1);
                    richTextBox_prev_diagnosis.Text = reader.GetString(2);
                    richTextBox_prev_observation.Text = reader.GetString(3);
                }
                else
                {
                    MessageBox.Show("Data not present in the list");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM Student_Profile WHERE ID = '"+textBox_search.Text+"';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBox_vpd_fname.Text = reader.GetString(0);
                    textBox_vpd_mname.Text = reader.GetString(1);
                    textBox_vpd_lname.Text = reader.GetString(2);
                    textBox_vpd_dob.Text = reader.GetString(3);
                    textBox_vpd_education.Text = reader.GetString(4);
                    textBox_vpd_branch.Text = reader.GetString(5);
                    textBox_vpd_Y_of_joining.Text = reader.GetString(6);
                    textBox_vpd_id.Text = reader.GetString(7);
                    textBox_vpd_gender.Text = reader.GetString(8);
                    richTextBox_vpd_permanent_add.Text = reader.GetString(10);
                    richTextBox_vpd_local_add.Text = reader.GetString(11);
                    textBox_vpd_pts_contact.Text = reader.GetString(12);
                    textBox_vpd_gud_contact.Text = reader.GetString(13);

                    byte[] imgg = (byte[])(reader["Image"]);
                    if (imgg == null)
                    {
                        pictureBox_vpd_img.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        pictureBox_vpd_img.Image = System.Drawing.Image.FromStream(ms);
                    }

                }
                else
                {
                    textBox_vpd_fname.Text = "";
                    textBox_vpd_mname.Text = "";
                    textBox_vpd_lname.Text = "";
                    textBox_vpd_dob.Text = "";
                    textBox_vpd_education.Text = "";
                    textBox_vpd_branch.Text ="";
                    textBox_vpd_Y_of_joining.Text ="";
                    textBox_vpd_id.Text ="";
                    textBox_vpd_gender.Text = "";
                    richTextBox_vpd_permanent_add.Text = "";
                    richTextBox_vpd_local_add.Text ="";
                    textBox_vpd_pts_contact.Text ="";
                    textBox_vpd_gud_contact.Text ="";

                    pictureBox_vpd_img.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox_image_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = listBox_image.SelectedIndex.ToString();
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM '" + curr_listbox_item + "' WHERE Date_Time = '" + date + "';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    byte[] imgg = (byte[])(reader["Image"]);
                    if (imgg == null)
                    {
                        pictureBox_img.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        pictureBox_img.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox_img.Image = null;
                    MessageBox.Show("Data not present in the list");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
