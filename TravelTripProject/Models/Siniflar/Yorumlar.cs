using System;
using System.Collections.Generic;
using System.Text;

namespace TravelTripProject.Models.Siniflar;

public class Yorumlar
{
    public int ID { get; set; }
    public string KullaniciAdi { get; set; }
    public string Mail { get; set; }
    public string Yorum { get; set; }
    public Blog Blog { get; set; }
}
