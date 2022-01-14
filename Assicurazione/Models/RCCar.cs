using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class RCCar : Policy
    {
        [MaxLength(5)]
        public string? LicensePlate { get; set; }
        public int Displacement { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Targa: {LicensePlate} - Cilindrata: {Displacement}";
        }
    }
}
