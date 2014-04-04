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
    public partial class password : Form
    {
        public password()
        {
            InitializeComponent();
        }

        string str = "Data Source=C:\\Users\\SONY\\Desktop\\Visual Studio\\Registration\\Registration\\USERS.sdf;Encrypt Database=True;Password=root@143;";
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Please enter the fields Properly.");
            else
            {
     
                    SqlCeConnection conn = new SqlCeConnection(str);
                    conn.Open();
                    string query = "SELECT * FROM Accounts";
                    SqlCeCommand cmd = new SqlCeCommand(query, conn);
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    int x = 0;
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == textBox1.Text && reader.GetString(1) == textBox2.Text)
                        {
                            string upd = "UPDATE Accounts SET password='"+this.textBox3.Text+"' WHERE username='" + this.textBox1.Text + "'";
                            SqlCeCommand up = new SqlCeCommand(upd, conn);
                            up.ExecuteNonQuery();
                             
                            this.Hide();
                            MessageBox.Show("Passwor Changed successfully");
                            
                            x++;
                            break;
                        }
                    }
                    if (x == 0)
                    {
                        MessageBox.Show("User not exist or Password mismatch");
                    }
            }
        }
    }
}
