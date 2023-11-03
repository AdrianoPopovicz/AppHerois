namespace AppHerois.Models
{
    public class SuperPoderesModel
    {
        public SuperPoderesModel() { 
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string SuperPoder { get; set; }
        public string Descricao { get; set; }
    }
}
