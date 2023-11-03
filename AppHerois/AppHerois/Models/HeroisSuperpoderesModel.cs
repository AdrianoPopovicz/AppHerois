using System.ComponentModel.DataAnnotations;

namespace AppHerois.Models
{
    public class HeroisSuperpoderesModel
    {
        public HeroisSuperpoderesModel() { 
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string HeroiId { get; set; }
        public string SuperpoderId { get; set;}
    }
}
