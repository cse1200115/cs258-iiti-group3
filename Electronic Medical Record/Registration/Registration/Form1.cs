using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            this.Hide();

            Reception_frm rf = new Reception_frm();
            rf.ShowDialog();
        }
    }
}
