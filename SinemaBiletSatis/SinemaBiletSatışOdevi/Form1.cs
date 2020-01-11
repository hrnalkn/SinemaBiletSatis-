using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaBiletSatışOdevi
{
    public partial class Form1 : Form
    {       
        int ToplamUcret = 0;
        int kolaSayac = 0;
        int suSayac=0;
        int mısırSayac = 0;
        int marketToplam = 0;
        int Zraporu = 0;
              
        public Form1()
        {
            InitializeComponent();
            panel1.Visible= false;
            textBox3.Text = mısırSayac.ToString();
            textBox4.Text = kolaSayac.ToString(); ;
            textBox5.Text = suSayac.ToString();
            panel2.Visible = false;
            panel1.Visible = false;

            

        }
        Salon salon = new Salon();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string salonNo = textBox1.Text;
                if (int.Parse(textBox2.Text) < 100 && int.Parse(textBox2.Text) > 10)
                {
                    int koltukAdet = int.Parse(textBox2.Text);
                    salon.SalonOlustur(salonNo, koltukAdet);
                    comboBox1.Items.Add(salon.SalonAdı);
                    MessageBox.Show($"{salon.SalonAdı.ToUpper()} Adlı salon, {salon.KoltukAdeti} Adet koltuk ile başarılı bir şekilde oluşturuldu.");
                }
                else
                {
                    MessageBox.Show($"En fazla 100 kişi ve en az 10 kişilik bir salon oluşturulabilir !!! \nYeni bir salon oluşturmayı deneyin!!!");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen girilen bilgileri kontrol edin ! ","HATA!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           

        }

        private void B_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            string koltukNo = b.Text;
            if (  (sender as Button).BackColor == Color.Red)
            {
               
                if (ToplamUcret>0 || (sender as Button).BackColor == Color.Red)
                {                    
                    (sender as Button).BackColor = Color.Green;
                    MessageBox.Show($"{comboBox1.SelectedItem.ToString().ToUpper()} isimli Salondan {(sender as Button).Text} numaralı koltuk için satış işlemi iptal edildi");
                    salon.İptal(comboBox1.SelectedIndex, int.Parse(b.Text) - 1);
                    if (checkBox1.Checked == false)
                    {

                        ToplamUcret += 15;
                        Zraporu += 15;
                    }
                    else
                    {
                        ToplamUcret += 12;
                        Zraporu += 12;

                    }
                }
               
            }
            else
            {

                (sender as Button).BackColor = Color.Red;
                MessageBox.Show($"{comboBox1.SelectedItem.ToString().ToUpper()} isimli Salondan {(sender as Button).Text} numaralı koltuk için bilet satıldı.");
                salon.Satis(comboBox1.SelectedIndex, int.Parse(b.Text) - 1);
                if (checkBox1.Checked == false)
                {

                    ToplamUcret += 15;
                    Zraporu += 15;
                }
                else
                {
                    ToplamUcret += 12;
                    Zraporu += 12;
                
                }
                
            }
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
                       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            int i = 0;
            foreach (var item in salon.salonlar[comboBox1.SelectedIndex])
            {
                Button b = new Button();
                panel1.Visible = true;
                b.Text = (i + 1).ToString();
                b.Width = 50;
                b.Height = 50;
                b.Name = (i + 1).ToString();
                if (item)
                {
                    b.BackColor = Color.Green;                
                }
                else if (!item)
                {
                    b.BackColor = Color.Red;
                }
                flowLayoutPanel1.Controls.Add(b);
                b.Click += B_Click;
                i++;
            }

        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            Zraporu = Zraporu+marketToplam;
            MessageBox.Show($"Toplam hesabınız {ToplamUcret+marketToplam} TL dir. İyi Seyirler Dileriz...");         
            ToplamUcret = 0;
            marketToplam = 0;
            kolaSayac = 0;
            mısırSayac = 0;
            suSayac = 0;
            textBox3.Text = mısırSayac.ToString();
            textBox4.Text = kolaSayac.ToString(); ;
            textBox5.Text = suSayac.ToString();
            panel2.Visible = false;
            panel1.Visible = false;

        }

        

        private void button6_Click(object sender, EventArgs e)
        {

            mısırSayac += 1;
            textBox3.Text = $"{mısırSayac}";
            marketToplam += 5;
            label12.Text = $"{marketToplam.ToString()} TL"; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mısırSayac>0)
            {
                mısırSayac -= 1;
                textBox3.Text = $"{mısırSayac}";
                marketToplam -= 5;
                label12.Text = $"{marketToplam.ToString()} TL";
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            kolaSayac += 1;
            textBox4.Text = $"{kolaSayac}";
            marketToplam += 5;
            label12.Text = $"{marketToplam.ToString()} TL";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (kolaSayac>0)
            {            
            kolaSayac -= 1;
            textBox4.Text = $"{kolaSayac}";
            marketToplam -= 5;
            label12.Text = $"{marketToplam.ToString()} TL";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            suSayac += 1;
            textBox5.Text = $"{suSayac}";
            marketToplam += 2;
            label12.Text = $"{marketToplam.ToString()} TL";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (suSayac > 0)
            {
                suSayac -= 1;
                textBox5.Text = $"{suSayac}";
                marketToplam -= 2;
                label12.Text = $"{marketToplam.ToString()} TL";
            }
        }

        private void maketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Günün Toplam Hasılatı={Zraporu} TL");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
