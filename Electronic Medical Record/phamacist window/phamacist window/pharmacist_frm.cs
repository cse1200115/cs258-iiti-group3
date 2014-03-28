using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace phamacist_window
{
    public partial class pharmacist_frm : Form
    {
        public pharmacist_frm()
        {
            InitializeComponent();
        }

        string str="Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medical_Records;Integrated Security=True";
        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "INSERT INTO Medicines(Generic_Name,Brands_Name,Batch_Num,Mfg,Exp,Quantity)VALUES('" + this.textBox_generic.Text + "','" + this.textBox_brands.Text + "','" + this.textBox_batch.Text + "','" + this.dateTimePicker_mfg.Text + "','" + this.dateTimePicker_exp.Text + "','" + this.textBox_quan.Text + "') ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data Insereted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox_batch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_MouseCaptureChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string batch = textBox6.Text;
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT *FROM Medicines WHERE Batch_Num = " + textBox6.Text;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.Read())
                {

                    textBox_gen.Text = reader.GetString(0);
                    textBox_brand.Text = reader.GetString(1);
                    textBox_mfg.Text = reader.GetString(3);
                    textBox_exp.Text = reader.GetString(4).ToString();
                    textBoxquan.Text = reader.GetString(5);
                }
                else
                {
                    textBox_gen.Text ="";
                    textBox_brand.Text ="";
                    textBox_mfg.Text ="";
                    textBox_exp.Text ="";
                    textBoxquan.Text ="";
                }
                
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userprofile frm = new userprofile();
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userprofile frm = new userprofile();
            frm.ShowDialog();
        }

        private void changeUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            password frm = new password();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            password frm = new password();
            frm.ShowDialog();
        }
    }
}
