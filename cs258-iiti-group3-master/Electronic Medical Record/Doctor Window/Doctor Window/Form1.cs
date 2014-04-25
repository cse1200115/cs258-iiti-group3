using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Doctor_Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Data Source=C:\\Users\\SONY\\Desktop\\Visual Studio\\Doctor Window\\Doctor Window\\USERS.sdf;Encrypt Database=True;Password=root@143;";
                SqlCeConnection conn = new SqlCeConnection(str);

                string query = "SELECT *FROM Accounts";
                SqlCeCommand cmd = new SqlCeCommand(query, conn);

                conn.Open();
                SqlCeDataReader reader = cmd.ExecuteReader();
                int x = 0;
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string pwd = reader.GetString(1);
                    if (id == textBox1.Text && pwd ==textBox2.Text)
                    {
                        this.Hide();
                        x++;
                        Doctor_frm df = new Doctor_frm();
                        df.ShowDialog();
                        break;
                    }
                }
                if (x == 0)
                    MessageBox.Show("Invalid User");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           
        }
    }
}
