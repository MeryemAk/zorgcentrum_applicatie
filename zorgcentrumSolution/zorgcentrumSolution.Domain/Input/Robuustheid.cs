using BuildingBlocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zorgcentrumSolution.Domain.Input; 
public class RobuustheidAfspraken {
    public List<afspraak> Afspraken = new();
    public List<Error> errors = new();
    public RobuustheidAfspraken() {
        string bestandnaam = "Afspraken.csv";

        if (!File.Exists(bestandnaam)) {
            errors.Add(Error.Create(0, "", "Bestand bestaat niet"));
            SchrijfFoutbestand("Fouten_Afspraken.txt", errors);
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

            if (!Enum.TryParse(velden[1], out AfspraakType afspraakType))
                foutmeldingen.Add($"Ongeldig afspraaktype: {velden[1]}");

            if (!DateTime.TryParse(velden[2], out DateTime start))
                foutmeldingen.Add($"Ongeldige startdatum: {velden[2]}");

            if (!DateTime.TryParse(velden[3], out DateTime duur))
                foutmeldingen.Add($"Ongeldige duur: {velden[3]}");

            if (!int.TryParse(velden[4], out int rrnPatient))
                foutmeldingen.Add($"Ongeldig RRN patiënt: {velden[4]}");

            if (!int.TryParse(velden[5], out int rrnArts))
                foutmeldingen.Add($"Ongeldig RRN arts: {velden[5]}");

            if (foutmeldingen.Count > 0) {
                errors.Add(Error.Create(index + 1, regel, foutmeldingen));
                continue;
            }

            // Maak afspraak indien alles voldoet
            Afspraken.Add(new afspraak
            {
                AfspraakId = afspraakId,
                AfspraakType = Enum.Parse<AfspraakType>(velden[1]),
                DatumTijdStart = DateTime.Parse(velden[2]),
                DuurMin = DateTime.Parse(velden[3]),
                RRNPatient = int.Parse(velden[4]),
                RRNArts = int.Parse(velden[5]),
                AfdelingCode = velden[6],
                Extra1 = velden[7],
                Extra2 = velden[8]
            });
        }
    }



    // foutbestand genereren
    private void SchrijfFoutbestand(string pad, List<Error> errors) {
        // Maak het bestand leeg elke keer dat input files ingehaald worden
        File.WriteAllText(pad, "");

        foreach (var error in errors) {
            File.AppendAllText(pad, $"Lijn: {error.LijnNummer}\n");
            File.AppendAllText(pad, $"Inhoud: {error.LijnInhoud}\n");
            File.AppendAllText(pad, "Fouten:\n");

            foreach (var bericht in error.Beschrijving) {
                File.AppendAllText(pad, $" - {bericht}\n");
            }

            File.AppendAllText(pad, "\n");
        }
    }
}
