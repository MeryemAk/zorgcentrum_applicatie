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
    public List<Afspraak> Afspraken = new();
    public List<Error> errors = new();
    public RobuustheidAfspraken() {
        string bestandnaam = Path.Combine(Environment.CurrentDirectory, "Input", "Afspraken.csv");

        string[] regels = CSVLezer.LeesRegels(bestandnaam, "Fouten_Afspraken.txt", errors); ;
        if (regels.Length > 0) {
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

            if (string.IsNullOrWhiteSpace(velden[1]))
                foutmeldingen.Add($"Ongeldig afspraaktype: {velden[1]}");

            if (!DateTime.TryParse(velden[2], out DateTime start))
                foutmeldingen.Add($"Ongeldige startdatum: {velden[2]}");

            if (!DateTime.TryParse(velden[3], out DateTime duur))
                foutmeldingen.Add($"Ongeldige duur: {velden[3]}");

            RRN rrnPatient = RRN.Create(velden[4]);
            if (rrnPatient == null) {
                foutmeldingen.Add($"Ongeldig RijksregisterNr Patient: {velden[4]}");
            }

            RRN rrnArts = RRN.Create(velden[5]);
            if (rrnArts == null) {
                foutmeldingen.Add($"Ongeldig RijksregisterNr Arts: {velden[5]}");
            } // RRN in database zoeken??

            if (string.IsNullOrWhiteSpace(velden[6]))
                foutmeldingen.Add($"Extra 1 leeg: {velden[1]}");

            if (string.IsNullOrWhiteSpace(velden[7]))
                foutmeldingen.Add($"Extra 2 leeg: {velden[1]}");

            if (foutmeldingen.Any()) {
                errors.Add(Error.Create(index + 1, regel, foutmeldingen));
                continue;
            }

            // Maak afspraak object indien alles voldoet
            Afspraken.Add(new Afspraak(afspraakId, velden[1], DateTime.Parse(velden[2]), DateTime.Parse(velden[3]), rrnPatient, velden[6], velden[7], velden[8]));
        }
    }
}

public class RobuustheidArtsen {
    public List<Arts> Arts = new();
    public List<Error> errors = new();
    public RobuustheidArtsen() {
        string bestandnaam = Path.Combine(Environment.CurrentDirectory, "Input", "Artsen.csv");

        string[] regels = CSVLezer.LeesRegels(bestandnaam, "Fouten_Artsen.txt", errors); ;
        if (regels.Length > 0) {
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

            if (foutmeldingen.Any()) {
                errors.Add(Error.Create(index + 1, regel, foutmeldingen));
                continue;
            }

            // Maak arts object indien alles voldoet
            Arts.Add(new Arts(rrn, velden[1], velden[2], riziv, velden[4], velden[5]));
        }
        Fout.SchrijfFoutbestand("Fouten_Artsen.txt", errors);
    }
}
