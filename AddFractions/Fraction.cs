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
        int newNumerator = Numerator + addend.Numerator;
        int newDenominator = Denominator.Equals(addend.Denominator) ? Denominator : Denominator + addend.Denominator;

        int min = Math.Min(newNumerator, newDenominator);

        for (int i = min; i >= 2; i--) {
            while (newNumerator % i == 0 && newDenominator % i == 0) {
                newNumerator /= i;
                newDenominator /= i;
            }
        }

        return new(newNumerator, newDenominator);
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
