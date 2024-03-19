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
        static void Main()
        {
            StocMateriePrima stocMateriePrima = new StocMateriePrima();
            Angajat angajatNou = new Angajat();
            MateriePrima materiePrimaNoua = new MateriePrima();
            int nrAngajati = 0;
            int nrMateriiPrime = 0;

            string optiune;
            int ok = 0;

            do
            {
                Console.WriteLine("ATENTIE: Dupa fiecare angajat/materie prima citit(a) de la tastatura " +
                                  "acesta trebuie salvat(a) pentru a ramane in lista respectiva!");
                Console.WriteLine();
                Console.WriteLine("1. Citire informații angajat de la tastatură");
                Console.WriteLine("2. Citire informații materie primă de la tastatură");
                Console.WriteLine("3. Afișare lista de angajați");
                Console.WriteLine("4. Afișare lista de materii prime");
                Console.WriteLine("5. Salvare angajat/materie primă în listă");
                Console.WriteLine("6. Inchidere program");

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
                        break;

                    case "4":
                        // Adaugă cod pentru afișarea listei de materii prime
                        break;

                    case "5":
                        if (ok == 1)
                        {
                            // Adaugare angajat în listă
                            nrAngajati++;
                            Console.WriteLine("Angajatul a fost salvat în listă.");
                        }
                        else if (ok == 2)
                        {
                            // Adaugare materie primă în listă
                            nrMateriiPrime++;
                            Console.WriteLine("Materia primă a fost salvată în listă.");
                        }
                        else
                        {
                            Console.WriteLine("Nu s-a citit niciun angajat sau materie primă.");
                        }
                        break;

                    case "6":
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


        public static MateriePrima CitireMateriePrimaTastatura()
        {
            // Adaugă cod pentru citirea informațiilor unei materii prime de la tastatură
            return new MateriePrima(); // Returnează o materie primă nou creată
        }
    }
}
