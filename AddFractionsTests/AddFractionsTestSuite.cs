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
}