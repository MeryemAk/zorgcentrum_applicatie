using System;
using System.Collections.Generic;
using System.Text;
using zorgcentrumSolution.Domain.Person;

namespace zorgcentrumSolution.Domain.AfspraakType; 
public class Consultatie : Afspraak {
    public Consultatie(int afspraakId, DateTime datumTijdStart, int duurMin, Patient patient, Arts arts, string afdelingCode)
        : base(afspraakId, datumTijdStart, duurMin, patient, arts, afdelingCode) {
        // domeinregels
        if (duurMin <= 10)
            throw new ArgumentException("Een consultatie duurt minstens 10 minuten.");
    }
}
