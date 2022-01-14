using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class Client
    {
        [Key]
        [MinLength(16), MaxLength(16)]
        public string? CF { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Address { get; set; }
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();

        public override string ToString()
        {
            return $"{CF} - {FirstName} - {LastName} - {Address}";
        }
    }
}
