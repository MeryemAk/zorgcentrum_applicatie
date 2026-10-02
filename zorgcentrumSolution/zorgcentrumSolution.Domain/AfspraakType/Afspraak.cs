using BuildingBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.AfspraakType; 
public class Afspraak {
    public int AfspraakId {  get; set; }
    public string AfspraakType { get; set; }
    public DateTime DatumTijdStart { get; set; }
    public DateTime DuurMin {  get; set; }
    public RRN RRN { get; }
    public string AfdelingCode { get; set; }
    public string Extra1 { get; set; }
    public string Extra2 {  get; set; }

    public Afspraak(int afspraakId, string afspraakType, DateTime datumTijdStart, DateTime duurMin, RRN rrn, string afdelingCode, string extra1, string extra2) {
        AfspraakId = afspraakId;
        AfspraakType = afspraakType;
        DatumTijdStart = datumTijdStart;
        DuurMin = duurMin;
        RRN = rrn;
        AfdelingCode = afdelingCode;
        Extra1 = extra1;
        Extra2 = extra2;
    } 
}


