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

namespace Registration
{
    public partial class Reception_frm : Form
    {
        public Reception_frm()
        {
            InitializeComponent();
            date_time();
            showw();
            
        }
        string str = "Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medical_Records;Integrated Security=True";
        string gender, occupation, Martial_status, education;
        string img_path, curr_listbox_item;

        private void date_time()
        {
            DateTime str = DateTime.Now;
            textBox_date_time.Text = str.ToString();
        }
        private void showw()
        {
            
        }
        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_LeftToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void Reception_frm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Reg_new_pt_Click(object sender, EventArgs e)
        {

        }

        private void listbox_regpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            curr_listbox_item = listbox_regpt.SelectedIndex.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void tab_modify_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //convert image to binary code-
                byte[] img = null;
                FileStream fstream = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                img = br.ReadBytes((int)fstream.Length);


                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "INSERT INTO Student_Profile(First_Name,Middle_Name,Last_Name,DOB,Education,Branch,Year_Of_Joining,ID,Gender,Corres_Address,Perm_Address,Local_Address,Contact_num,Guar_contact,Martial_Status,Blood_group,Insurance_num,Image)VALUES('" + this.textBox_fname.Text + "','" + this.textBox_mname.Text+ "','" + this.textBox_lname.Text+ "','"+this.dateTimePicker_dob.Text+"','"+education+"','"+this.textBox_branch.Text+"','"+this.dateTimePicker_Y_of_joining.Text+"','"+this.textBox_id.Text+"','"+gender+"','"+this.richTextBox_corres_add.Text+"','"+this.richTextBox_perm_add.Text+"','"+this.richTextBox_local_guad_Add.Text+"','"+this.textBox_contact.Text+"','"+this.textBox_guad_contact.Text+"','"+Martial_status+"','"+this.comboBox_blood.Text+"','"+this.textBox_ins_no.Text+"',@IMG)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@IMG",img));
                cmd.ExecuteNonQuery();

                string tab = "CREATE TABLE " + textBox_id.Text + "(Date_Time varchar(50),Chief_Complaint varchar(250),Diagnosis varchar(250),Observation varchar(250),Image_docs image,Generic_Name varchar(200),Brands_Name varchar(200),Doses varchar(200),Frequency varchar(200),Days varchar(200),Exp varchar(200))";
                SqlCommand tcmd = new SqlCommand(tab,conn);
                tcmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data Inserted Successfully");

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton_male_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void btn_img_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files(*.jpg|*.jpg|PNG Files(*.PNG|*.png|All Files(*.*)|*.*";
            if (op.ShowDialog()== DialogResult.OK)
            {
                string PicLoc = op.FileName.ToString();
                img_path= PicLoc;
                pictureBox_pic.ImageLocation = PicLoc;
            }

        }

        private void radioBtn_btech_CheckedChanged(object sender, EventArgs e)
        {
            education = "B Tech.";
        }

        private void radioBtn_mtech_CheckedChanged(object sender, EventArgs e)
        {
            education = "M Tech.";
        }

        private void radio_btn_phd_CheckedChanged(object sender, EventArgs e)
        {
            education = "PHD";
        }

        private void radioButton_female_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void radioButton_g_other_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Other";
        }

        private void radioButton_married_CheckedChanged(object sender, EventArgs e)
        {
            Martial_status = "Married";
        }

        private void radioButton_unmarried_CheckedChanged(object sender, EventArgs e)
        {
            Martial_status = "UnMarried";
        }

        private void radioButton_student_CheckedChanged(object sender, EventArgs e)
        {
            occupation = "Student";
        }

        private void radioButton_faculty_CheckedChanged(object sender, EventArgs e)
        {
            occupation = "Faculty";
        }

        private void radioButton_other_CheckedChanged(object sender, EventArgs e)
        {
            occupation = "Other";
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "INSERT INTO Pt_entry_per_day(ID,Pt_Name,Date_Time,Complain)VALUES('" + this.text_roll.Text + "','" + this.text_pt.Text + "','" + this.textBox_date_time.Text + "','" + this.richText_complain.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data Inserted Successful");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox_vpd_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string s = "cse1200115";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM Student_Profile WHERE ID='" +textBox_vpd_id.Text+ "';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    textBox_vpd_fname.Text = reader.GetString(0);
                    textBox_vpd_mname.Text = reader.GetString(1);
                    textBox_lname.Text = reader.GetString(2);
                    textBox_vpd_dob.Text = reader.GetString(3);
                    textBox_vpd_edu.Text = reader.GetString(4);
                    textBox_vpd_branch.Text = reader.GetString(5);
                    textBox_vpd_year_of_join.Text = reader.GetString(6);
                    textBox_vpd_gender.Text = reader.GetString(8);
                    richTextBox_vpd_corres_add.Text = reader.GetString(9);
                    richTextBox_vpd_perm_add.Text = reader.GetString(10);
                    richTextBox_vpd_local_add.Text = reader.GetString(11);
                    textBox_vpd_contact.Text = reader.GetString(12);
                    textBox_vpd_guad_contact.Text = reader.GetString(13);
                    textBox_vpd_martial.Text = reader.GetString(14);
                    textBox_vpd_blood.Text = reader.GetString(15);
                    textBox_vpd_insurance.Text = reader.GetString(16);

                    byte[] imgg = (byte[])(reader["Image"]);
                    if (imgg == null)
                    {
                        pictureBox_vpd.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        pictureBox_vpd.Image = System.Drawing.Image.FromStream(ms);
                    }

                }
                else
                {
                    textBox_vpd_fname.Text = "";
                    textBox_vpd_mname.Text = "";
                    textBox_lname.Text = "";
                    textBox_vpd_dob.Text = "";
                    textBox_vpd_edu.Text = "";
                    textBox_vpd_branch.Text = "";
                    textBox_vpd_year_of_join.Text = "";
                    textBox_vpd_gender.Text = "";
                    richTextBox_vpd_corres_add.Text = "";
                    richTextBox_vpd_perm_add.Text = "";
                    richTextBox_vpd_local_add.Text = "";
                    textBox_vpd_contact.Text = "";
                    textBox_vpd_guad_contact.Text = "";
                    textBox_vpd_martial.Text = "";
                    textBox_vpd_blood.Text = "";
                    textBox_vpd_insurance.Text = "";
                    pictureBox_vpd.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }




    }
}
