using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProject
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OkulProjectDBEntities ef = new OkulProjectDBEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ogrenci yeniOgr = new Ogrenci();

            yeniOgr.ogrenciNo = txtOgrNo.Text;
            yeniOgr.adSoyad = txtAdSoyad.Text;
            yeniOgr.Adres = txtAdres.Text;

            ef.Ogrenci.Add(yeniOgr);
            ef.SaveChanges();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ef.Ogrenci.ToList();
            foreach(var item in ef.Ogrenci.ToList())
            {
                cmbxOgrNo.Items.Add(item.ogrenciNo);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string ogrNo;
            ogrNo = cmbxOgrNo.SelectedItem.ToString();
            var guncellenecek = ef.Ogrenci.Where(x => x.ogrenciNo == ogrNo).FirstOrDefault();

            guncellenecek.adSoyad = txtAdSoyad.Text;
            guncellenecek.Adres = txtAdres.Text;

            ef.SaveChanges();
            dataGridView1.DataSource = ef.Ogrenci.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string ogrNo;
            ogrNo = cmbxOgrNo.SelectedItem.ToString();
            var silinecek = ef.Ogrenci.Where(x => x.ogrenciNo == ogrNo).FirstOrDefault();
        }
    }
}
