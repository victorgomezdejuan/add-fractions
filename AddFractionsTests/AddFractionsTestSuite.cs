using AddFractions;

namespace AddFractionsTests;

public class AddFractionsTestSuite {
    [Fact]
    public void Equals_SameFraction() {
        Fraction augend = new(1, 3);
        Fraction addend = new(1, 3);

        Assert.Equal(augend, addend);
    }

    [Fact]
    public void Equals_DistinctNumerator() {
        Fraction augend = new(1, 3);
        Fraction addend = new(2, 3);

        Assert.NotEqual(augend, addend);
    }

    [Fact]
    public void Equals_DistinctDenominator() {
        Fraction augend = new(1, 3);
        Fraction addend = new(1, 2);

        Assert.NotEqual(augend, addend);
    }

    [Fact]
    public void Addition_SameDenominator() {
        Fraction augend = new(2, 5);
        Fraction addend = new(1, 5);
        Fraction expected = new(3, 5);

        Number sum = augend.Plus(addend);

        Assert.Equal(expected, sum);
    }

    [Fact]
    public void Addition_SameDenominatorWithReduction() {
        Fraction augend = new(1, 8);
        Fraction addend = new(3, 8);
        Fraction expected = new(1, 2);

        Number sum = augend.Plus(addend);

        Assert.Equal(expected, sum);
    }

    [Fact]
    public void Addition_DifferentDenominator() {
        Fraction augend = new(1, 2);
        Fraction addend = new(1, 3);
        Fraction expected = new(5, 6);

        Number sum = augend.Plus(addend);

        Assert.Equal(expected, sum);
    }

    [Fact]
    public void Addition_ResultNaturalNumber2() {
        Fraction augend = new(3, 2);
        Fraction addend = new(1, 2);
        NaturalNumber expected = new(2);

        Number sum = augend.Plus(addend);

        Assert.Equal(expected, sum);
    }
}