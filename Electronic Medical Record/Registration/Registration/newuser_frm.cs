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
    public partial class newuser_frm : Form
    {
        public newuser_frm()
        {
            InitializeComponent();
        }

        string str = "Data Source=C:\\Users\\SONY\\Desktop\\Visual Studio\\Registration\\Registration\\USERS.sdf;Encrypt Database=True;Password=root@143;";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text=="")
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
                    if (reader.GetString(0) == textBox1.Text)
                    {
                        x++;
                        MessageBox.Show("This username already exist. Please try another.");
                        break;
                    }
                }
                if (x == 0) // if the user not exist
                {
                    if (textBox2.Text == textBox3.Text)
                    {

                        string ins = "INSERT INTO Accounts(username,password,emailid) VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','"+this.textBox4.Text+"')";
                        SqlCeCommand cm = new SqlCeCommand(ins, conn);
                        cm.ExecuteNonQuery();
                        this.Hide();
                        MessageBox.Show("Account created successfully");
                    }
                    else
                    {
                        MessageBox.Show("Password Mismatch");
                    }

                }
            }


        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Please enter the fields Properly.");
            else
            {
                if (textBox2.Text == textBox3.Text)
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
                            DialogResult dialog = MessageBox.Show("Do you really want to delete this user ?","Delete User",MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.Yes)
                            {
                                string del = "DELETE FROM Accounts WHERE username='" + this.textBox1.Text + "'";
                                SqlCeCommand d = new SqlCeCommand(del, conn);
                                d.ExecuteNonQuery();
                                this.Hide();
                                MessageBox.Show("User deleted successfully");
                            }
                            else
                            {
                                this.Hide();
                            }
                            x++;
                            break;
                        }
                    }
                    if (x == 0)
                    {
                        MessageBox.Show("User not exist or Password mismatch");
                    }
                }
                else
                {
                    MessageBox.Show("Password mismatch");
                }
                
            }
        }
    }
}
