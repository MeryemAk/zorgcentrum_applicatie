using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain; 
public abstract class persoon : IComparable<persoon> {
    public string Naam { get; set; }
    public string Voornaam { get; set; }
    // public int RRN { get; set; }
    // apart voor arts en patient of toch samen onder klasse persoon
    public int CompareTo(persoon other) {
        return Voornaam.CompareTo(other.Voornaam);
    }
}
