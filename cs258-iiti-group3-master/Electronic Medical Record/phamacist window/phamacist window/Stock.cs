using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace phamacist_window
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            stock();
        }

        void stock()
        {
            try
            {

                string str = "Data Source=VAIO\\SQLEXPRESS;Initial Catalog=Medicines;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string query = "SELECT * FROM INFORMATION_SCHEMA.tables";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tab = reader.GetString(2);
                    
                    SqlConnection tabcon = new SqlConnection(str);
                    tabcon.Open();
                    string tabquery = "SELECT * FROM "+tab+"";
                    SqlCommand tabcmd = new SqlCommand(tabquery, tabcon);
                    SqlDataReader tabreader = tabcmd.ExecuteReader();

                    string[] words = tab.Split('_');
                    while (tabreader.Read())
                    {
                        
                        dataGridView2.Rows.Add(words[0], words[1], tabreader.GetString(0), tabreader.GetString(1), tabreader.GetString(3), tabreader.GetString(2), tabreader.GetString(5), tabreader.GetInt32(4).ToString());
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
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
