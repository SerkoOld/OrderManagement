using System;
using System.Linq;

namespace Order.Management.Models
{
  // Generic Matrix class
  // This is for easy printing of the matrix
  public class Matrix<TRow, TColumn, TValue>
  {
    private readonly TValue[,] _data;
    public readonly TRow[] Rows;
    public readonly TColumn[] Columns;

    public Matrix(TRow[] rows, TColumn[] columns)
    {
      Rows = rows;
      Columns = columns;
      _data = new TValue[rows.Length, Columns.Length];
    }

    private TValue GetValue(TRow row, TColumn column)
    {
      checkIndex(row, column);
      return _data[Array.IndexOf(Rows, row), Array.IndexOf(Columns, column)];
    }

    private void SetValue(TRow row, TColumn column, TValue value)
    {
      checkIndex(row, column);
      _data[Array.IndexOf(Rows, row), Array.IndexOf(Columns, column)] = value;
    }

    private void checkIndex(TRow row, TColumn column)
    {
      if (!Rows.Contains(row))
      {
        throw new IndexOutOfRangeException($"Row {row} is not in the matrix");
      }
      if (!Columns.Contains(column))
      {
        throw new IndexOutOfRangeException($"Column {column} is not in the matrix");
      }
    }

    public TValue this[TRow row, TColumn column]
    {
      get => GetValue(row, column);
      set => SetValue(row, column, value);
    }
  }
}
