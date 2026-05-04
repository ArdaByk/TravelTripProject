using System.ComponentModel.DataAnnotations;

namespace TravelTripProject.Models.Siniflar;

public class BlogResim
{
    [Key]
    public int ID { get; set; }
    public string ImageUrl { get; set; }
    public int BlogID { get; set; }
    public virtual Blog Blog { get; set; }
}
