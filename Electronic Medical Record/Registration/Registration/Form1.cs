using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Registration
{
    public partial class Login_frm : Form
    {
        public Login_frm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                string str = "Data Source=C:\\Users\\SONY\\Desktop\\Visual Studio\\Registration\\Registration\\USERS.sdf;Encrypt Database=True;Password=root@143;";
                SqlCeConnection conn = new SqlCeConnection(str);

                string query = "SELECT *FROM Accounts";
                SqlCeCommand cmd = new SqlCeCommand(query,conn);

                conn.Open();       
                SqlCeDataReader reader = cmd.ExecuteReader();
                int x = 0;
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string pwd = reader.GetString(1);
                    if (id == text_user.Text && pwd == text_pass.Text)
                    {
                        this.Hide();
                        x++;
                        Reception_frm rf = new Reception_frm();
                        rf.ShowDialog();
                        break;
                    }
                }
                if (x == 0)
                    MessageBox.Show("Invalid User");
                conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        private void psd_button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
