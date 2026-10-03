using System;
using System.Collections.Generic;
using System.Text;
using zorgcentrumSolution.Domain.Person;

namespace zorgcentrumSolution.Domain.AfspraakType;

public class Operatie : Afspraak {
    public string Beschrijving { get; }
    public int AanwezigheidMin { get; }

    public Operatie(int afspraakId, DateTime start, int duurMin, Patient patient, Arts arts, string afdeling, string beschrijving, int aanwezigheidMin)
        : base(afspraakId, start, duurMin, patient, arts, afdeling) {

        // domeinregels
        if (string.IsNullOrWhiteSpace(beschrijving))
            throw new ArgumentException("Een operatie vereist een beschrijving.");
        if (duurMin <= 30)
            throw new ArgumentException("Een operatie duurt minstens 30 minuten.");
        if (aanwezigheidMin < 30)
            throw new ArgumentException("De patiënt moet minstens 30 minuten voor de operatie aanwezig zijn.");

        Beschrijving = beschrijving;
        AanwezigheidMin = aanwezigheidMin;
    }
}
