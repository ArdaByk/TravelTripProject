using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelTripProject.Models.Siniflar;
public class Admin
{
    public int ID { get; set; }
    public string Kullanici { get; set; }
    public string Sifre { get; set; }
}
