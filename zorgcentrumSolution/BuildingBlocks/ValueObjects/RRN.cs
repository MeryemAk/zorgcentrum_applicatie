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
        // controle: is RRN leeg
        if (string.IsNullOrWhiteSpace(invoer)) {
            return null;
        }

        string cijfers = invoer.Trim().Replace(".", "").Replace("-", "");

        // controle: bestaat RRN uit 11 cijfers
        if (cijfers.Length != 11) {
            return null;
        }

        // controle: bestaat gegeven input enkel uit cijfers
        foreach (char c in cijfers) {
            if (c < '0' || c > '9') {
                return null;
            }
        }

        long Eerste9 = long.Parse(cijfers[..9]); // 1ste 9 cijfers van RRN
        long controle = long.Parse(cijfers[9..11]);

        // eerst controle of het voor 2000 is
        long CheckDigit = 97 - (Eerste9 % 97);

        if (CheckDigit == controle) {
            return new RRN(cijfers);
        }
        else {
            // vanaf 2000 een 2 ervoor
            long Eerste9Na2000 = long.Parse("2" + cijfers[..9]); // long gebruiken anders Overflow Exc
            CheckDigit = 97 - (Eerste9Na2000 % 97);

            if (CheckDigit == controle) {
                return new RRN(cijfers);
            }
            else {
                return null; // geen van beide varianten klopt
            }
        }
    }
}
