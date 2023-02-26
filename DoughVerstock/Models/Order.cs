namespace DoughVerstock.Models;

public class Order
{
  public List<Good> Cart { get; set; }
  public int ID { get; }
  public int Price { get; set; }
  public DateTime Date { get; }
  private static int _runningCounter = new int();
  public static SortedDictionary<int, Order> Database = new SortedDictionary<int, Order>() { };
  public int VendorID { get; set; }
  public Order(int vendorID)
  {
    _runningCounter++;
    ID = _runningCounter;
    Cart = new List<Good>() { };
    Price = 0;
    Date = DateTime.Now;
    Database[ID] = this;
    VendorID = vendorID;
    Vendor.Database[VendorID].Orders.Add(this);
  }
  public static void ClearCounter()
  {
    _runningCounter = 0;
  }
  private int ConfirmPrice(Good good)
  {
    int tally = Cart.Select(x => x.Quantity).Sum();
    int mod = tally % (good.BXGO + 1);
    if (mod == good.BXGO)
    {
      return 0;
    }
    else
    {
      return good.Price;
    }
  }
  public int GetTotalPrice() => Cart.Select(good => good.Price).Sum();
  public void AddGood(dynamic good)
  {
    if (good.Quantity == 1)
    {
      good.Price = ConfirmPrice(good);
      if (good.Price == 0)
      {
        good.Label += $" B{good.BXGO}G1 DEAL";
      }
      Cart.Add(good);
    }
    else
    {
      int div = good.Quantity / (good.BXGO + 1);
      int mod = good.Quantity % (good.BXGO + 1);
      if (div > 0)
      {
        good.Quantity = div * (good.BXGO + 1);
        good.MultiLabel();
        good.MultiPrice();
        Cart.Add(good);
      }
      Type T = good.GetType();
      for (int i = 0; i < mod; i++)
      {
        Object newGood = Activator.CreateInstance(T);
        AddGood(newGood);
      }
    }
  }
  public string StringReceipt()
  {
    string receipt = "";
    Price = 0;
    foreach (Good good in Cart)
    {
      receipt += $"    {good.Label,32}    {good.Price,4}    \n";
      Price += good.Price;
    }
    receipt += $"    {new string('─', 40)}    \n";
    receipt += $"{"TOTAL: " + Price.ToString(),44}    ";
    return receipt;
  }
}