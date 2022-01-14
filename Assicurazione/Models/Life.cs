using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class Life : Policy
    {
        public int InsuredYears { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" AnniAssicurato: {InsuredYears}";
        }
    }
}
