using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain; 
public class afspraak {
    public int AfspraakId {  get; set; }
    public AfspraakType AfspraakType { get; }
    public DateTime DatumTijdStart { get; set; }
    public DateTime DuurMin {  get; set; }
    public int RRNPatient {  get; set;
    publc int RRNArts { get; set; }

}
