using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.ValueObjects; 
public record RIZIV {
    // RIZIV nummer bestaat uit 11 cijfers 
    public string Waarde { get; }
    private RIZIV(string waarde) {
        Waarde = waarde;
    }

    public static RIZIV Create(string invoer) {
        // controle: is RIZIV leeg
        if (string.IsNullOrWhiteSpace(invoer)) {
            return null;
        }
        string cijfers = invoer.Trim().Replace("-", "");

        // controle: bestaat RIZIV uit 11 cijfers
        if (cijfers.Length != 11) {
            return null;
        }

        // controle: bestaat gegeven input enkel uit cijfers
        foreach (char c in cijfers) {
            if (c < '0' || c > '9') {
                return null;
            }
        }

        return new RIZIV(cijfers);
    }
}
