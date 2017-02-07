using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AdressBokRepositories.Models;

namespace AdressBokRepositories.IRpositories
{
    public interface IAdressBokRepository
    {
        IEnumerable<AdressBok> All();
        void Add(AdressBok ab);
        void Remove(Guid id);
    }
}
