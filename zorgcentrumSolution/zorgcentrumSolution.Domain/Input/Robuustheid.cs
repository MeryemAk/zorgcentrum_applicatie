using BuildingBlocks;
using BuildingBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using zorgcentrumSolution.Domain.AfspraakType;
using zorgcentrumSolution.Domain.Person;

namespace zorgcentrumSolution.Domain.Input;
public class RobuustheidAfspraken {
    public List<Error> errors = new();
    public RobuustheidAfspraken() {
        string bestandnaam = Path.Combine(Environment.CurrentDirectory, "Input", "Afspraken.csv");

        string[] regels = CSVLezer.LeesRegels(bestandnaam, "Fouten_Afspraken.txt", errors); ;
        if (regels.Length == 0) {
            return;
        }

        for (int index = 1; index < regels.Length; index++) {
            // start at index 1 to exclude header
            string regel = regels[index];
            string[] velden = regel.Split(";");

            List<string> foutmeldingen = new();

            if (velden.Length < 9) {
                foutmeldingen.Add("Te weinig velden");
            }

            if (!int.TryParse(velden[0], out int afspraakId))
                foutmeldingen.Add($"Ongeldig afspraakId: {velden[0]}");

            string type = velden[1];
            if (string.IsNullOrWhiteSpace(type))
                foutmeldingen.Add($"Ongeldig afspraaktype: {type}");

            if (!DateTime.TryParse(velden[2], out DateTime start))
                foutmeldingen.Add($"Ongeldige startdatum: {velden[2]}");

            if (!int.TryParse(velden[3], out int duur))
                foutmeldingen.Add($"Ongeldige duur: {velden[3]}");

            RRN rrnPatient = RRN.Create(velden[4]);
            if (rrnPatient == null) {
                foutmeldingen.Add($"Ongeldig RijksregisterNr Patient: {velden[4]}");
            }

            RRN rrnArts = RRN.Create(velden[5]);
            if (rrnArts == null) {
                foutmeldingen.Add($"Ongeldig RijksregisterNr Arts: {velden[5]}");
            }

            string afdelingCode = velden[6];
            if (string.IsNullOrWhiteSpace(afdelingCode))
                foutmeldingen.Add("Afdelingscode is leeg");

            string extra1 = velden[7];
            string extra2 = velden[8];

            // controle op juiste input van basisgegevens
            if (foutmeldingen.Count > 0) {
                errors.Add(Error.Create(index + 1, regel, foutmeldingen));
                continue;
            }

            // Maak afspraak per type indien alles voldoet
            Afspraak nieuw = null;

            if (type == "Operatie") {
                if (string.IsNullOrWhiteSpace(extra1))
                    foutmeldingen.Add("Beschrijving (Extra 1) is leeg");
                else if (!int.TryParse(extra2, out int aanwezigheidMin))
                    foutmeldingen.Add("Ongeldige aanwezigheidstijd (Extra2): " + extra2);
                else
                    nieuw = new Operatie(afspraakId, start, duur, rrnPatient, rrnArts, afdelingCode, extra1, aanwezigheidMin);

            } else if (type == "Consultatie") {
                nieuw = new Consultatie(afspraakId, start, duur, rrnPatient, rrnArts, afdelingCode);

            } else if (type == "Controle") {
                
                if (!extra1.StartsWith("ref=")) {
                    foutmeldingen.Add("Extra1 moet beginnen met ref=: " + extra1);
                } else {
                    string idTekst = extra1.Substring(4);   // alles na "ref=" (AI)
                    if (!int.TryParse(idTekst, out int eerdereId)) {
                        foutmeldingen.Add("Ongeldige referentie: " + extra1);
                    } else {
                        // afspraak dat hoort bij ref opzoeken via zoekAfspraak() method 
                        nieuw = new Controle(afspraakId, start, duur, rrnPatient, rrnArts, afdelingCode, eerdereId);
                    }
                }

            } else {
                foutmeldingen.Add($"Onbekend afspraaktype: {type}");
            }

            if (foutmeldingen.Count > 0) {
                errors.Add(Error.Create(index + 1, regel, foutmeldingen));
                continue;
            }
        }
    }
}

public class RobuustheidArtsen {
    public List<Arts> Arts = new();
    public List<Error> errors = new();
    public RobuustheidArtsen() {
        string bestandnaam = Path.Combine(Environment.CurrentDirectory, "Input", "Artsen.csv");

        string[] regels = CSVLezer.LeesRegels(bestandnaam, "Fouten_Artsen.txt", errors); ;
        if (regels.Length == 0) {
            return;
        };

        for (int index = 1; index < regels.Length; index++) {
            // start at index 1 to exclude header
            string regel = regels[index];
            string[] velden = regel.Split(";");

            if (velden.Length < 6) {
                errors.Add(Error.Create(index + 1, regel, "Te weinig velden"));
                continue;
            }

            List<string> foutmeldingen = new();

            RRN rrn = RRN.Create(velden[0]);
            if (rrn == null) {
                foutmeldingen.Add($"Ongeldig RijksregisterNr: {velden[0]}");
            }

            if (string.IsNullOrWhiteSpace(velden[1]))
                foutmeldingen.Add($"Ongeldig naam: {velden[1]}");

            if (string.IsNullOrWhiteSpace(velden[2]))
                foutmeldingen.Add($"Ongeldige voornaam: {velden[2]}");

            RIZIV riziv = RIZIV.Create(velden[0]);
            if (riziv == null) {
                foutmeldingen.Add($"Ongeldig RIZIV: {velden[0]}");
            }

            if (string.IsNullOrWhiteSpace(velden[4]))
                foutmeldingen.Add($"Ongeldig specialisatie: {velden[4]}");

            if (string.IsNullOrWhiteSpace(velden[5]))
                foutmeldingen.Add($"Ongeldig afdeling: {velden[5]}");

            if (foutmeldingen.Count > 0) {
                errors.Add(Error.Create(index + 1, regel, foutmeldingen));
                continue;
            }

            // Maak arts object indien alles voldoet
            Arts.Add(new Arts(rrn, velden[1], velden[2], riziv, velden[4], velden[5]));
        }
        Fout.SchrijfFoutbestand("Fouten_Artsen.txt", errors);
    }
}
