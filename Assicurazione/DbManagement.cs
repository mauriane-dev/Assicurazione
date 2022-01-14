using Assicurazione.Models;
using Assicurazione.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione
{
    internal class DbManagement
    {
        internal static void StampaCollection<T>(ICollection<T> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("Lista vuota");
                return;
            }
            foreach (var c in collection)
            {
                Console.WriteLine(c);
            }
        }
    }
}


