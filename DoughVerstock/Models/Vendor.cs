namespace DoughVerstock.Models
{
  public class Vendor
  {
    public string Name { get; set; }
    public int ID { get; }
    private static int _runningCounter = 1;
    public string Description { get; set; }
    public List<Order> Orders { get; }
    public static SortedDictionary<int, Vendor> Database = new SortedDictionary<int, Vendor>() { };
    public Vendor(string name, string description)
    {
      Name = name;
      ID = _runningCounter;
      _runningCounter++;
      Description = description;
      Orders = new List<Order>() { };
      Database[ID] = this;
    }
  }
}