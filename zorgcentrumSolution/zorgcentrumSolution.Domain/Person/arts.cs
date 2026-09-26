using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.Person; 
public class arts : persoon {
    public int RRNArts { get; set; }
    public int RIZIV { get; set; }
    public string Specialisatie { get; set; }
    public string AfdelingCode { get; set; }

    public arts(int RNNarts, string naam, string voornaam, int riziv, string specialisatie, string afdelingCode) {
        RRNArts = RNNarts;
        Naam = naam;
        Voornaam = voornaam;
        RIZIV = riziv;
        Specialisatie = specialisatie;
        AfdelingCode = afdelingCode;
    }

}
