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
            if (tabControl1.SelectedTab == tabPage3)
            {
                try
                {

                    DateTime now = DateTime.Now;
                    string date_time = now.ToString();

                    string generic_type = "",doses = "", frequncy = "";
                    for (int i = 0; i < dataGridView_new_visit.Rows.Count - 1; i++)
                    {
                        generic_type= generic_type+ dataGridView_new_visit.Rows[i].Cells[0].Value + ",";
                        doses = doses + dataGridView_new_visit.Rows[i].Cells[1].Value + ",";
                        frequncy = frequncy + dataGridView_new_visit.Rows[i].Cells[2].Value + ",";
                    }

                    

                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    if (img_path=="")
                    {
                        string query = "INSERT INTO " + curr_listbox_item + "(Date_Time,Chief_Complaint,Diagnosis,Observation,Generic_Name,Doses,Frequency)VALUES('" + date_time + "','" + this.richTextBox_new_chief_complaint.Text + "','" + this.richTextBox_next_diagnosis.Text + "','" + this.richTextBox_next_observation.Text + "','" + generic_type + "','" + doses + "','" + frequncy + "')";
                        SqlCommand cmd = new SqlCommand(query,conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted Successfully");
                    }
                    else
                    {
                        byte[] img = null;
                        FileStream fstream = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fstream);
                        img = br.ReadBytes((int)fstream.Length);

                        string query = "INSERT INTO " + curr_listbox_item + "(Date_Time,Chief_Complaint,Diagnosis,Observation,Image_docs,Generic_Name,Doses,Frequency)VALUES('" + date_time + "','" + this.richTextBox_new_chief_complaint.Text + "','" + this.richTextBox_next_diagnosis.Text + "','" + this.richTextBox_next_observation.Text + "',@IMG,'" + generic_type + "','" + doses + "','" + frequncy + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.Add(new SqlParameter("@IMG", img));
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Data Inserted Successfully");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (tabControl1.SelectedTab == tabPage4)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string query = "UPDATE Student SET Allergy='" + richTextBox_allergy.Text + "',Observations='" + richTextBox_oservation.Text + "',Family_history='" + richTextBox_rich_history.Text + "',Social_history='" + richTextBox_social_history.Text + "' WHERE ID='"+curr_listbox_item+"'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data saved Succsessfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
               
            
           

        }

        void LoadImages()
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                string query = "SELECT * FROM " + curr_listbox_item + " WHERE Image_docs IS NOT NULL";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                listBox_image.Items.Clear();

                while (reader.Read())
                {
                    listBox_image.Items.Add(reader.GetString(0));
                }
                conn.Close();
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
                string query = "SELECT * FROM Student WHERE ID='"+curr_listbox_item+"';";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                textBox_fname.Clear();
                textBox_mname.Clear();
                textBox_lname.Clear();
                textBox5_dob.Clear();
                textBox_education.Clear();
                textBox_branch.Clear();
                textBox_Y_of_joining.Clear();
                textBox_roll_no.Clear();
                textBox_gender.Clear();
                richTextBox_permanent_Add.Clear();
                richTextBox_local_add.Clear();
                textBox_pt_record.Clear();
                textBox_gud_contact.Clear();
                textBox_martial_status.Clear();
                textBox_blood.Clear();
                textBox_emailid.Clear();
                richTextBox_observation.Clear();

                //for allergy tab.
                richTextBox_allergy.Clear();
                richTextBox_oservation.Clear();
                richTextBox_rich_history.Clear();
                richTextBox_social_history.Clear();
                pictureBox_roll_no.Image = null;


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
                    textBox_emailid.Text = reader.GetString(22);
                    richTextBox_observation.Text = reader.GetString(19);

                    //for allergy tab.
                    richTextBox_allergy.Text = reader.GetString(18);
                    richTextBox_oservation.Text = reader.GetString(19);
                    richTextBox_rich_history.Text = reader.GetString(20);
                    richTextBox_social_history.Text = reader.GetString(21);

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

                //show all the previous visits.
                PreviousVisits();
                LoadImages();
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
            string date = listBox_prevvisits.SelectedItem.ToString();
       
            
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM "+curr_listbox_item+" WHERE Date_Time ='"+date+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                richTextBox_prev_chief_complaint.Clear();
                richTextBox_prev_diagnosis.Clear();
                richTextBox_prev_observation.Clear();
                dataGridView_previous.DataSource = null;
                dataGridView_previous.Rows.Clear();
                dataGridView_previous.Refresh();

                while(reader.Read())
                {
                    richTextBox_prev_chief_complaint.Text = reader.GetString(1);
                    richTextBox_prev_diagnosis.Text = reader.GetString(2);
                    richTextBox_prev_observation.Text = reader.GetString(3);
                    
                   string[] med = reader.GetString(5).Split(',');
                   string[] dos = reader.GetString(6).Split(',');
                   string[] freq = reader.GetString(7).Split(',');
                   for (int i = 0; i < med.Length-1; i++)
                       dataGridView_previous.Rows.Add(med[i], dos[i], freq[i]);
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
                string query = "SELECT * FROM Student WHERE ID = '"+textBox_search.Text+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                textBox_vpd_fname.Clear();
                textBox_vpd_mname.Clear();
                textBox_vpd_lname.Clear();
                textBox_vpd_dob.Clear();
                textBox_vpd_education.Clear();
                textBox_vpd_branch.Clear();
                textBox_vpd_Y_of_joining.Clear();
                textBox_vpd_id.Clear();
                textBox_vpd_gender.Clear();
                richTextBox_vpd_permanent_add.Clear();
                richTextBox_vpd_local_add.Clear();
                textBox_vpd_pts_contact.Clear();
                textBox_vpd_gud_contact.Clear();
                textBox_vpd_email.Clear();
                textBox_vpd_blood.Clear();
                textBox_vpd_martial_status.Clear();
                richTextBox_vpd_obsevation.Clear();
                pictureBox_vpd_img.Image = null;


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
                    textBox_vpd_pts_contact.Text=reader.GetString(13);
                    textBox_vpd_gud_contact.Text = reader.GetString(14);
                    textBox_vpd_email.Text=reader.GetString(22);
                    textBox_vpd_blood.Text = reader.GetString(15);
                    textBox_vpd_martial_status.Text=reader.GetString(14);
                    richTextBox_vpd_obsevation.Text=reader.GetString(19);



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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox_image_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = listBox_image.SelectedItem.ToString();
        
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM " + curr_listbox_item + " WHERE Date_Time ='" + date + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    byte[] imgg = (byte[])(reader["Image_docs"]);
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

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userProfile frm = new userProfile();
            frm.ShowDialog();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userProfile frm = new userProfile();
            frm.ShowDialog();
        }

        private void changeUsernameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            password frm = new password();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            password frm = new password();
            frm.ShowDialog();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Leave(object sender, EventArgs e)
        {
            
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        void PreviousVisits()
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM " + curr_listbox_item + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                listBox_prevvisits.Items.Clear();
                while (reader.Read())
                {
                    listBox_prevvisits.Items.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            //PreviousVisits();
        }
    }
}
