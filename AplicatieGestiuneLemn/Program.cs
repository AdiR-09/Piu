using System;
using System.Runtime.InteropServices;

// Importăm clasele noastre definite în alte fișiere
using EntitatiAngajati; // Pentru proiectul Angajat
using GestionareMateriePrima; // Pentru proiectul MateriePrima
using GestiuneStocMateriePrima; // Pentru proiectul StocMateriePrima
using System.Globalization;


namespace GestiuneLemn
{
    class Program
    {
        static int nrAngajati = 0;
        static Angajat[] angajati = new Angajat[MAX_ANGAJATI];
        static int nrMateriiPrime = 0;
        //static MateriePrima[] materiiPrime = new MateriePrima[MAX_MATERII_PRIME]; // Definim vectorul de materii prime
        const int MAX_ANGAJATI = 100;
        const int MAX_MATERII_PRIME = 100; // Definim capacitatea maximă a vectorului de materii prime
        static MateriePrima[] materiiPrime = new MateriePrima[MAX_MATERII_PRIME]; // Inițializăm array-ul de materii prime


        static void Main()
        {
            StocMateriePrima stocMateriePrima = new StocMateriePrima();
            Angajat angajatNou = new Angajat();
            MateriePrima materiePrimaNoua = new MateriePrima();


            string optiune;
            int ok = 0;

            do
            {
                Console.WriteLine("ATENTIE: Dupa fiecare angajat/materie prima citit(a) de la tastatura " +
                                  "acesta trebuie salvat(a) pentru a ramane in lista respectiva!");
                Console.WriteLine();
                Console.WriteLine("1. Citire informatii angajat de la tastatură");
                Console.WriteLine("2. Citire informatii materie primă de la tastatură");
                Console.WriteLine("3. Afișare lista de angajati");
                Console.WriteLine("4. Afișare lista de materii prime");
                Console.WriteLine("5. Salvare angajat/materie primă în listă");
                Console.WriteLine("6. Cautare dupa criterii-angajati");
                Console.WriteLine("7. Inchidere program");

                Console.WriteLine("Alegeti o optiune:");
                optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        angajatNou = CitireAngajatTastatura();
                        ok = 1;
                        break;

                    case "2":
                        materiePrimaNoua = CitireMateriePrimaTastatura();
                        ok = 2;
                        break;

                    case "3":
                        // Adaugă cod pentru afișarea listei de angajați
                        AfisareListaAngajati();
                        break;

                    case "4":
                        // Adaugă cod pentru afișarea listei de materii prime
                        AfisareListaMateriiPrime();
                        break;

                    case "5":
                        if (ok == 1)
                        {
                            // Verificăm dacă numărul maxim de angajați a fost atins
                            if (nrAngajati < MAX_ANGAJATI)
                            {
                                // Adăugăm noul angajat în array
                                angajati[nrAngajati] = angajatNou;
                                nrAngajati++; // Incrementăm numărul de angajați
                                Console.WriteLine("Angajatul a fost salvat în listă.");
                            }
                            else
                            {
                                Console.WriteLine("Numărul maxim de angajați a fost atins. Nu se poate adăuga mai multe persoane.");
                            }
                        }
                        else if (ok == 2)
                        {
                            // Adăugăm materia primă în array-ul de materii prime
                            if (nrMateriiPrime < MAX_MATERII_PRIME)
                            {
                                materiiPrime[nrMateriiPrime] = materiePrimaNoua;
                                nrMateriiPrime++;
                                Console.WriteLine("Materia primă a fost salvată în listă.");
                            }
                            else
                            {
                                Console.WriteLine("Numărul maxim de materii prime a fost atins. Nu se poate adăuga mai multe materii prime.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nu s-a citit niciun angajat sau materie primă.");
                        }
                        break;
                    case "6":
                        bool continuaCautare = true;
                        do
                        {
                            Console.WriteLine("Criterii de căutare:");
                            Console.WriteLine("1. Angajatii cu salariu sub 2500");
                            Console.WriteLine("2. Angajatii care lucrează în Transport");
                            Console.WriteLine("3. Revenire la meniul principal");
                            Console.WriteLine("Alegeți o opțiune:");
                            string criteriu = Console.ReadLine();
                            switch (criteriu)
                            {
                                case "1":
                                    CautareAngajatiSalariuSub(2500);
                                    break;
                                case "2":
                                    CautareAngajatiDepartament("Transport");
                                    break;
                                case "3":
                                    continuaCautare = false;
                                    break;
                                default:
                                    Console.WriteLine("Opțiune invalidă! Vă rugăm să selectați o opțiune validă.");
                                    break;
                            }
                        } while (continuaCautare);
                        break;

                    case "7":
                        Console.WriteLine("Programul se închide...");
                        return;

                    default:
                        Console.WriteLine("Opțiune invalidă! Vă rugăm să selectați o opțiune validă.");
                        break;
                }
            } while (optiune != "6");
        }

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


