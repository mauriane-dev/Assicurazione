using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class Robbery : Policy
    {
        public int CoveredPercentage { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" PercentualeCoperta: {CoveredPercentage}";
        }
    }
}
