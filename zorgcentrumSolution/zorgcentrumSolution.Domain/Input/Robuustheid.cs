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

        if (!File.Exists(bestandnaam)) {
            errors.Add(Error.Create(0, "", "Bestand bestaat niet"));
            Fout.SchrijfFoutbestand("Fouten_Afspraken.txt", errors);
            return;
        } // geef error indien bestand niet bestaat

        string[] regels = File.ReadAllLines(bestandnaam);

        for (int index = 0; index < regels.Length; index++) {

            string regel = regels[index];
            string[] velden = regel.Split(";");

            List<string> foutmeldingen = new();

            if (velden.Length < 9) { // extra 1 en 2 soms leeg?? hoe behandelen?
                foutmeldingen.Add("Te weinig velden");
            }


            if (!int.TryParse(velden[0], out int afspraakId))
                foutmeldingen.Add($"Ongeldig afspraakId: {velden[0]}");

            if (!Enum.TryParse(velden[1], out string afspraakType))
                foutmeldingen.Add($"Ongeldig afspraaktype: {velden[1]}");

            if (!DateTime.TryParse(velden[2], out DateTime start))
                foutmeldingen.Add($"Ongeldige startdatum: {velden[2]}");

            if (!DateTime.TryParse(velden[3], out DateTime duur))
                foutmeldingen.Add($"Ongeldige duur: {velden[3]}");

            if (!int.TryParse(velden[4], out int rrnPatient))
                foutmeldingen.Add($"Ongeldig RRN patiënt: {velden[4]}");

            if (!int.TryParse(velden[5], out int rrnArts))
                foutmeldingen.Add($"Ongeldig RRN arts: {velden[5]}");

            // extra 1

            // extra 2

            if (foutmeldingen.Count > 0) { // if foutmeldingen.Any() kan ook gebruikt worden
                errors.Add(Error.Create(index + 1, regel, foutmeldingen));
                continue;
            }

            // Maak afspraak indien alles voldoet
            Afspraken.Add(new Afspraak
            {
                AfspraakId = afspraakId,
                AfspraakType = velden[1],
                DatumTijdStart = DateTime.Parse(velden[2]),
                DuurMin = DateTime.Parse(velden[3]),
                //RRN = velden[4], 
                //RRN = velden[5],
                AfdelingCode = velden[6],
                Extra1 = velden[7],
                Extra2 = velden[8]
            });
        }
    }
}

public class RobuustheidArtsen {
    public List<Arts> Arts = new();
    public List<Error> errors = new();
    public RobuustheidArtsen() {
        string bestandnaam = @"C:\school\semester1\programmeren_gevorderd1\zorgcentrum_applicatie\zorgcentrumSolution\zorgcentrumSolution.Domain\Input\Artsen.csv";

        string[] regels = CSVLezer.LeesRegels(bestandnaam, "Fouten_Artsen.txt", errors); ;
        if (regels.Length > 0) {
            return;
        };

        for (int index = 1; index < regels.Length; index++) {
            // start at index 1 to exclude header
            string regel = regels[index];
            string[] velden = regel.Split(";");
            List<string> foutmeldingen = new();

            if (velden.Length < 6) {
                errors.Add(Error.Create(index + 1, regel, "Te weinig velden"));
                continue;
            }


            if (!int.TryParse(velden[0], out RRN rrn))
                foutmeldingen.Add($"Ongeldig RijksregisterNr: {velden[0]}");
            // rrn bevat puntjes en streepjes - controle herzien

            if (string.IsNullOrWhiteSpace(velden[1]))
                foutmeldingen.Add($"Ongeldig naam: {velden[1]}");

            if (string.IsNullOrWhiteSpace(velden[2]))
                foutmeldingen.Add($"Ongeldige voornaam: {velden[2]}");

            if (!int.TryParse(velden[3], out RIZIV riziv))
                foutmeldingen.Add($"Ongeldige RIZIV: {velden[3]}");

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
