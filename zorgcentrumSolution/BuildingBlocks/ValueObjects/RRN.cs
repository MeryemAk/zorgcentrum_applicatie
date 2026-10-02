using System;
using System.Collections.Generic;
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

        return new RRN(cijfers);
    }
}
