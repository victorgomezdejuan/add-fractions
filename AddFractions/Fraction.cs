namespace AddFractions;
public class Fraction {
    public int Number { get; init; }

    public Fraction(int number) {
        Number = number;
    }

    public Fraction Plus(Fraction addend) {
        return new(Number + addend.Number);
    }

    private bool Equals(Fraction other) {
        return Number.Equals(other.Number);
    }

    public override bool Equals(object? obj) {
        return obj is Fraction other && Equals(other);
    }

    public override int GetHashCode() {
        return Number.GetHashCode();
    }
}
