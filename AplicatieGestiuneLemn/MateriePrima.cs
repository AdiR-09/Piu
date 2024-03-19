using System;

namespace GestionareMateriePrima
{
    public class MateriePrima
    {
        public string TipMateriePrima { get; set; }
        public decimal Lungime { get; set; }
        public decimal Diametru { get; set; }
        public string Calitate { get; set; }
        public DateTime DataAprovizionare { get; set; }
        public string LocatieDepozitare { get; set; }
        public string Denumire { get; set; } // Adăugăm proprietatea pentru denumirea materiei prime
        public decimal Cantitate { get; set; } // Adăugăm proprietatea pentru cantitatea materiei prime
        public decimal PretUnitar { get; set; } // Adăugăm proprietatea pentru prețul unitar al materiei prime

        public MateriePrima()
        {
            TipMateriePrima = string.Empty;
            Lungime = 0;
            Diametru = 0;
            Calitate = string.Empty;
            DataAprovizionare = DateTime.MinValue;
            LocatieDepozitare = string.Empty;
            Denumire = string.Empty; // Inițializăm denumirea cu un șir gol
            Cantitate = 0; // Inițializăm cantitatea cu 0
            PretUnitar = 0; // Inițializăm prețul unitar cu 0
        }

        // Constructorul cu parametri
        public MateriePrima(string tipMateriePrima, decimal lungime, decimal diametru, string calitate, DateTime dataAprovizionare, string locatieDepozitare, string denumire, decimal cantitate, decimal pretUnitar)
        {
            TipMateriePrima = tipMateriePrima;
            Lungime = lungime;
            Diametru = diametru;
            Calitate = calitate;
            DataAprovizionare = dataAprovizionare;
            LocatieDepozitare = locatieDepozitare;
            Denumire = denumire; // Inițializăm denumirea cu valoarea dată
            Cantitate = cantitate; // Inițializăm cantitatea cu valoarea dată
            PretUnitar = pretUnitar; // Inițializăm prețul unitar cu valoarea dată
        }

        public string Info()
        {
            return $"Tip materie prima: {TipMateriePrima}, Lungime: {Lungime}, Diametru: {Diametru}, Calitate: {Calitate}, Data aprovizionare: {DataAprovizionare}, Locatie depozitare: {LocatieDepozitare}, Denumire: {Denumire}, Cantitate: {Cantitate}, Pret unitar: {PretUnitar}.";
        }
    }
}
