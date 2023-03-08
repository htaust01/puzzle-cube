using System;
namespace PuzzleCube
{
	public static class TwoDimensionalArrayExtensionMethods
	{
        /// <summary>
        /// Returns the row at rowIndex of array2D as an array
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="rowIndex">the index of the row to be returned</param>
        /// <returns>an int array with the values of the row</returns>
        public static int[] GetRow(this int[,] array2D, int rowIndex)
		{
			int[] row = new int[array2D.GetLength(0)];
			for (int column = 0; column < array2D.GetLength(0); column++)
				row[column] = array2D[rowIndex, column];
			return row;
		}

        /// <summary>
        /// Returns the reversed row at rowIndex of array2D as an array
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="rowIndex">the index of the row to be returned in reverse</param>
        /// <returns>an int array with the values of the row in reverse</returns>
        public static int[] GetReverseRow(this int[,] array2D, int rowIndex)
        {
            int[] row = new int[array2D.GetLength(0)];
            for (int column = 0; column < array2D.GetLength(0); column++)
                row[column] = array2D[rowIndex, column];
			Array.Reverse(row);
            return row;
        }

        /// <summary>
        /// Returns the column at columnIndex of array2D as an array
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="columnIndex">the index of the column to be returned</param>
        /// <returns>an int array with the values of the column</returns>
        public static int[] GetColumn(this int[,] array2D, int columnIndex)
		{
			int[] column = new int[array2D.GetLength(1)];
			for (int row = 0; row < array2D.GetLength(1); row++)
				column[row] = array2D[row, columnIndex];
			return column;
		}

        /// <summary>
        /// Returns the reversed column at columnIndex of array2D as an array
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="columnIndex">the index of the column to be returned in reverse</param>
        /// <returns>an int array with the values of the column in reverse</returns>
        public static int[] GetReverseColumn(this int[,] array2D, int columnIndex)
        {
            int[] column = new int[array2D.GetLength(1)];
            for (int row = 0; row < array2D.GetLength(1); row++)
                column[row] = array2D[row, columnIndex];
			Array.Reverse(column);
            return column;
        }

        /// <summary>
        /// Assigns arrayToAssign to the column at columnIndex of array2D
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="columnIndex">the index of the column to be reassigned</param>
        /// <param name="arrayToAssign">an int array that will be assigned to the column</param>
        public static void AssignArrayToColumn(this int[,] array2D, int columnIndex, int[] arrayToAssign)
		{
            if (array2D.GetLength(1) != arrayToAssign.Length)
                throw new Exception("ERROR: The array is not the correct length for the column");
            for (int row = 0; row < array2D.GetLength(0); row++)
				array2D[row, columnIndex] = arrayToAssign[row];
		}

        /// <summary>
        /// Assigns arrayToAssign to the row at rowIndex of array2D
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="rowIndex">the index of the row to be reassigned</param>
        /// <param name="arrayToAssign">an int array that will be assigned to the row</param>
        public static void AssignArrayToRow(this int[,] array2D, int rowIndex, int[] arrayToAssign)
		{
			if (array2D.GetLength(0) != arrayToAssign.Length)
				throw new Exception("ERROR: The array is not the correct length for the row");
			for (int column = 0; column < array2D.GetLength(1); column++)
				array2D[rowIndex, column] = arrayToAssign[column];
		}

        /// <summary>
        /// Rotates the square array2D a quarter turn clockwise quarterTurns number of times
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="quarterTurns">the number of quaterTurns to rotate the 2D array</param>
        public static void Rotate2DArray(this int[,] array2D, int quarterTurns)
		{
			if (array2D.GetLength(0) != array2D.GetLength(1))
				throw new Exception("ERROR: The 2D array is not square");
			int[,] newArr = new int[array2D.GetLength(1), array2D.GetLength(0)];
			for(int quarterRotations = 0; quarterRotations < quarterTurns; quarterRotations++)
			{
				int columnIndex;
				for(int row = 0; row < array2D.GetLength(0); row++)
				{
					columnIndex = newArr.GetLength(1) - 1 - row;
					newArr.AssignArrayToColumn(columnIndex, array2D.GetRow(row));
				}
				for (int row = 0; row < array2D.GetLength(0); row++)
					array2D.AssignArrayToRow(row, newArr.GetRow(row));
			}
		}

        /// <summary>
        /// Assigns fillValue to each cell in array2D
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <param name="fillValue">the value that will be assigned to every cell of the 2D array</param>
        public static void Fill2DArray(this int[,] array2D, int fillValue)
		{
			for(int row = 0; row < array2D.GetLength(0); row++)
			{
				for (int column = 0; column < array2D.GetLength(1); column++)
					array2D[row, column] = fillValue;
			}
		}

        /// <summary>
        /// Returns true if all cells have the same value, otherwise returns false
        /// </summary>
        /// <param name="array2D">the 2D array to act on</param>
        /// <returns> a bool that is true if all cells are equal and false otherwise</returns>
        public static bool AllCellsEqual(this int[,] array2D)
		{
			int cellValue = array2D[0, 0];
			for(int row = 0; row < array2D.GetLength(0); row++)
			{
				for(int column = 0; column < array2D.GetLength(1); column++)
				{
					if (array2D[row, column] != cellValue)
						return false;
				}
			}
			return true;
		}
	}
}

