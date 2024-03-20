using EntitatiAngajati;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class NivelStocareDateAngajat
    {
        static int nrAngajati = 0;
        static Angajat[] angajati = new Angajat[MAX_ANGAJATI];
         private const int MAX_ANGAJATI = 100;
        public static Angajat CitireAngajatTastatura()
        {
            Console.WriteLine("Introduceti numele angajatului:");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele angajatului:");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceti CNP-ul angajatului:");
            string cnp = Console.ReadLine();

            Console.WriteLine("Introduceti data angajarii (format: ZZ.LL.AAAA):");
            DateTime dataAngajarii;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataAngajarii))
            {
                Console.WriteLine("Data introdusă nu este în formatul corect. Vă rugăm să reintroduceți data angajării.");
                return null; // În cazul în care data nu este introdusă corect, returnăm null
            }

            Console.WriteLine("Introduceti salariul angajatului:");
            decimal salariu;
            if (!decimal.TryParse(Console.ReadLine(), out salariu))
            {
                Console.WriteLine("Salariul introdus nu este într-un format corect. Vă rugăm să reintroduceți salariul angajatului.");
                return null; // În cazul în care salariul nu este introdus corect, returnăm null
            }

            Console.WriteLine("Introduceti departamentul angajatului:");
            string departament = Console.ReadLine();

            // Creăm un obiect de tip Angajat cu datele introduse și îl returnăm
            return new Angajat(nume, prenume, cnp, dataAngajarii, salariu, departament);
        }
        public static void AfisareListaAngajati()
        {
            Console.WriteLine("Lista de angajați:");
            Console.WriteLine("............................................................................................................");
            Console.WriteLine("Nr. | Nume                  | Prenume      | CNP           | Data angajării  | Salariu | Departament");
            Console.WriteLine("............................................................................................................");

            // Verificăm dacă există angajați înregistrați
            if (nrAngajati == 0)
            {
                Console.WriteLine("Nu există angajați înregistrați.");
                return;
            }

            // Parcurgem array-ul de angajați și afișăm fiecare angajat
            for (int i = 0; i < nrAngajati; i++)
            {
                Console.WriteLine($"{i + 1,-4}| {angajati[i].Nume,-21}| {angajati[i].Prenume,-14} | {angajati[i].CNP,-14} | {angajati[i].DataAngajarii.ToString("dd/MM/yyyy"),-17}| {angajati[i].Salariu,-8} | {angajati[i].Departament,-11}");
            }
            Console.WriteLine("............................................................................................................");
        }

    }
}
