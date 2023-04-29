namespace AddFractions;
public class NaturalNumber : Number {
    private int value;

    public NaturalNumber(int value) => this.value = value;

    public bool Equals(NaturalNumber other) => value == other.value;

    public override bool Equals(object? obj) => obj is NaturalNumber other && Equals(other);
}
