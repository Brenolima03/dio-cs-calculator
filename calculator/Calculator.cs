using System;
using System.Collections.Generic;

namespace Calculator
{
  public class Calculator
  {
    private List<float> _history = new List<float>();

    public int sum(int x, int y)
    {
      int result = x + y;
      AddToHistory(result);
      return result;
    }

    public int subtract(int x, int y)
    {
      int result = x - y;
      AddToHistory(result);
      return result;
    }

    public int multiply(int x, int y)
    {
      int result = x * y;
      AddToHistory(result);
      return result;
    }

    public float divide(int x, int y)
    {
      if (y == 0) throw new DivideByZeroException();
      float result = (float)x / y;
      AddToHistory(result);
      return result;
    }

    public List<float> history()
    {
      // Return up to the last 3 entries
      return _history.Count <= 3 ?
        new List<float>(_history) : _history.GetRange(_history.Count - 3, 3);
    }

    private void AddToHistory(float result)
    {
      // Add the result to history and maintain only the last 3 entries
      _history.Add(result);
      if (_history.Count > 3)
      {
        // Remove the oldest entry to keep only the last 3
        _history.RemoveAt(0);
      }
    }
  }
}
