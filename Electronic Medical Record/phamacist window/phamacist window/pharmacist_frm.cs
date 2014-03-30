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
                string tab = textBox_generic.Text + "_" + textBox_type.Text;

                string str = "Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medicines;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string query = "SELECT * FROM INFORMATION_SCHEMA.tables";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int x = 0;
                while (reader.Read())
                {
                    if (reader.GetString(2) == tab) 
                    {
                        x++;
                        break;
                    }
                }
                reader.Close();
                if (x == 0)  // if the table is not present
                {
                    try
                    {
                        // create the table
                        string tabquery = "CREATE TABLE " + tab + "(manufacturer varchar(50),batchnum varchar(50),expdate varchar(50),purchasingdate varchar(50),quantity int,invoice varchar(50))";
                        cmd = new SqlCommand(tabquery, conn);
                        cmd.ExecuteNonQuery();
                        
                        //insert the value
                        string ins = "INSERT INTO " + tab + "(manufacturer,batchnum,expdate,purchasingdate,quantity,invoice)VALUES('" + textBox_manufact.Text + "','" + textBox_batch.Text + "','" + dateTimePicker_exp.Text + "','" + dateTimePicker1.Text + "','" + textBox_quan.Text + "','" + textBox_invoice.Text + "')";
                        cmd = new SqlCommand(ins, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data insertes successfully");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (x > 0) // if the table is present
                {
                    try
                    {
                        //insert the value
                        string ins = "INSERT INTO " + tab + "(manufacturer,batchnum,expdate,purchasingdate,quantity,invoice)VALUES('" + textBox_manufact.Text + "','" + textBox_batch.Text + "','" + dateTimePicker_exp.Text + "','" + dateTimePicker1.Text + "','" + textBox_quan.Text + "','" + textBox_invoice.Text + "')";
                        cmd= new SqlCommand(ins, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data insertes successfully");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                conn.Close();
            }
            catch(Exception ex)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage_medicine_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void View_Stock_Click(object sender, EventArgs e)
        {
            Stock frm = new Stock();
            frm.ShowDialog();
        }
    }
}
