using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BuildingBlocks.ValueObjects; 
public record RRN {
    public string Waarde { get; }

    private RRN (string waarde) {
        Waarde = waarde;
    }

    public static RRN Create(string invoer) {
        if (string.IsNullOrWhiteSpace(invoer)) {
            return null;
        }

        string cijfers = invoer.Trim().Replace(".", "").Replace("-", "");

        if (cijfers.Length != 11) {
            return null;
        }

        // eerste 6 cijfers halen uit RRN
        string geboorteDatumTekst = cijfers[..6]; // yyMMdd

        // proberen om cijfers om te zetten naar geboortedatum in yyMMdd formaat
        if (!DateTime.TryParseExact(geboorteDatumTekst,
                                    "yyMMdd",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out DateTime geboorteDatum)) 
        {
            return null; // indien niet gelukt dan null geven
        }

        // EERST normale RRN modulo 97, indien NIET 0 dan is het met 2 er voor

        /* FOUT
        int CheckDigit;
        // geboren voor 2000?
        if (geboorteDatum < new DateTime(2000, 1, 1)) {
            // eerste 9 cijfers van RRN
            int Eerste9 = int.Parse(cijfers[..9]);
            CheckDigit = 97 - (Eerste9 % 97);

        } else { //geboren na 2000?
            // cijfer 2 gevolgd door eerste 9 cijfers van RRN
            string Eerste9String = "2" + cijfers[..9];
            int Eerste9Int = int.Parse(Eerste9String);
            CheckDigit = 97 - (Eerste9Int % 97);
        }

        int controle = int.Parse(cijfers[9..11]);
        if (CheckDigit != controle) {
            return null; // indien CheckDigit niet gelijk aan laatste 2 cijfers dan is RRN niet correct
        } */

        return new RRN(cijfers);
    }
}
