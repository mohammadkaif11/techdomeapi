using System.ComponentModel.DataAnnotations;

namespace Api1.Models
{
    public class Note
    {
        [Key]
        public int id { get; set; }
        public string Tittle { get; set; }
        public string description { get; set; } 

            
    }
}
