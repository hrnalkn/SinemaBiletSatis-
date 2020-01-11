using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaBiletSatışOdevi
{
    class Salon
    {
        public List<bool> salon = new List<bool>();
        public List<List<bool>> salonlar = new List<List<bool>>();

        private string salonAdı;
        private int koltukAdeti;

        public string SalonAdı 
        { 
            get { return salonAdı; }   
            set { salonAdı = value; } 
        }
        public int KoltukAdeti 
        { 
            get { return koltukAdeti; } 
            set { koltukAdeti = value; } 
        }      
        public void SalonOlustur(string salonAdı, int koltukAdedi)
        {
            this.salonAdı = salonAdı;
            this.koltukAdeti = koltukAdedi;           
            this.salon = new List<bool>(koltukAdeti);
            for (int i = 0; i < koltukAdeti; i++)
            {
                salon.Add(true);
            }
            salonlar.Add(salon);
        }
        public void Satis(int salonIndex, int koltukIndex)
        {
            salon = salonlar[salonIndex];
            salon[koltukIndex] = false;
        }
        public void İptal(int salonIndex, int koltukIndex)
        {
            salon = salonlar[salonIndex];
            salon[koltukIndex] = true;
        }



    }
}
