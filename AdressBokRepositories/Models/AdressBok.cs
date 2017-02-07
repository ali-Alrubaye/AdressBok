using System;

namespace AdressBokRepositories.Models
{
    public class AdressBok
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Telefonnummer { get; set; }
        public string Adress { get; set; }
        public DateTime UpdateAd { get; set; }
    }
}
