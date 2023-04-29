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
        if (Numerator == Denominator && addend.Numerator == addend.Denominator)
            return new Fraction(Numerator + addend.Numerator);

        int numerator = Numerator;
        int denominator = Denominator;
        int addendNumerator = addend.Numerator;
        int addendDenominator = addend.Denominator;

        if (Denominator != addend.Denominator) {
            numerator *= addend.Denominator;
            denominator *= addend.Denominator;
            addendNumerator *= Denominator;
            addendDenominator *= Denominator;
        }

        int newNumerator = numerator + addendNumerator;
        int newDenominator = denominator.Equals(addendDenominator) ? denominator : denominator + addendDenominator;

        return Reduce(new Fraction(newNumerator, newDenominator));
    }

    private Fraction Reduce(Fraction fraction) {
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
