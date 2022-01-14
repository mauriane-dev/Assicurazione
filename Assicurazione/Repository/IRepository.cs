using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Repository
{
    internal interface IRepository<T>
    {
        public ICollection<T> GetAll();
        public T? Create(T item);
    }
}
