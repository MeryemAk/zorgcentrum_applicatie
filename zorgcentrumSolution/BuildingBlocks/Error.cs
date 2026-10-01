using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BuildingBlocks;
public record Error {
    public int LijnNummer { get; }
    public string LijnInhoud { get; }
    public List<string> Beschrijving { get; }

    private Error(int lijnNummer, string lijnInhoud, List<string> beschrijving) {
        LijnNummer = lijnNummer;
        LijnInhoud = lijnInhoud;
        Beschrijving = beschrijving;
    }

    // input van een lijst met fout meldingen
    public static Error Create(int lijnNummer, string lijnInhoud, List<string> beschrijving) {
        return new Error(lijnNummer, lijnInhoud, beschrijving);
    }

    // input met 1 enkel foutmelding
    public static Error Create(int lijnNummer, string lijnInhoud, string beschrijving) {
        return new Error(lijnNummer, lijnInhoud, new List<string> { beschrijving });
    }
}
