using BuildingBlocks.ValueObjects;

namespace zorgcentrumSolution.DomainTest; 
public class RRNTest {
    [Theory] // theory lists are AI generated
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("123")]
    [InlineData("85.07.30-033.AB")]
    [InlineData("85.07.30-033.99")]

    public void RRNCreate_OngeldigeInput(string input) {
        RRN? myRRN = RRN.Create(input);

        Assert.Null(myRRN);
    }

    [Theory]
    [InlineData("85.07.30-033.28")]
    [InlineData("85073003328")]
    public void RRNCreate_GeldigeInput(string input) {
        RRN? myRRN = RRN.Create(input);

        Assert.NotNull(myRRN); // checksum controle geslaagd een RRN wordt gemaakt (geen null)
        Assert.Equal("85073003328", myRRN.Waarde); // worden . en - juist uit RRN gehaald
    }

    [Theory]
    [InlineData("85.07.30-033.28")]   // geboren voor 2000
    [InlineData("00.01.01-001.05")]   // geboren vanaf 2000
    public void RRNCreate_GeldigeChecksum(string input) {
        RRN? myRRN = RRN.Create(input);

        Assert.NotNull(myRRN);
    }

    [Theory]
    [InlineData("85.07.30-033.29")]   // laatste cijfer 1 te hoog
    [InlineData("85.07.30-033.99")]   // totaal foute controle
    [InlineData("85.07.30-034.28")]   // volgnummer aangepast, controle niet
    public void RRNCreate_FouteChecksum(string input) {
        RRN? myRRN = RRN.Create(input);

        Assert.Null(myRRN);
    }
}
