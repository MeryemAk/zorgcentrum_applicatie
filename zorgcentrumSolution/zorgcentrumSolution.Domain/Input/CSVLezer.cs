using BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.Domain.Input; 
public static class CSVLezer {
    public static string[] LeesRegels(string bestandnaam, string foutbestand, List<Error> errors) {
        if (!File.Exists(bestandnaam)) {
            errors.Add(Error.Create(0, "", "Bestand bestaat niet"));
            Fout.SchrijfFoutbestand(foutbestand, errors);
            return Array.Empty<string>();
        }
        return File.ReadAllLines(bestandnaam);
    }
}
