namespace AddFractions;
public class Fraction : Number {
    public int Numerator { get; init; }
    public int Denominator { get; init; }

    public Fraction(int numerator, int denominator) {
        Numerator = numerator;
        Denominator = denominator;
    }

    public Number Plus(Fraction addend) {
        (Fraction newAugend, Fraction newAddend) = PrepareFractionsForAddition(this, addend);

        return Reduce(new Fraction(newAugend.Numerator + newAddend.Numerator, newAugend.Denominator));
    }

    private static (Fraction, Fraction) PrepareFractionsForAddition(Fraction augend, Fraction addend) {
        if (augend.Denominator == addend.Denominator)
            return (augend.Clone(), addend.Clone());

        Fraction newAugend = new(augend.Numerator * addend.Denominator, augend.Denominator * addend.Denominator);
        Fraction newAddend = new(addend.Numerator * augend.Denominator, addend.Denominator * augend.Denominator);

        return (newAugend, newAddend);
    }

    private static Number Reduce(Fraction fraction) {
        if (fraction.Numerator % fraction.Denominator == 0)
            return new NaturalNumber(fraction.Numerator / fraction.Denominator);

        return ReduceToFraction(fraction);
    }

    private static Fraction ReduceToFraction(Fraction fraction) {
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

    private Fraction Clone() {
        return new Fraction(Numerator, Denominator);
    }
}