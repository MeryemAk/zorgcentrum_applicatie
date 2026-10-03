using BuildingBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using zorgcentrumSolution.Domain.Person;

namespace zorgcentrumSolution.Domain.AfspraakType; 
public abstract class Afspraak : IComparable<Afspraak> {
    public int AfspraakId {  get; }
    public DateTime DatumTijdStart { get; }
    public int DuurMin {  get; }
    public Patient Patient { get; }
    public Arts Arts { get; }
    public string AfdelingCode { get; }

    public DateTime DatumTijdEinde {
        get { return DatumTijdStart.AddMinutes(DuurMin); }
    } // AddMinutes method via AI

    protected Afspraak(int afspraakId, DateTime datumTijdStart, int duurMin, Patient patient, Arts arts, string afdelingCode) {

        // Domeinregels
        if (duurMin <= 0)
            throw new ArgumentException("Duur moet positief zijn.");
        if (patient == null)
            throw new ArgumentException("Patiënt is verplicht.");
        if (arts == null)
            throw new ArgumentException("Arts is verplicht.");
        if (string.IsNullOrWhiteSpace(afdelingCode))
            throw new ArgumentException("Afdeling is verplicht.");
        if (patient.RRN.Equals(arts.RRN))
            throw new ArgumentException("Arts en patiënt mogen niet dezelfde persoon zijn.");
        if (patient.AfdelingCode != afdelingCode)
            throw new ArgumentException("Patient moet ingeschreven zijn in afdeling");
        if (arts.AfdelingCode != afdelingCode)
            throw new ArgumentException("Arts moet ingeschreven zijn in afdeling");

        AfspraakId = afspraakId;
        DatumTijdStart = datumTijdStart;
        DuurMin = duurMin;
        Patient Patient = patient;
        Arts Arts = arts;
        AfdelingCode = afdelingCode;
    }

    public bool IsErOverlap(Afspraak other) {
        // A eindigt voor of op het moment dat B begint -> geen overlap
        if (DatumTijdEinde <= other.DatumTijdStart)
            return false;

        // B eindigt voor of op het moment dat A begint -> geen overlap
        if (other.DatumTijdEinde <= DatumTijdStart)
            return false;

        // anders overlappen ze
        return true;
    }

    public int CompareTo(Afspraak other) {
        return AfspraakId.CompareTo(other.AfspraakId);
        // vergelijking op basis van AfspraakId
    }
}


