using Assicurazione.Models;
using Assicurazione.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione
{
    internal class Menu
    {
        static IRepositoryClient rc = new RepositoryClient();
        static IRepositoryPolicy rp = new RepositoryPolicy();

        internal static void Start()
        {
            bool exit = true;

            do
            {
                Console.WriteLine("**** Menu ****" +
                    "\n[1] Inserire nuovi clienti" +
                    "\n[2] Inserire una polizza" +
                    "\n[3] Stampare tutte le polizze" +
                    "\n[4] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        //Metodo per inserire un nuovo cliente
                        AddCliente();
                        break;

                    case '2':
                        AddPolizza();
                        break;

                    case '3':
                        StampaPolizze();
                        break;

                    case '4':
                        exit = false;
                        Console.WriteLine("Arrivederci!");
                        break;

                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (exit);
        }


        private static void StampaPolizze()
        {
            var polizze = rp.GetAll();
            DbManagement.StampaCollection<Policy>(polizze);
        }

        private static void AddCliente()
        {
            string codice = GetInfo("il Codice Fiscale");
            string nome = GetInfo("il Nome");
            string cognome = GetInfo("il Cognome");
            string indirizzo = GetInfo("il Indirizzo");
            
            var clienteCreato = rc.Create( new Client()
            {
                    CF = codice,
                    FirstName = nome,
                    LastName = cognome,
                    Address = indirizzo
            });

            if (clienteCreato != null)
            {
                Console.WriteLine("Cliente Creato:  ");
                Console.WriteLine(clienteCreato);
            }
            else
            {
                Console.WriteLine("Operazione non riuscita");
            }


        }

        private static void AddPolizza() 
        {
            Policy policy = new Policy();

            int numero = GetNumber("il numero di polizza");
            //Console.Write("Data di nascita (dd/mm/yyyy)");
            DateTime dataStipula = GetData();
            decimal importo = GetPrice("l'importo assicurativo");
            decimal rata = GetPrice("la rata mensile");

            var clienti = rc.GetAll();
            foreach (var cliente in clienti)
            {
                Console.WriteLine(cliente);
            }

            string codice = GetInfo("il codice fiscale di un cliente");
            //controllo se esiste un reparto con quell'id/numero
            var clienteEsistente = rc.GetByCode(codice);
            if (clienteEsistente == null)
            {
                Console.WriteLine("Cliente inesistente");
            }
            else
            {
                Console.WriteLine("Che tipo di polizza vuoi inserire? 1-RCAuto 2-Furto 3-Vita");
                int tipoPolizza = GetNumber("il tipo di polizza da aggiungere:" +
                                            "\n[1] RCAuto" +
                                            "\n[2] Furto" +
                                            "\n[3] Vita");

                //bool verifica = Int32.TryParse(Console.ReadLine(), out tipoProdotto);
                while (tipoPolizza > 3 || tipoPolizza < 0)
                {
                    Console.WriteLine("Inserisci un valore corretto");
                }

                if (tipoPolizza == 1)
                {
                    string targa = GetInfo("la targa");

                    while (targa.Length > 5)
                    {
                        Console.WriteLine("Inserisci una targa corretta");
                    }

                    int cilindrata = GetNumber("la cilindrata");

                    policy = new RCCar()
                    {
                        PolicyNumber = numero,
                        StipulationDate = dataStipula,
                        InsuranceAmount = importo,
                        MonthlyPayment = rata,
                        LicensePlate = targa,
                        Displacement = cilindrata,
                        CF = codice
                    };
                }
                else if (tipoPolizza == 2)
                {
                    int coperta = GetNumber("la percentuale coperta");

                    policy = new Robbery()
                    {
                        PolicyNumber = numero,
                        StipulationDate = dataStipula,
                        InsuranceAmount = importo,
                        MonthlyPayment = rata,
                        CoveredPercentage = coperta,
                        CF = codice
                    };
                }
                else if (tipoPolizza == 3)
                {
                    int anno = GetNumber("l'anno assicurato");

                    policy = new Life()
                    {
                        PolicyNumber = numero,
                        StipulationDate = dataStipula,
                        InsuranceAmount = importo,
                        MonthlyPayment = rata,
                        InsuredYears = anno,
                        CF = codice
                    };
                }
                rp.Create(policy);
                Console.WriteLine("Polizza aggiunta !!!");
            }
        }

        //Metodi per recuperare l'input utente
        private static string GetInfo(string message)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci {message}: ");
                info = Console.ReadLine();

            } while (string.IsNullOrEmpty(info));

            return info;
        }
 
        private static decimal GetPrice(string message)
        {
            decimal prezzo = 0;
            do
            {
                Console.WriteLine($"Inserire {message}: ");
            } while (!decimal.TryParse(Console.ReadLine(), out prezzo));

            return prezzo;
        }

        private static int GetNumber(string message)
        {
            int numero = 0;
            do
            {
                Console.WriteLine($"Inserire {message}: ");
            } while (!Int32.TryParse(Console.ReadLine(), out numero));

            return numero;
        }

        private static DateTime GetData()
        {
            DateTime date;

            Console.WriteLine("Inserire la data di stipula: ");
            while (!DateTime.TryParse(Console.ReadLine(), out date) || date > DateTime.Today)
            {
                Console.WriteLine("Hai inserito un formato scorretto di data o una data precedente a oggi!");
            }

            return date;
        }


    }
}
