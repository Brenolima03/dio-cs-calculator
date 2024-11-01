// UnitTest1.cs
using Xunit;
using System;
using System.Collections.Generic;
using Calculator;

public class CalculatorTests
{
  [Theory]
  [InlineData(5, 3, 8)]
  [InlineData(0, 0, 0)]
  [InlineData(-5, 5, 0)]
  public void TestSum(int x, int y, int expected)
  {
    var calculator = new Calculator.Calculator();
    int result = calculator.sum(x, y);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(10, 4, 6)]
  [InlineData(0, 0, 0)]
  [InlineData(5, -5, 10)]
  public void TestSubtract(int x, int y, int expected)
  {
    var calculator = new Calculator.Calculator();
    int result = calculator.subtract(x, y);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(6, 7, 42)]
  [InlineData(0, 10, 0)]
  [InlineData(-3, -3, 9)]
  public void TestMultiply(int x, int y, int expected)
  {
    var calculator = new Calculator.Calculator();
    int result = calculator.multiply(x, y);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(10, 2, 5.0f)]
  [InlineData(9, 3, 3.0f)]
  [InlineData(-10, 2, -5.0f)]
  public void TestDivide(int x, int y, float expected)
  {
    var calculator = new Calculator.Calculator();
    float result = calculator.divide(x, y);
    Assert.Equal(expected, result);
  }

  [Fact]
  public void TestCannotDivideByZero()
  {
    var calculator = new Calculator.Calculator();
    Assert.Throws<DivideByZeroException>(() => calculator.divide(10, 0));
  }

  [Fact]
  public void TestHistory()
  {
    var calculator = new Calculator.Calculator();
    calculator.sum(1, 1);
    calculator.subtract(5, 2);
    calculator.multiply(2, 3);
    calculator.divide(8, 4);

    List<float> history = calculator.history();

    Assert.NotEmpty(history);
    Assert.Equal(3, history.Count);
  }
}
