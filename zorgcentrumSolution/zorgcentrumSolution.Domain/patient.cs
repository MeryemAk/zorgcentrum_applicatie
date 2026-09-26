using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain;

public class patient {
    public int RRNPatient {  get; set; }
    public string Naam { get; set; }
    public string Voornaam { get; set; }
    public string AfdelingCode { get; set; }

    public patient(int RRNpatient, string naam, string voornaam, string afdelingCode) {
        RRNPatient = RRNpatient;
        Naam = naam;
        Voornaam = voornaam;
        AfdelingCode = afdelingCode;
    }
}