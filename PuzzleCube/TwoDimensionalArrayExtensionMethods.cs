using System;
namespace PuzzleCube
{
	public static class TwoDimensionalArrayExtensionMethods
	{
		/// <summary>
		/// Returns the row at rowIndex of the 2d array as an array
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		public static int[] GetRow(this int[,] arr, int rowIndex)
		{
			int[] row = new int[arr.GetLength(0)];
			for (int column = 0; column < arr.GetLength(0); column++)
				row[column] = arr[rowIndex, column];
			return row;
		}


		/// <summary>
		/// Returns the column at columnIndex of the 2d array as an array
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="columnIndex"></param>
		/// <returns></returns>
		public static int[] GetColumn(this int[,] arr, int columnIndex)
		{
			int[] column = new int[arr.GetLength(1)];
			for (int row = 0; row < arr.GetLength(1); row++)
				column[row] = arr[row, columnIndex];
			return column;
		}

		/// <summary>
		/// Assigns arrayToAssign to the column at columnIndex of the 2d array
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="columnIndex"></param>
		/// <param name="arrayToAssign"></param>
		public static void AssignArrayToColumn(this int[,] arr, int columnIndex, int[] arrayToAssign)
		{
			for (int row = 0; row < arr.GetLength(0); row++)
				arr[row, columnIndex] = arrayToAssign[row];
		}

		/// <summary>
		/// Assigns arrayToAssign to the row at rowIndex of the 2d array
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="rowIndex"></param>
		/// <param name="arrayToAssign"></param>
		public static void AssignArrayToRow(this int[,] arr, int rowIndex, int[] arrayToAssign)
		{
			for (int column = 0; column < arr.GetLength(1); column++)
				arr[rowIndex, column] = arrayToAssign[column];
		}

		/// <summary>
		/// Rotates the 2D array arr a quarter turn clockwise quarterTurns number of times
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="quarterTurns"></param>
		public static void Rotate2DArray(this int[,] arr, int quarterTurns)
		{
			int[,] newArr = new int[arr.GetLength(1), arr.GetLength(0)];
			for(int quarterRotations = 0; quarterRotations < quarterTurns; quarterRotations++)
			{
				int columnIndex;
				for(int row = 0; row < arr.GetLength(0); row++)
				{
					columnIndex = newArr.GetLength(1) - 1 - row;
					newArr.AssignArrayToColumn(columnIndex, arr.GetRow(row));
				}
				for (int row = 0; row < arr.GetLength(0); row++)
					arr.AssignArrayToRow(row, newArr.GetRow(row));
			}
		}

		/// <summary>
		/// Assigns fillValue to each cell in the 2D array arr
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="fillValue"></param>
		public static void Fill2DArray(this int[,] arr, int fillValue)
		{
			for(int row = 0; row < arr.GetLength(0); row++)
			{
				for (int column = 0; column < arr.GetLength(1); column++)
					arr[row, column] = fillValue;
			}
		}

		/// <summary>
		/// Returns true if all cells have the same value, otherwise returns false
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static bool AllCellsEqual(this int[,] arr)
		{
			int cellValue = arr[0, 0];
			for(int row = 0; row < arr.GetLength(0); row++)
			{
				for(int column = 0; column < arr.GetLength(1); column++)
				{
					if (arr[row, column] != cellValue)
						return false;
				}
			}
			return true;
		}
	}
}

