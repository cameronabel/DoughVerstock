namespace DoughVerstock.Models;

public class Croissant : Good
{
  public Croissant() : this(1) { }
  public Croissant(int quantity)
    : base("Croissant", 5)
  {
    Quantity = quantity;
    BXGO = 2;
    if (Quantity > 1) { MultiLabel(); MultiPrice(); }
  }
}