using System;
using System.Collections.Generic;
using System.Text;
using zorgcentrumSolution.Domain.Person;

namespace zorgcentrumSolution.Domain.AfspraakType; 
public class Controle : Afspraak {
    public Afspraak EerdereAfspraak { get; }

    public Controle(int afspraakId, DateTime datumTijdStart, int duurMin, Patient patient, Arts arts, string afdelingCode, Afspraak eerdereAfspraak)
        : base(afspraakId, datumTijdStart, duurMin, patient, arts, afdelingCode) {

        // domeinregels
        if (eerdereAfspraak == null)
            throw new ArgumentException("Een controle verwijst naar een eerdere afspraak.");
        if (datumTijdStart <= eerdereAfspraak.DatumTijdStart)
            throw new ArgumentException("Een controle moet later zijn dan de eerdere afspraak.");
        if (afdelingCode != eerdereAfspraak.AfdelingCode)
            throw new ArgumentException("Een controle moet op dezelfde afdeling gebeuren als de eerdere afspraak.");
        if (!patient.RRN.Equals(eerdereAfspraak.Patient.RRN))
            throw new ArgumentException("Een controle moet voor dezelfde patiënt zijn als de eerdere afspraak.");

        EerdereAfspraak = eerdereAfspraak;
    }
}
