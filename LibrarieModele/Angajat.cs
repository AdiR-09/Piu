using System;

namespace EntitatiAngajati

{
    public class Angajat
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public DateTime DataAngajarii { get; set; }
        public decimal Salariu { get; set; }
        public string Departament { get; set; }

        public Angajat()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            CNP = string.Empty;
            DataAngajarii = DateTime.MinValue;
            Salariu = 0;
            Departament = string.Empty;
        }

        public Angajat(string nume, string prenume, string cnp, DateTime dataAngajarii, decimal salariu, string departament)
        {
            Nume = nume;
            Prenume = prenume;
            CNP = cnp;
            DataAngajarii = dataAngajarii;
            Salariu = salariu;
            Departament = departament;
        }

        public string Info()
        {
            return $"Nume: {Nume}, Prenume: {Prenume}, CNP: {CNP}, Data angajarii: {DataAngajarii}, Salariu: {Salariu}, Departament: {Departament}.";
        }
    }
}
