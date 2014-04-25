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
            queue();
            autocomplete();
            
        }
        string curr_listbox_item = "";
        string tab="";
        string str="Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medical_Records;Integrated Security=True";

        private void queue()
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM Pt_transfered_to_pharmacist";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    listBox1.Items.Add(id);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void autocomplete()
        {
            try
            {

                AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
                AutoCompleteStringCollection medcoll = new AutoCompleteStringCollection();

                string str = "Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medicines;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string query = "SELECT * FROM INFORMATION_SCHEMA.tables";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string medicine = reader.GetString(2);
                    coll.Add(medicine);

                    string[] med = medicine.Split('_');
                    medcoll.Add(med[0]);
                    
                }
                conn.Close();

                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = coll;

                textBox_generic.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox_generic.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox_generic.AutoCompleteCustomSource = medcoll;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void autofill()
        {
            try
            {

                AutoCompleteStringCollection medcoll = new AutoCompleteStringCollection();

                string str = "Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medicines;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string query = "SELECT * FROM INFORMATION_SCHEMA.tables";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string medicine = reader.GetString(2);
                    string[] med = medicine.Split('_');
                    if (med[0] == textBox_generic.Text)
                    {
                        medcoll.Add(med[1]);
                    }
                    
                }
                conn.Close();
                textBox_type.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox_type.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox_type.AutoCompleteCustomSource = medcoll;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
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
            try
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {

                    if (dataGridView3[dataGridView3.Columns.Count - 1, i].Value != null)
                    {
                        
                        long x =Convert.ToInt64(dataGridView3[dataGridView3.Columns.Count - 2, i].Value) - Convert.ToInt64(dataGridView3[dataGridView3.Columns.Count - 1, i].Value);
                       
                        if (x >= 0)
                        {
                            
                            string str = "Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medicines;Integrated Security=True";
                            SqlConnection conn = new SqlConnection(str);
                            conn.Open();
                            string query = "UPDATE " + tab + " SET quantity= " + x.ToString() + " WHERE batchnum= " + dataGridView3[1, i].Value.ToString() + "";
                            SqlCommand cmd = new SqlCommand(query,conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Item issued");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Out of Stock");
                        }

                     
                    }
                    
                    
                }
                IssueMedicine();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void View_Stock_Click(object sender, EventArgs e)
        {
            Stock frm = new Stock();
            frm.ShowDialog();
                
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            curr_listbox_item = listBox1.SelectedItem.ToString();
             try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT TOP 1* FROM "+curr_listbox_item+" ORDER BY Date_Time ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                while(reader.Read())
                {
                   
                   string[] med = reader.GetString(5).Split(',');
                   string[] dos = reader.GetString(6).Split(',');
                   string[] freq = reader.GetString(7).Split(',');
                   for (int i = 0; i < med.Length-1; i++)
                       dataGridView1.Rows.Add((i+1).ToString(),med[i], dos[i], freq[i]);
                }
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        void IssueMedicine()
        {
            try
            {
                tab = textBox1.Text;
                dataGridView3.Rows.Clear();

                string str = "Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medicines;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string query = "SELECT * FROM INFORMATION_SCHEMA.tables";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(2) == tab)
                    {
                        SqlConnection tabcon = new SqlConnection(str);
                        tabcon.Open();
                        string tabquery = "SELECT * FROM " + tab + "";
                        SqlCommand tabcmd = new SqlCommand(tabquery, tabcon);
                        SqlDataReader tabreader = tabcmd.ExecuteReader();


                        while (tabreader.Read())
                        {

                            dataGridView3.Rows.Add(tabreader.GetString(0), tabreader.GetString(1), tabreader.GetString(2), tabreader.GetInt32(4).ToString());
                        }
                        break;
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IssueMedicine();
        }

        private void tabPage_medicine_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Please save the medicine issued before leaving this tab.");
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_generic_TextChanged(object sender, EventArgs e)
        {
            textBox_type.Clear();
            autofill();
        }
    }
}

