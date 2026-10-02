using BuildingBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.Person; 
public class Arts : Persoon {
    public RRN RRN { get; }
    public RIZIV RIZIV { get; set; }
    public string Specialisatie { get; set; }
    public string AfdelingCode { get; set; }

    public Arts(RRN rrn, string naam, string voornaam, RIZIV riziv, string specialisatie, string afdelingCode) {
        RRN = rrn;
        Naam = naam;
        Voornaam = voornaam;
        RIZIV = riziv;
        Specialisatie = specialisatie;
        AfdelingCode = afdelingCode;
    }

}
