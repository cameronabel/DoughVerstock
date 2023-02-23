using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoughVerstock.Models;

namespace DoughVerstock.Tests;

[TestClass]
public class BreadTests
{
  [TestMethod]
  public void BreadConstructor_CreatesInstanceOfBread_Bread()
  {
    Bread testBread = new Bread(1);
    Assert.AreEqual(typeof(Bread), testBread.GetType());
  }
  [TestMethod]
  public void BreadConstructor_AssignsLabelField_Bread()
  {
    Bread testBread = new Bread(1);
    string result = testBread.Label;
    Assert.AreEqual("Bread", result);
  }
  [TestMethod]
  public void BreadConstructor_AssignsPriceField_Int()
  {
    Bread testBread = new Bread(1);
    int result = testBread.Price;
    Assert.AreEqual(5, result);
  }
  [TestMethod]
  public void BreadConstructor_AssignsQuantityField_Int()
  {
    Bread testBreads = new Bread(1);
    int result = testBreads.Quantity;
    Assert.AreEqual(1, result);
  }
  [TestMethod]
  public void BreadConstructor_AssignsMultiPriceField_Int()
  {
    Bread testBreads = new Bread(3);
    int result = testBreads.Price;
    Assert.AreEqual(10, result);
  }
  [TestMethod]
  public void BreadConstructor_AssignsMultiLabelField_String()
  {
    Bread testBreads = new Bread(3);
    string result = testBreads.Label;
    Assert.AreEqual(@" 3 x Bread @ 5 ea B2G1 DEAL", result);
  }
}