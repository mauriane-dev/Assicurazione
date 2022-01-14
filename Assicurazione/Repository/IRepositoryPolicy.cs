using Assicurazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Repository
{
    internal interface IRepositoryPolicy : IRepository<Policy>
    {
        public Policy? GetByNumber(int number);
    }
}
