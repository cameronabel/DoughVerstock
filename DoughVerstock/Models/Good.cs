namespace DoughVerstock.Models;

public class Good
{
  public string Label { get; set; }
  public int Price { get; set; }
  public int Quantity { get; set; }
  public int BXGO { get; set; }
  private int _basePrice;
  private string _name;
  public void MultiLabel()
  {
    Label = $"{Quantity,2} x {_name} @ {_basePrice} ea";
    if (BXGO > 0 && Quantity > BXGO)
    {
      Label += $" B{BXGO}G1 DEAL";
    }
  }
  public void MultiPrice()
  {
    if (BXGO > 0)
    {
      int div = Quantity / (BXGO + 1);
      int mod = Quantity % (BXGO + 1);
      Price = _basePrice * BXGO * div + _basePrice * mod;
    }
  }
  public Good(string name, int basePrice)
  {
    Label = name;
    _name = name;
    _basePrice = basePrice;
    Price = basePrice;
    Quantity = 1;
  }
}