        public static void AfisareListaMateriiPrime()
        {
            Console.WriteLine("Lista de materii prime:");

            // Verificăm dacă există materii prime înregistrate
            if (nrMateriiPrime == 0)
            {
                Console.WriteLine("Nu există materii prime înregistrate.");
                return;
            }

            // Parcurgem array-ul de materii prime și afișăm fiecare materie primă
            for (int i = 0; i < nrMateriiPrime; i++)
            {
                Console.WriteLine($"Materia prima {i + 1}:");
                Console.WriteLine($"Denumire: {materiiPrime[i].Denumire}");
                Console.WriteLine($"Cantitate: {materiiPrime[i].Cantitate}");
                Console.WriteLine($"Prep unitar: {materiiPrime[i].PretUnitar}");
                Console.WriteLine();
            }
        }
        public static MateriePrima CitireMateriePrimaTastatura()
        {
            Console.WriteLine("Introduceti denumirea materiei prime:");
            string denumire = Console.ReadLine();

            Console.WriteLine("Introduceți tipul materiei prime:");
            string tipMateriePrima = Console.ReadLine();

            Console.WriteLine("Introduceți lungimea materiei prime:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal lungime))
            {
                Console.WriteLine("Lungimea introdusă nu este într-un format corect. Vă rugăm să reintroduceți lungimea materiei prime.");
                return null; // În cazul în care lungimea nu este introdusă corect, returnăm null
            }

            Console.WriteLine("Introduceți diametrul materiei prime:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal diametru))
            {
                Console.WriteLine("Diametrul introdus nu este într-un format corect. Vă rugăm să reintroduceți diametrul materiei prime.");
                return null; // În cazul în care diametrul nu este introdus corect, returnăm null
            }

            Console.WriteLine("Introduceți calitatea materiei prime:");
            string calitate = Console.ReadLine();

            Console.WriteLine("Introduceți data aprovizionării materiei prime (format: ZZ.LL.AAAA):");
            DateTime dataAprovizionare;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataAprovizionare))
            {
                Console.WriteLine("Data introdusă nu este în formatul corect. Vă rugăm să reintroduceți data aprovizionării materiei prime.");
                return null; // În cazul în care data nu este introdusă corect, returnăm null
            }

            Console.WriteLine("Introduceți locația de depozitare a materiei prime:");
            string locatieDepozitare = Console.ReadLine();

            Console.WriteLine("Introduceți cantitatea materiei prime:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal cantitate))
            {
                Console.WriteLine("Cantitatea introdusă nu este într-un format corect. Vă rugăm să reintroduceți cantitatea materiei prime.");
                return null; // În cazul în care cantitatea nu este introdusă corect, returnăm null
            }

            Console.WriteLine("Introduceți prețul unitar al materiei prime:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal pretUnitar))
            {
                Console.WriteLine("Prețul unitar introdus nu este într-un format corect. Vă rugăm să reintroduceți prețul unitar al materiei prime.");
                return null; // În cazul în care prețul unitar nu este introdus corect, returnăm null
            }

            // Creăm un obiect de tip MateriePrima cu datele introduse
            MateriePrima materiePrima = new MateriePrima(tipMateriePrima, lungime, diametru, calitate, dataAprovizionare, locatieDepozitare, denumire, cantitate, pretUnitar);

            // Adăugăm obiectul creat în array-ul materiiPrime
            materiiPrime[nrMateriiPrime] = materiePrima;
            nrMateriiPrime++; // Incrementăm numărul de materii prime

            // Returnăm obiectul creat
            return materiePrima;
        }

        public static void CautareAngajatiSalariuSub(decimal limitaSalariu)
        {
            Console.WriteLine($"Angajații cu salariu sub {limitaSalariu}:");
            bool gasit = false;
            foreach (var angajat in angajati)
            {
                if (angajat != null && angajat.Salariu < limitaSalariu)
                {
                    Console.WriteLine($"Nume: {angajat.Nume}, Prenume: {angajat.Prenume}, Salariu: {angajat.Salariu}");
                    gasit = true;
                }
            }
            if (!gasit)
            {
                Console.WriteLine("Nu s-au găsit angajați conform criteriilor.");
            }
        }

        public static void CautareAngajatiDepartament(string departamentCautat)
        {
            Console.WriteLine($"Angajații care lucrează în departamentul {departamentCautat}:");
            bool gasit = false;
            foreach (var angajat in angajati)
            {
                if (angajat != null && angajat.Departament.Equals(departamentCautat, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Nume: {angajat.Nume}, Prenume: {angajat.Prenume}, Departament: {angajat.Departament}");
                    gasit = true;
                }
            }
            if (!gasit)
            {
                Console.WriteLine($"Nu s-au găsit angajați care lucrează în departamentul {departamentCautat}.");
            }
        }






    }
}
