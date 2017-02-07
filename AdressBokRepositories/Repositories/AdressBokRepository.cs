using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdressBokRepositories.IRpositories;
using AdressBokRepositories.Models;

namespace AdressBokRepositories.Repositories
{
   public class AdressBokRepository:IAdressBokRepository
    {
        public static IList<AdressBok> Adressboks { get; private set; } = new List<AdressBok>();

       public AdressBokRepository()
       {
           if (!Adressboks.Any())
           {
                SetupTemporaryData();
            }
       }
        public IEnumerable<AdressBok> All()
       {
            return Adressboks.ToList();
        }

       public void Add(AdressBok ab)
       {
            Adressboks.Add(ab);
        }

       public void Remove(Guid id)
       {
            var AB = Adressboks.FirstOrDefault(x => x.Id == id);
            Adressboks.Remove(AB);
        }

        private void SetupTemporaryData()
        {
            Adressboks = new List<AdressBok>
            {

             new AdressBok {Id=Guid.NewGuid(), Name ="Bok01",Telefonnummer=012345678,Adress="Gata Ett" ,UpdateAd=DateTime.UtcNow },
             new AdressBok {Id=Guid.NewGuid(), Name="Bok02",Telefonnummer=012345678,Adress="Gata två" ,UpdateAd=DateTime.UtcNow },
             new AdressBok {Id=Guid.NewGuid(), Name="Bok03",Telefonnummer=012345678,Adress="Gata tre" ,UpdateAd=DateTime.UtcNow },
             new AdressBok {Id=Guid.NewGuid(), Name="Bok04",Telefonnummer=012345678,Adress="Gata fyra",UpdateAd=DateTime.UtcNow  },
             new AdressBok {Id=Guid.NewGuid(), Name="Bok05",Telefonnummer=012345678,Adress="Gata fem" ,UpdateAd=DateTime.UtcNow }
               };

        }
    }
}
