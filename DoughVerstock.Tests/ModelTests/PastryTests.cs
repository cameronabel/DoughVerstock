using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoughVerstock.Models;

namespace DoughVerstock.Tests;

[TestClass]
public class PastryTests
{
  [TestMethod]
  public void PastryConstructor_CreatesInstanceOfPastry_Pastry()
  {
    Pastry testPastry = new Pastry(1);
    Assert.AreEqual(typeof(Pastry), testPastry.GetType());
  }
  [TestMethod]
  public void PastryConstructor_AssignsLabelField_Pastry()
  {
    Pastry testPastry = new Pastry(1);
    string result = testPastry.Label;
    Assert.AreEqual("Pastry", result);
  }
  [TestMethod]
  public void PastryConstructor_AssignsPriceField_Int()
  {
    Pastry testPastry = new Pastry(1);
    int result = testPastry.Price;
    Assert.AreEqual(2, result);
  }
  [TestMethod]
  public void PastryConstructor_AssignsQuantityField_Int()
  {
    Pastry testPastries = new Pastry(1);
    int result = testPastries.Quantity;
    Assert.AreEqual(1, result);
  }
  [TestMethod]
  public void PastryConstructor_AssignsMultiPriceField_Int()
  {
    Pastry testPastries = new Pastry(4);
    int result = testPastries.Price;
    Assert.AreEqual(6, result);
  }
  [TestMethod]
  public void PastryConstructor_AssignsMultiLabelField_String()
  {
    Pastry testPastries = new Pastry(4);
    string result = testPastries.Label;
    Assert.AreEqual(@" 4 x Pastry @ 2 ea B3G1 DEAL", result);
  }
}