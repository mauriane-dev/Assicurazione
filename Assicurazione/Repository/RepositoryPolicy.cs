using Assicurazione.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Repository
{
    internal class RepositoryPolicy : IRepositoryPolicy
    {
        public Policy? Create(Policy p)
        {
            using (var ctx = new Context())
            {
                ctx.Policies.Add(p);
                ctx.SaveChanges();
            }

            return p;
        }

        public ICollection<Policy> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Policies.Include(p => p.Client).ToList();
            }
        }

        public Policy? GetByNumber(int number)
        {
            return GetAll().FirstOrDefault(p => p.PolicyNumber == number);
        }
    }
}
