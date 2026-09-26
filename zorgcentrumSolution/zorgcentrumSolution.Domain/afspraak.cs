using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain; 
public class afspraak {
    public int AfspraakId {  get; set; }
    public AfspraakType AfspraakType { get; }
    public DateTime DatumTijdStart { get; set; }
    public DateTime DuurMin {  get; set; }
    public int RRNPatient { get; set; }
    public int RRNArts { get; set; }
    public string AfdelingCode { get; set; }
    public string Extra1 { get; set; }
    public string Extra2 {  get; set; }
}
