using Assicurazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Repository
{
    internal class RepositoryClient : IRepositoryClient
    {
        public Client? Create(Client c)
        {
            using (var ctx = new Context())
            {
                ctx.Clients.Add(c);
                ctx.SaveChanges();
            }

            return c;
        }

        public ICollection<Client> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Clients.ToList();
            }
        }

        public Client? GetByCode(string codice)
        {
            return GetAll().FirstOrDefault(d => d.CF == codice);
        }

    }
}
