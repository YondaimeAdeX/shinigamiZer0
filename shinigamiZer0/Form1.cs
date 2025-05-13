using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shinigamiZer0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        dbKutuphaneEntities db = new dbKutuphaneEntities();

        private void Doldur() {

            var tur = db.TblTurler.Select(x => new
            {
                id = x.id,
                tur = x.turAdi

            }).ToList();
            cmbtur.DataSource = tur;
            cmbtur.DisplayMember = "tur";
            cmbtur.ValueMember = "id";
            dataGridView1.DataSource = tur;

            var yazar = db.TblYazarlar.Select(x => new
            {
                id = x.id,
                yazar = x.yazarAdi
            }).ToList();
            cmbyazar.DataSource = yazar;
            cmbyazar.DisplayMember = "yazar";
            cmbyazar.ValueMember = "id";
            dataGridView2.DataSource = yazar;

            var kitap = db.TblKitaplar.Select(x => new
            {
                x.id,
                x.kitapAdi,
                x.TblTurler.turAdi,
                x.TblYazarlar.yazarAdi,
                x.sayfaSayisi
            }).ToList();
            dataGridView3.DataSource = kitap;
        
        
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TblTurler tur = new TblTurler();
            tur.turAdi = txturadi.Text;
            db.TblTurler.Add(tur);
            db.SaveChanges();
            Doldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
        }
        int turid,yazarid,kitapid;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            turid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var tur = db.TblTurler.Where(x => x.id == turid).FirstOrDefault();
            txturadi.Text = tur.turAdi;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.TblTurler where x.id == turid select x).FirstOrDefault();
            guncelle.turAdi = txturadi.Text;
            db.SaveChanges();
            Doldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TblYazarlar yazar = new TblYazarlar();
            yazar.yazarAdi = txtyazaradi.Text;
            db.TblYazarlar.Add(yazar);
            db.SaveChanges();
            Doldur();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            yazarid = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            var yazar = db.TblYazarlar.Where(x => x.id == yazarid).FirstOrDefault();
            txtyazaradi.Text = yazar.yazarAdi;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TblKitaplar kitap = new TblKitaplar();
            kitap.kitapAdi = txtkitapadi.Text;
            kitap.turu = int.Parse(cmbtur.SelectedValue.ToString());
            kitap.yazari = int.Parse(cmbyazar.SelectedValue.ToString());
            kitap.sayfaSayisi = txtsayfasayisi.Text;
            db.TblKitaplar.Add(kitap);
            db.SaveChanges();
            Doldur();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var sil = (from x in db.TblKitaplar where x.id == kitapid select x).FirstOrDefault();
            db.TblKitaplar.Remove(sil);
            db.SaveChanges();
            Doldur();
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            kitapid = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            var kitap = db.TblKitaplar.Where(x => x.id == kitapid).FirstOrDefault();
            txtkitapadi.Text = kitap.kitapAdi;
            txtsayfasayisi.Text = kitap.sayfaSayisi;
            cmbtur.Text = kitap.TblTurler.turAdi;
            cmbyazar.Text = kitap.TblYazarlar.yazarAdi;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var ara = from x in db.TblKitaplar
                      where x.kitapAdi.Contains(textBox1.Text)
                      select new
                      {
                          x.id,
                          x.kitapAdi,
                          x.TblTurler.turAdi,
                          x.TblYazarlar.yazarAdi,
                          x.sayfaSayisi


                      };
            dataGridView3.DataSource = ara.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.TblKitaplar where x.id == kitapid select x).FirstOrDefault();
            guncelle.kitapAdi = txtkitapadi.Text;
            guncelle.turu = int.Parse(cmbtur.SelectedValue.ToString());
            guncelle.yazari = int.Parse(cmbyazar.SelectedValue.ToString());
            guncelle.sayfaSayisi = txtsayfasayisi.Text;
            db.SaveChanges();
            Doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.TblYazarlar where x.id == yazarid select x).FirstOrDefault();
            guncelle.yazarAdi = txtyazaradi.Text;
            db.SaveChanges();
            Doldur();
        }
    }
}
