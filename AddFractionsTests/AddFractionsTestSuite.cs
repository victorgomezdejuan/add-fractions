using AddFractions;

namespace AddFractionsTests;

public class AddFractionsTestSuite {
    [Fact]
    public void AddNaturalNumbers() {
        Fraction augend = new(2);
        Fraction addend = new(1);
        Fraction expected = new(3);

        Fraction sum = augend.Plus(addend);

        Assert.Equal(expected, sum);
    }

    [Fact]
    public void EqualFractions() {
        Fraction augend = new(1, 3);
        Fraction addend = new(1, 3);

        Assert.Equal(augend, addend);
    }

    [Fact]
    public void DistinctNumerator() {
        Fraction augend = new(1, 3);
        Fraction addend = new(2, 3);

        Assert.NotEqual(augend, addend);
    }

    [Fact]
    public void DistinctDenominator() {
        Fraction augend = new(1, 3);
        Fraction addend = new(1, 2);

        Assert.NotEqual(augend, addend);
    }

    //[Fact]
    //public void SameDenominator() {
    //    Fraction augend = new(2, 5);
    //    Fraction addend = new(1, 5);
    //    Fraction expected = new(3, 5);

    //    Fraction sum = augend.Plus(addend);

    //    Assert.Equal(expected, sum);
    //}
}