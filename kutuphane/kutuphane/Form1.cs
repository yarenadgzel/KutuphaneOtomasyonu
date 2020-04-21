using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
    namespace kutuphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.ACE.OleDb.12.0;Data Source =" + Application.StartupPath + "\\kutuphane.accdb");


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.ReadOnly = true;
            textBox1.Enabled = false;
            textBox7.Enabled = false;
            textBox13.Enabled = false;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
            //KİTAP EKLEME İŞLEMLERİ
        {
           
            baglantim.Open();
          
            OleDbCommand eklekomutu = new OleDbCommand("insert into kitap(kitapad,kitapyazar,baskiyili,yayınevi,stoksayı) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", baglantim);
            eklekomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanına Eklendi..", "Veri Tabanı İşlemleri");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }
        //Kayıt Silme
        private void button2_Click(object sender, EventArgs e)
        {
            baglantim.Open();

            OleDbCommand silkomutu = new OleDbCommand("delete from kitap where kitapno="+Convert.ToInt32(textBox1.Text)+"",baglantim);
            silkomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanından Silindi ..", "Veri Tabanı İşlemleri");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();


        }
      // KİTAP KAYITLARI DataGridViewda sonuçlar listelenir.

        private void button3_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbDataAdapter listele = new OleDbDataAdapter("select * from kitap ", baglantim); //Bellekte oluşturulan tablo ve kayıtların, veritabanına gönderilmesi 
                                                                                             // ya da veritabanındaki tabloların belleğe çekilmesi işlemlerini gerçekleştiren sınıftır.
            DataSet sakla = new DataSet();
            listele.Fill(sakla);
            dataGridView1.DataSource = sakla.Tables[0];
            baglantim.Close();

        }
        //GÜNCELLEME İŞLEMLERİ
        private void button4_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbCommand güncellekomutu = new OleDbCommand("update kitap set kitapad='" + textBox2.Text + "', kitapyazar= '" + textBox3.Text + "', baskiyili= " + Convert.ToInt32(textBox4.Text) + " ,yayınevi= '" + textBox5.Text + "' , stoksayı= " +Convert.ToInt32(textBox6.Text) + " where kitapno= "+Convert.ToInt32(textBox1.Text)+"", baglantim);
            güncellekomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanında Güncellendi..", "Veri Tabanı İşlemleri");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        //ÜYE GÜNCELLEME İŞLEMLERİ
        private void button14_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbCommand güncellekomutu = new OleDbCommand("update üye set uyead='" + textBox8.Text + "', uyesoyad= '" + textBox9.Text + "', telefonno= '" + textBox10.Text + "' , eposta= '" + textBox11.Text + "' , adres= '" + textBox12.Text + "' where üyeno= " +Convert.ToInt32(textBox7.Text) + "", baglantim);
            güncellekomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanında Güncellendi..", "Veri Tabanı İşlemleri");
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();

        }
        //ÜYE EKLEME İŞLEMLERİ
        private void button11_Click(object sender, EventArgs e)
        {

            baglantim.Open();

            OleDbCommand eklekomutu = new OleDbCommand("insert into üye(uyead,uyesoyad,telefonno,eposta,adres) values('" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "')", baglantim);
            eklekomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanına Eklendi..", "Veri Tabanı İşlemleri");
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();


        }
        //ÜYE KAYDI SİLME İŞLEMİ
        private void button12_Click(object sender, EventArgs e)
        {
            baglantim.Open();

            OleDbCommand silkomutu = new OleDbCommand("delete from üye where üyeno=" + Convert.ToInt32(textBox7.Text) + "", baglantim);
            silkomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanından Silindi ..", "Veri Tabanı İşlemleri");
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();


        }
        //ÜYELERİN DATAGRİDVİEWDA GÖSTERİMİ
        private void button13_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbDataAdapter listele = new OleDbDataAdapter("select * from üye ", baglantim);
            DataSet sakla = new DataSet();
            listele.Fill(sakla);
            dataGridView2.DataSource = sakla.Tables[0];
            baglantim.Close();
        }
        //EMANET KAYIT GÜNCELLEME
        private void button19_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbCommand güncellekomutu = new OleDbCommand("update ödünç set emanetno=" +Convert.ToInt32( textBox13.Text) + ", üyeno= " +Convert.ToInt32( textBox14.Text) + ", kitapno= " +Convert.ToInt32( textBox15.Text )+ " , oduncvermetarih= '" + textBox16.Text + "' , oduncteslimtarih= '" + textBox17.Text + "',teslimalındı= '"+ textBox18.Text +"' where emanetno= " + Convert.ToInt32(textBox13.Text) + "", baglantim);
            güncellekomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanında Güncellendi..", "Veri Tabanı İşlemleri");
            if(textBox18.Text=="edildi" || textBox18.Text == "Edildi")
            {
                stokartır(textBox15.Text);
                MessageBox.Show("Teslim alınan kitap stok'a eklenmiştir");
            }
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        
       
        //EMANET KAYIT EKLEME İŞLEMLERİ
        private void button16_Click(object sender, EventArgs e)
        {

            baglantim.Open();
            OleDbCommand eklekomutu = new OleDbCommand("insert into ödünç(üyeno,kitapno,oduncvermetarih,oduncteslimtarih,teslimalındı) values('" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "')", baglantim);
            eklekomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanına Eklendi..", "Veri Tabanı İşlemleri");
            stokazalt(textBox15.Text);
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            
        }
        //EMANET SİLME İŞLEMLERİ
        private void button17_Click(object sender, EventArgs e)
        {
            baglantim.Open();

            OleDbCommand silkomutu = new OleDbCommand("delete from ödünç where emanetno=" + Convert.ToInt32(textBox13.Text) + "", baglantim);
            silkomutu.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Kayıt Veri Tabanından Silindi ..", "Veri Tabanı İşlemleri");
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();

        }
        //EMANET LİSTESİNİN DATAGRİDVİEW GÖSTERİMİ
        private void button18_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbDataAdapter listele = new OleDbDataAdapter("select * from ödünç ", baglantim);
            DataSet sakla = new DataSet();
            listele.Fill(sakla);
            dataGridView3.DataSource = sakla.Tables[0];
            baglantim.Close();
        }
        //Emanet geri verilince stok sayısını artıran program
        private void stokartır(string kitapno2)
        {

            int stokSayi2 = 0;
            baglantim.Open();

            OleDbCommand cmdStokSayi2 = new OleDbCommand("select * from kitap where kitapno = " + Convert.ToInt32(kitapno2), baglantim);
            OleDbDataReader dr2 = cmdStokSayi2.ExecuteReader();
            while (dr2.Read())
            {
                stokSayi2 = Convert.ToInt32(dr2["stoksayı"]);
            }

            OleDbCommand stokguncelle = new OleDbCommand("update kitap set stoksayı = " + (stokSayi2 + 1) + " where kitapno = " + Convert.ToInt32(kitapno2), baglantim);
            stokguncelle.ExecuteNonQuery();
            baglantim.Close();

        }






        //Emanet kitap verildiğinde stok azaltan progrram
      public void stokazalt(string kitapno)
        {
            int stokSayi = 0;
            baglantim.Open();

            OleDbCommand cmdStokSayi = new OleDbCommand("select * from kitap where kitapno = " + Convert.ToInt32(kitapno), baglantim);
            OleDbDataReader dr = cmdStokSayi.ExecuteReader();
            while(dr.Read())
            {
                stokSayi = Convert.ToInt32(dr["stoksayı"]);
            }
            if (stokSayi == 0)
            {
                
                MessageBox.Show("Stok bulunamadı");
            }
            else
            {
           
                OleDbCommand stokguncelle = new OleDbCommand("update kitap set stoksayı = " + (stokSayi - 1) + " where kitapno = " + Convert.ToInt32(kitapno), baglantim);
                stokguncelle.ExecuteNonQuery();
                baglantim.Close();

            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }


        //İki kere tıklandıgında texttboxlara doluyor güncelleme işlemini kolaylastırıyor.Datagridview1 için
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["kitapno"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["kitapad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["kitapyazar"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["baskiyili"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["yayınevi"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["stoksayı"].Value.ToString();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //İki kere tıklandıgında texttboxlara doluyor güncelleme işlemini kolaylastırıyor.Datagridview2 için
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView2.CurrentRow.Cells["üyeno"].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells["uyead"].Value.ToString();
            textBox9.Text = dataGridView2.CurrentRow.Cells["uyesoyad"].Value.ToString();
            textBox10.Text = dataGridView2.CurrentRow.Cells["telefonno"].Value.ToString();
            textBox11.Text = dataGridView2.CurrentRow.Cells["eposta"].Value.ToString();
            textBox12.Text = dataGridView2.CurrentRow.Cells["adres"].Value.ToString();

        }

        //İki kere tıklandıgında texttboxlara doluyor güncelleme işlemini kolaylastırıyor.Datagridview3 için
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox13.Text = dataGridView3.CurrentRow.Cells["emanetno"].Value.ToString();
            textBox14.Text = dataGridView3.CurrentRow.Cells["üyeno"].Value.ToString();
            textBox15.Text = dataGridView3.CurrentRow.Cells["kitapno"].Value.ToString();
            textBox16.Text = dataGridView3.CurrentRow.Cells["oduncvermetarih"].Value.ToString();
            textBox17.Text = dataGridView3.CurrentRow.Cells["oduncteslimtarih"].Value.ToString();
            textBox18.Text = dataGridView3.CurrentRow.Cells["teslimalındı"].Value.ToString();
        }
    }
    }
    

