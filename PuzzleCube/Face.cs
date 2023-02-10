using System;
namespace PuzzleCube
{
	public class Face
	{
		// Properties
		public int Side { get; set; }
		public int[,] Colors { get; set; }


		// Constructors
        public Face(int side, int color)
        {
			Side = side;
			Colors = new int[side, side];
			for(int row = 0; row < side; row++)
			{
				for (int col = 0; col < side; col++)
					Colors[row, col] = color;
			}
        }


		// Methods

		public int[] GetRow(int rowNumber)
		{
			int[] row = new int[Side];
			for(int column = 0; column < Side; column++)
			{
				row[column] = Colors[rowNumber, column];
			}
			return row;
		}

        public int[] GetColumn(int columnNumber)
        {
            int[] column = new int[Side];
            for (int row = 0; row < Side; row++)
            {
                column[row] = Colors[row, columnNumber];
            }
            return column;
        }

		public void AssignToColumn(int columnNumber, int[] column)
		{
			for(int row = 0; row < Side; row++)
			{
				Colors[row, columnNumber] = column[row];
			}
		}

		public void RotateFaceClockwise()
		{
			int[,] rotated = new int[Side, Side];
			for(int row = 0; row < Side; row++)
			{
				this.AssignToColumn(Side - row, GetRow(row));
			}

		}


    }
}

