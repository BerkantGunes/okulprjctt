using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProject
{
    public partial class frmLogin: Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        OkulProjectDBEntities ef = new OkulProjectDBEntities();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            var liste = ef.Users.ToList();

            foreach(var item in liste)
            {
                if(item.email == txtEmail.Text && item.sifre == txtSifre.Text)
                {
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Kullanici adi veya sifre yanlis!");
                }
            }
        }
    }
}
