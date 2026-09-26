using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain; 
public class afdeling {
    public string Code { get; set; }
    public string Specialiteit { get; set; }

    public afdeling(string code, string specialiteit) {
        Code = code;
        Specialiteit = specialiteit;
    }
}
public class afdelingDictionary {
    public readonly Dictionary<string, afdeling> CodeNaarSpecialiteit = new Dictionary<string, afdeling> { //AI gebruik om tabel om te zetten naar dictionary
        { "ANES", new afdeling("ANES", "Anesthesie‑reanimatie") },
        { "BIOL", new afdeling("BIOL", "Klinische biologie") },
        { "CARD", new afdeling("CARD", "Cardiologie") },
        { "CHIR", new afdeling("CHIR", "Heelkunde") },
        { "DERM", new afdeling("DERM", "Dermatologie") },
        { "ENDO", new afdeling("ENDO", "Endocrino‑diabetologie") },
        { "GAST", new afdeling("GAST", "Gastro‑enterologie") },
        { "GERC", new afdeling("GERC", "Geriatrie") },
        { "GYNA", new afdeling("GYNA", "Gynaecologie & verloskunde") },
        { "HEMA", new afdeling("HEMA", "Klinische hematologie") },
        { "NCHI", new afdeling("NCHI", "Neurochirurgie") },
        { "NEFR", new afdeling("NEFR", "Nefrologie") },
        { "NEUR", new afdeling("NEUR", "Neurologie") },
        { "NUCL", new afdeling("NUCL", "Nucleaire geneeskunde") },
        { "ONCO", new afdeling("ONCO", "Medische oncologie") },
        { "ORL",  new afdeling("ORL",  "Oto‑Rhino‑Laryngologie") },
        { "OPHT", new afdeling("OPHT", "Oftalmologie") },
        { "ORTH", new afdeling("ORTH", "Orthopedische heelkunde") },
        { "PAAN", new afdeling("PAAN", "Pathologische anatomie") },
        { "PEDI", new afdeling("PEDI", "Kindergeneeskunde") },
        { "PNEU", new afdeling("PNEU", "Pneumologie") },
        { "PSYC", new afdeling("PSYC", "Psychiatrie") },
        { "RADO", new afdeling("RADO", "Radiotherapie‑oncologie") },
        { "REUM", new afdeling("REUM", "Reumatologie") },
        { "REVA", new afdeling("REVA", "Fysische geneeskunde & revalidatie") },
        { "RXDI", new afdeling("RXDI", "Röntgendiagnose") },
        { "SLAP", new afdeling("SLAP", "Slaapgeneeskunde") },
        { "STOM", new afdeling("STOM", "Stomatologie") },
        { "URGE", new afdeling("URGE", "Urgentiegeneeskunde") },
        { "UROL", new afdeling("UROL", "Urologie") },
        { "PNEC", new afdeling("PNEC", "Pneumologie – Slaapcentrum") },
        { "CARD-AFD", new afdeling("CARD-AFD", "Cardiologie‑afdeling") },
        { "GAST-AFD", new afdeling("GAST-AFD", "Gastro‑enterologie afdeling") },
        { "NEUR-AFD", new afdeling("NEUR-AFD", "Neurologie afdeling") },
        { "ORTH-AFD", new afdeling("ORTH-AFD", "Orthopedie afdeling") },
        { "GERC-AFD", new afdeling("GERC-AFD", "Geriatrie afdeling") },
        { "ONCO-AFD", new afdeling("ONCO-AFD", "Oncologie afdeling") },
        { "PAAN-AFD", new afdeling("PAAN-AFD", "Pathologische anatomie") },
        { "RADI", new afdeling("RADI", "Radiologie / MRI / CT") },
        { "URGE-AFD", new afdeling("URGE-AFD", "Spoed & urgentiegeneeskunde") }
    };
}