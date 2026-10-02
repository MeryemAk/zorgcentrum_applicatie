using BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.Input;
public static class Fout {
    public static void SchrijfFoutbestand(string pad, List<Error> errors) {
        // bestand leegmaken
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
