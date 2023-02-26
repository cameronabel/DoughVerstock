using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoughVerstock.Models;
using System;

namespace DoughVerstock.Tests;

[TestClass]
public class OrderTests : IDisposable
{
  public void Dispose()
  {
    Order.ClearCounter();
  }
  Vendor testVendor;
  [TestInitialize]
  public void TestInitialize()
  {
    testVendor = new Vendor("Name", "Description");
  }

  [TestMethod]
  public void OrderConstructor_CreatesInstanceOfOrder_Order()
  {
    Order testOrder = new Order(1);
    Assert.AreEqual(typeof(Order), testOrder.GetType());
  }
  [TestMethod]
  public void OrderConstructor_Assigns_NextOrderNumber_Int()
  {
    Order testOrder = new Order(1);
    Assert.AreEqual(1, testOrder.ID);
  }
  [TestMethod]
  public void AddGood_AddsGoodToCart_UpdatedCart()
  {
    Order testOrder = new Order(1);
    Bread testBread = new Bread(1);
    testOrder.AddGood(testBread);
    Assert.AreEqual(1, testOrder.Cart.Count);
  }
  [TestMethod]
  public void StringReceipt_ReturnsStringReceipt_SingleGood()
  {
    Order testOrder = new Order(1);
    Bread testBread = new Bread(1);
    testOrder.AddGood(testBread);
    string expectedReceipt = $"    {"Bread",32}    {"5",4}    \n    {new string('─', 40)}    \n{"TOTAL: 5",44}    ";
    Assert.AreEqual(expectedReceipt, testOrder.StringReceipt());
  }
  [TestMethod]
  public void StringReceipt_ReturnsStringReceipt_MultipleGoods()
  {
    Order testOrder = new Order(1);
    Bread testBread = new Bread(1);
    Pastry testPastries = new Pastry(4);
    testOrder.AddGood(testBread);
    testOrder.AddGood(testPastries);
    string expectedReceipt = $"    {"Bread",32}    {"5",4}    \n    {" 4 x Pastry @ 2 ea B3G1 DEAL",32}    {"6",4}    \n    {new string('─', 40)}    \n{"TOTAL: 11",44}    ";
    Assert.AreEqual(expectedReceipt, testOrder.StringReceipt());
  }
  [TestMethod]
  public void StringReceipt_ReturnsStringReceipt_MultipleLines()
  {
    Order testOrder = new Order(1);
    Bread testBread = new Bread(1);
    Pastry testPastries = new Pastry(5);
    testOrder.AddGood(testBread);
    testOrder.AddGood(testPastries);
    string expectedReceipt = $"    {"Bread",32}    {"5",4}    \n    {" 4 x Pastry @ 2 ea B3G1 DEAL",32}    {"6",4}    \n    {"Pastry",32}    {"2",4}    \n    {new string('─', 40)}    \n{"TOTAL: 13",44}    ";
    Assert.AreEqual(expectedReceipt, testOrder.StringReceipt());
  }
  [TestMethod]
  public void ConfirmPrice_ProperlyCalculatesPrice_RegularPrice()
  {
    Order testOrder = new Order(1);
    Bread testBread = new Bread(2);
    testOrder.AddGood(testBread);
    string expectedReceipt = $"    {"Bread",32}    {"5",4}    \n    {"Bread",32}    {"5",4}    \n    {new string('─', 40)}    \n{"TOTAL: 10",44}    ";
    Assert.AreEqual(expectedReceipt, testOrder.StringReceipt());
  }
  [TestMethod]
  public void ConfirmPrice_ProperlyCalculatesPrice_BOGOPrice()
  {
    Order testOrder = new Order(1);
    Bread testBread = new Bread(2);
    Bread thirdBread = new Bread();
    testOrder.AddGood(testBread);
    testOrder.AddGood(thirdBread);
    string expectedReceipt = $"    {"Bread",32}    {"5",4}    \n    {"Bread",32}    {"5",4}    \n    {"Bread B2G1 DEAL",32}    {"0",4}    \n    {new string('─', 40)}    \n{"TOTAL: 10",44}    ";
    Assert.AreEqual(expectedReceipt, testOrder.StringReceipt());
  }
  [TestMethod]
  public void GetTotalPrice_EmptyOrderCostsZero_Zero()
  {
    Order testOrder = new Order(1);
    Assert.AreEqual(0, testOrder.GetTotalPrice());
  }
  [TestMethod]
  public void GetTotalPrice_TestOrderCalculatesCost_23()
  {
    Order testOrder = new Order(1);
    testOrder.AddGood(new Bread(3));
    testOrder.AddGood(new Bread());
    testOrder.AddGood(new Pastry(4));
    testOrder.AddGood(new Pastry());
    Assert.AreEqual(23, testOrder.GetTotalPrice());
  }
}