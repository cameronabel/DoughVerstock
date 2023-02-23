namespace DoughVerstock.Models;

public class Bread : Good
{
  public Bread() : this(1) { }
  public Bread(int quantity)
    : base("Bread", 5)
  {
    Quantity = quantity;
    BXGO = 2;
    if (Quantity > 1) { MultiLabel(); MultiPrice(); }
  }
}