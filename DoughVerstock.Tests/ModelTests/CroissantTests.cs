using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoughVerstock.Models;

namespace DoughVerstock.Tests;

[TestClass]
public class CroissantTests
{
  [TestMethod]
  public void CroissantConstructor_CreatesInstanceOfCroissant_Croissant()
  {
    Croissant testCroissant = new Croissant(1);
    Assert.AreEqual(typeof(Croissant), testCroissant.GetType());
  }
  [TestMethod]
  public void CroissantConstructor_AssignsLabelField_Croissant()
  {
    Croissant testCroissant = new Croissant(1);
    string result = testCroissant.Label;
    Assert.AreEqual("Croissant", result);
  }
  [TestMethod]
  public void CroissantConstructor_AssignsPriceField_Int()
  {
    Croissant testCroissant = new Croissant(1);
    int result = testCroissant.Price;
    Assert.AreEqual(3, result);
  }
  [TestMethod]
  public void CroissantConstructor_AssignsQuantityField_Int()
  {
    Croissant testCroissants = new Croissant(1);
    int result = testCroissants.Quantity;
    Assert.AreEqual(1, result);
  }
  [TestMethod]
  public void CroissantConstructor_AssignsMultiPriceField_Int()
  {
    Croissant testCroissants = new Croissant(5);
    int result = testCroissants.Price;
    Assert.AreEqual(12, result);
  }
  [TestMethod]
  public void CroissantConstructor_AssignsMultiLabelField_String()
  {
    Croissant testCroissants = new Croissant(5);
    string result = testCroissants.Label;
    Assert.AreEqual(@" 5 x Croissant @ 3 ea B4G1 DEAL", result);
  }
}