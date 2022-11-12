using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Bagaz
    {
        [Key]
        public int id_bagazu { get; set; }
        public float waga { get; set; }
    }
}
