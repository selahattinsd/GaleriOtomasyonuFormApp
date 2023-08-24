using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleriOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DB_GaleriEntities Baglantı = new DB_GaleriEntities();
        private void bt1_Click(object sender, EventArgs e)
        {
            Goruntuleme();
            txt1.Visible = false;
            lbl1.Visible = false;
        }
        public void Goruntuleme()
        {
            dataGridView1.DataSource = Baglantı.Araclars.ToList();
        }
      
        private void btn2_Click(object sender, EventArgs e)
        {
            Araclar save = new Araclar();
            save.AracFiyat = Convert.ToDecimal(txt2.Text);
            save.Marka = txt4.Text;
            save.Adet = Convert.ToInt32(txt3.Text);
            save.Model = txt5.Text;
            Baglantı.Araclars.Add(save);
            Baglantı.SaveChanges();
            Goruntuleme();

            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txt1.Text = satır.Cells["AracNo"].Value.ToString();
            txt2.Text = satır.Cells["AracFiyat"].Value.ToString();
            txt3.Text = satır.Cells["Adet"].Value.ToString();
            txt4.Text = satır.Cells["Marka"].Value.ToString();
            txt5.Text = satır.Cells["Model"].Value.ToString();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(txt1.Text);
            var update = Baglantı.Araclars.Where(x => x.AracNo == no).FirstOrDefault();
            update.AracFiyat = Convert.ToDecimal(txt2.Text);
            update.Marka = txt4.Text;
            update.Adet = Convert.ToInt32(txt3.Text);
            update.Model = txt5.Text;
            Baglantı.SaveChanges();
            Goruntuleme();
            
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(txt1.Text);
            var delete = Baglantı.Araclars.Where(a=>a.AracNo ==no).FirstOrDefault();
            Baglantı.Araclars.Remove(delete);
            Baglantı.SaveChanges();
            Goruntuleme();
        }
    }
}
