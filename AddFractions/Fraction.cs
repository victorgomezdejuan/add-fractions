namespace AddFractions;
public class Fraction {
    public int Numerator { get; init; }
    public int Denominator { get; init; }

    public Fraction(int number) {
        Numerator = number;
        Denominator = number;
    }

    public Fraction(int numerator, int denominator) {
        Numerator = numerator;
        Denominator = denominator;
    }

    public Fraction Plus(Fraction addend) {
        if (NaturalNumbers(this, addend))
            return new Fraction(Numerator + addend.Numerator);

        Tuple<Fraction, Fraction> tuple = PrepareFractionsForAddition(this, addend);
        Fraction newAugend = tuple.Item1;
        Fraction newAddend = tuple.Item2;

        int newNumerator = newAugend.Numerator + newAddend.Numerator;
        int newDenominator = newAugend.Denominator == newAddend.Denominator ? newAugend.Denominator : newAugend.Denominator + newAddend.Denominator;

        return Reduce(new Fraction(newNumerator, newDenominator));
    }

    private static bool NaturalNumbers(Fraction augend, Fraction addend)
        => augend.Numerator == augend.Denominator && addend.Numerator == addend.Denominator;

    private static Tuple<Fraction, Fraction> PrepareFractionsForAddition(Fraction augend, Fraction addend) {
        int augendNumerator = augend.Numerator;
        int augendDenominator = augend.Denominator;
        int addendNumerator = addend.Numerator;
        int addendDenominator = addend.Denominator;

        if (augend.Denominator != addend.Denominator) {
            augendNumerator *= addend.Denominator;
            augendDenominator *= addend.Denominator;
            addendNumerator *= augend.Denominator;
            addendDenominator *= augend.Denominator;
        }

        return new Tuple<Fraction, Fraction>(new Fraction(augendNumerator, augendDenominator), new Fraction(addendNumerator, addendDenominator));
    }

    private static Fraction Reduce(Fraction fraction) {
        int numerator = fraction.Numerator;
        int denominator = fraction.Denominator;
        int min = Math.Min(numerator, denominator);

        for (int i = min; i >= 2; i--) {
            while (numerator % i == 0 && denominator % i == 0) {
                numerator /= i;
                denominator /= i;
            }
        }

        return new Fraction(numerator, denominator);
    }

    private bool Equals(Fraction other) {
        return Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);
    }

    public override bool Equals(object? obj) {
        return obj is Fraction other && Equals(other);
    }

    public override int GetHashCode() {
        return Numerator.GetHashCode();
    }
}
