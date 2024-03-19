using System;

namespace GestiuneStocMateriePrima

{
    public class StocMateriePrima
    {
        public decimal CantitateDisponibila { get; set; }
        public decimal PretPerUnitate { get; set; }
        public string Locatie { get; set; }

        public StocMateriePrima()
        {
            CantitateDisponibila = 0;
            PretPerUnitate = 0;
            Locatie = string.Empty;
        }

        public StocMateriePrima(decimal cantitateDisponibila, decimal pretPerUnitate, string locatie)
        {
            CantitateDisponibila = cantitateDisponibila;
            PretPerUnitate = pretPerUnitate;
            Locatie = locatie;
        }

        public string Info()
        {
            return $"Cantitate disponibila: {CantitateDisponibila}, Pret per unitate: {PretPerUnitate}, Locatie: {Locatie}.";
        }
    }
}
