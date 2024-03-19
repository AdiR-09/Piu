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

        public MateriePrima()
        {
            TipMateriePrima = string.Empty;
            Lungime = 0;
            Diametru = 0;
            Calitate = string.Empty;
            DataAprovizionare = DateTime.MinValue;
            LocatieDepozitare = string.Empty;
        }

        public MateriePrima(string tipMateriePrima, decimal lungime, decimal diametru, string calitate, DateTime dataAprovizionare, string locatieDepozitare)
        {
            TipMateriePrima = tipMateriePrima;
            Lungime = lungime;
            Diametru = diametru;
            Calitate = calitate;
            DataAprovizionare = dataAprovizionare;
            LocatieDepozitare = locatieDepozitare;
        }

        public string Info()
        {
            return $"Tip materie prima: {TipMateriePrima}, Lungime: {Lungime}, Diametru: {Diametru}, Calitate: {Calitate}, Data aprovizionare: {DataAprovizionare}, Locatie depozitare: {LocatieDepozitare}.";
        }
    }
}
