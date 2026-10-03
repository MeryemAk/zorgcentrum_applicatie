using BuildingBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace zorgcentrumSolution.DomainTest; 
public class RIZIVTest {
    [Theory]
    [InlineData("1-23456-25-001")]
    [InlineData("12345625001")]
    [InlineData("1-00000-07-001")]
    [InlineData("1-54321-06-001")]

    public void RIZIVCreate_GeldigeInput(string input) {
        RIZIV? myRIZIV = RIZIV.Create(input);

        Assert.NotNull(myRIZIV); // geldige RIZIV wordt gecreeerd dus not null
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("1-23456-25")]       // te kort
    [InlineData("1-23456-25-0012")]  // te lang
    [InlineData("1-2345A-25-001")]   // letter
    public void RIZIVCreate_OngeldigeInput(string input) {
        RIZIV? myRIZIV = RIZIV.Create(input);

        Assert.Null(myRIZIV);
    }
}
