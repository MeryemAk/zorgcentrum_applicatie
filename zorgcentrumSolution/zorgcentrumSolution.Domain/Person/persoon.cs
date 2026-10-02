using BuildingBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.Person; 
public abstract class Persoon : IComparable<Persoon> {
    public string Naam { get; set; }
    public string Voornaam { get; set; }
    public RRN RNN { get; }
    
    public int CompareTo(Persoon other) {
        return Voornaam.CompareTo(other.Voornaam);
        // vergelijking op basis van voornaam nu maar niet beter op RNN?
    }
}
