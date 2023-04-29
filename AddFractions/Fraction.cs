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
        return new(Numerator + addend.Numerator);
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
