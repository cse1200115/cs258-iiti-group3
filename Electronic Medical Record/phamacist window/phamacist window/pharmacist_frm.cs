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
