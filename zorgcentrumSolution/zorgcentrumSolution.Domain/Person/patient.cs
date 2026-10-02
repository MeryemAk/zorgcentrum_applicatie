using BuildingBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.Person;

public class Patient : Persoon {
    public string AfdelingCode { get; set; }
    public RRN RRN { get; }

    public Patient(RRN rrn, string naam, string voornaam, string afdelingCode) {
        RRN = rrn;
        Naam = naam;
        Voornaam = voornaam;
        AfdelingCode = afdelingCode;
    }
}