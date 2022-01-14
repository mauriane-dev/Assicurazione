using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class Policy
    {
        [Key]
        public int PolicyNumber { get; set; }
        public DateTime StipulationDate { get; set; }
        public decimal InsuranceAmount { get; set; }
        public decimal MonthlyPayment { get; set; }

        //Foreign Key
        public string? CF { get; set; }
        public Client Client { get; set; }  //Navigation property

        public override string ToString()
        {
            return $"{PolicyNumber} - DataStipula: {StipulationDate} - " +
                   $"ImportoAssicurativo: {InsuranceAmount} - RataMensile: {MonthlyPayment} - " +
                   $"Client - {Client}";
        }
    }
}
