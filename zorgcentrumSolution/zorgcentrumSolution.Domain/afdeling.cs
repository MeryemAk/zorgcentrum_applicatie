namespace zorgcentrumSolution.Domain;

public class Afdeling {
    public string Code { get; set; }
    public string Specialiteit { get; set; }

    public Afdeling(string code, string specialiteit) {
        Code = code;
        Specialiteit = specialiteit;
    }
}
public class AfdelingDictionary {
    public readonly Dictionary<string, Afdeling> CodeNaarSpecialiteit = new Dictionary<string, Afdeling> { //AI gebruik om tabel om te zetten naar dictionary
        { "ANES", new Afdeling("ANES", "Anesthesie‑reanimatie") },
        { "BIOL", new Afdeling("BIOL", "Klinische biologie") },
        { "CARD", new Afdeling("CARD", "Cardiologie") },
        { "CHIR", new Afdeling("CHIR", "Heelkunde") },
        { "DERM", new Afdeling("DERM", "Dermatologie") },
        { "ENDO", new Afdeling("ENDO", "Endocrino‑diabetologie") },
        { "GAST", new Afdeling("GAST", "Gastro‑enterologie") },
        { "GERC", new Afdeling("GERC", "Geriatrie") },
        { "GYNA", new Afdeling("GYNA", "Gynaecologie & verloskunde") },
        { "HEMA", new Afdeling("HEMA", "Klinische hematologie") },
        { "NCHI", new Afdeling("NCHI", "Neurochirurgie") },
        { "NEFR", new Afdeling("NEFR", "Nefrologie") },
        { "NEUR", new Afdeling("NEUR", "Neurologie") },
        { "NUCL", new Afdeling("NUCL", "Nucleaire geneeskunde") },
        { "ONCO", new Afdeling("ONCO", "Medische oncologie") },
        { "ORL",  new Afdeling("ORL",  "Oto‑Rhino‑Laryngologie") },
        { "OPHT", new Afdeling("OPHT", "Oftalmologie") },
        { "ORTH", new Afdeling("ORTH", "Orthopedische heelkunde") },
        { "PAAN", new Afdeling("PAAN", "Pathologische anatomie") },
        { "PEDI", new Afdeling("PEDI", "Kindergeneeskunde") },
        { "PNEU", new Afdeling("PNEU", "Pneumologie") },
        { "PSYC", new Afdeling("PSYC", "Psychiatrie") },
        { "RADO", new Afdeling("RADO", "Radiotherapie‑oncologie") },
        { "REUM", new Afdeling("REUM", "Reumatologie") },
        { "REVA", new Afdeling("REVA", "Fysische geneeskunde & revalidatie") },
        { "RXDI", new Afdeling("RXDI", "Röntgendiagnose") },
        { "SLAP", new Afdeling("SLAP", "Slaapgeneeskunde") },
        { "STOM", new Afdeling("STOM", "Stomatologie") },
        { "URGE", new Afdeling("URGE", "Urgentiegeneeskunde") },
        { "UROL", new Afdeling("UROL", "Urologie") },
        { "PNEC", new Afdeling("PNEC", "Pneumologie – Slaapcentrum") },
        { "CARD-AFD", new Afdeling("CARD-AFD", "Cardiologie‑afdeling") },
        { "GAST-AFD", new Afdeling("GAST-AFD", "Gastro‑enterologie afdeling") },
        { "NEUR-AFD", new Afdeling("NEUR-AFD", "Neurologie afdeling") },
        { "ORTH-AFD", new Afdeling("ORTH-AFD", "Orthopedie afdeling") },
        { "GERC-AFD", new Afdeling("GERC-AFD", "Geriatrie afdeling") },
        { "ONCO-AFD", new Afdeling("ONCO-AFD", "Oncologie afdeling") },
        { "PAAN-AFD", new Afdeling("PAAN-AFD", "Pathologische anatomie") },
        { "RADI", new Afdeling("RADI", "Radiologie / MRI / CT") },
        { "URGE-AFD", new Afdeling("URGE-AFD", "Spoed & urgentiegeneeskunde") }
    };
}