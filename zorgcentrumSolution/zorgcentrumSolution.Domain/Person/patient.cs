using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.Person;

public class Patient : persoon {
    public int RRNPatient {  get; set; }
    public string AfdelingCode { get; set; }

    public Patient(int RRNpatient, string naam, string voornaam, string afdelingCode) {
        RRNPatient = RRNpatient;
        Naam = naam;
        Voornaam = voornaam;
        AfdelingCode = afdelingCode;
    }
}