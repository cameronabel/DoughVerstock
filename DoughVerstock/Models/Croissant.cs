namespace DoughVerstock.Models;

public class Croissant : Good
{
  public Croissant() : this(1) { }
  public Croissant(int quantity)
    : base("Croissant", 3)
  {
    Quantity = quantity;
    BXGO = 4;
    if (Quantity > 1) { MultiLabel(); MultiPrice(); }
  }
}