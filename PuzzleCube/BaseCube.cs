using System;
namespace PuzzleCube
{
    /// <summary>
    /// A simulation of a cube with a square 2D array on each face.
    /// The cube can be rotated about the x axis, the y axis, and the z axis
    /// and the faces will reorient themselves to how they should be.
    /// </summary>
	public class BaseCube
	{
        private static ConsoleColor initialBackgroundColor = Console.BackgroundColor;

        public int SideLength { get; set; }

		public int[,] Up { get; set; }
        public int[,] Down { get; set; }
        public int[,] Right { get; set; }
        public int[,] Left { get; set; }
        public int[,] Front { get; set; }
        public int[,] Back { get; set; }

        protected List<string> PossibleMoves { get; set; }
        public List<string> PreviousMoves { get; set; }

        public BaseCube(int sideLength)
		{
            if (sideLength < 1)
                throw new Exception("ERROR: sideLength can not be less than 1");
			this.SideLength = sideLength;
            this.Up = new int[sideLength, sideLength];
            this.Up.Fill2DArray(1);
            this.Down = new int[sideLength, sideLength];
            this.Down.Fill2DArray(6);
            this.Right = new int[sideLength, sideLength];
            this.Right.Fill2DArray(2);
            this.Left = new int[sideLength, sideLength];
            this.Left.Fill2DArray(5);
            this.Front = new int[sideLength, sideLength];
            this.Front.Fill2DArray(3);
            this.Back = new int[sideLength, sideLength];
            this.Back.Fill2DArray(4);
            this.PossibleMoves = new List<string> { "X", "Y", "Z" };
            this.PreviousMoves = new List<string>();
        }

        protected void RotateX()
        {
            var temp = Up;
            Up = Front;
            Front = Down;
            Down = Back;
            Back = temp;
            Back.Rotate2DArray(2);
            Down.Rotate2DArray(2);
            Right.Rotate2DArray(1);
            Left.Rotate2DArray(3);
            this.UpdatePreviousMoves("X");
        }

        protected void RotateY()
        {
            var temp = Front;
            Front = Right;
            Right = Back;
            Back = Left;
            Left = temp;
            Up.Rotate2DArray(1);
            Down.Rotate2DArray(3);
            this.UpdatePreviousMoves("Y");
        }

        protected void RotateZ()
        {
            var temp = Up;
            Up = Left;
            Left = Down;
            Down = Right;
            Right = temp;
            Up.Rotate2DArray(1);
            Left.Rotate2DArray(1);
            Down.Rotate2DArray(1);
            Right.Rotate2DArray(1);
            Front.Rotate2DArray(1);
            Back.Rotate2DArray(3);
            this.UpdatePreviousMoves("Z");
        }

        public bool IsSolved()
        {
            if (!Up.AllCellsEqual()) return false;
            if (!Down.AllCellsEqual()) return false;
            if (!Right.AllCellsEqual()) return false;
            if (!Left.AllCellsEqual()) return false;
            if (!Front.AllCellsEqual()) return false;
            if (!Back.AllCellsEqual()) return false;
            return true;
        }

        protected void UpdatePreviousMoves(string move)
        {
            if(this.IsSolved())
            {
                this.PreviousMoves.Clear();
                return;
            }
            int numMoves = this.PreviousMoves.Count;
            if (numMoves >= 3
                && move == this.PreviousMoves[numMoves - 1]
                && move == this.PreviousMoves[numMoves - 2]
                && move == this.PreviousMoves[numMoves - 3])
            {
                this.PreviousMoves.RemoveAt(numMoves - 1);
                this.PreviousMoves.RemoveAt(numMoves - 2);
                this.PreviousMoves.RemoveAt(numMoves - 3);
            }
            else
                this.PreviousMoves.Add(move);
        }

        public bool IsValidSequence(string sequence)
        {
            List<string> rotations = new List<string> { "X", "Y", "Z" };
            List<string> numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int index = 0;
            while (index < sequence.Length)
            {
                if (!this.PossibleMoves.Contains(sequence[index].ToString())) return false;
                index++;
                if (index < sequence.Length)
                {
                    if (numbers.Contains(sequence[index].ToString()))
                    {
                        int number = int.Parse(sequence[index].ToString());
                        if (rotations.Contains(sequence[index - 1].ToString()))
                        {
                            if (number < 1 || number > 3) return false;
                        }
                        else
                        {
                            if (number < 1 || number > this.SideLength) return false;
                        }
                        index++;
                    }
                }
            }
            return true;
        }

        public virtual void ProcessSequence(string sequence)
        {
            int index = 0;
            while (index < sequence.Length)
            {
                string move = sequence[index].ToString();
                index++;
                int totalQuarterTurns = 1;
                if (index < sequence.Length)
                {
                    if (int.TryParse(sequence[index].ToString(), out totalQuarterTurns)) index++;
                }
                switch (move)
                {
                    case "X":
                        for(int quarterTurn = 0; quarterTurn < totalQuarterTurns; quarterTurn++)
                            this.RotateX();
                        break;
                    case "Y":
                        for (int quarterTurn = 0; quarterTurn < totalQuarterTurns; quarterTurn++)
                            this.RotateY();
                        break;
                    case "Z":
                        for (int quarterTurn = 0; quarterTurn < totalQuarterTurns; quarterTurn++)
                            this.RotateZ();
                        break;
                    default:
                        throw new Exception("ERROR: Unkown Move");
                }
            }
        }

        public void Display2D()
        {// Displays the net of the cube like a sideways cross, each cell is 6 spaces horizontal and 3 vertical
            int[,] blankFace = new int[this.SideLength, this.SideLength];
            for (int faceRow = 0; faceRow < 3; faceRow++)
            {
                for (int row = 0; row < this.SideLength; row++)
                {
                    for (int repeat = 0; repeat < 3; repeat++)
                    {
                        switch (faceRow)
                        {
                            case 0:
                                PrintFaceRow(blankFace, row);
                                PrintFaceRow(this.Up, row);
                                Console.WriteLine();
                                break;
                            case 1:
                                PrintFaceRow(this.Left, row);
                                PrintFaceRow(this.Front, row);
                                PrintFaceRow(this.Right, row);
                                PrintFaceRow(this.Back, row);
                                Console.WriteLine();
                                break;
                            case 2:
                                PrintFaceRow(blankFace, row);
                                PrintFaceRow(this.Down, row);
                                Console.WriteLine();
                                break;
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        private void PrintFaceRow(int[,] face, int row)
        {// Helper function that prints one row of a face on a single line
            for (int column = 0; column < face.GetLength(1); column++)
            {
                Console.BackgroundColor = GetColor(face[row, column]);
                Console.Write("      ");
                Console.BackgroundColor = GetColor(0);
                Console.Write("  ");
            }
        }

        private ConsoleColor GetColor(int i)
        {
            switch (i)
            {
                case 0: return initialBackgroundColor;
                case 1: return ConsoleColor.White;
                case 2: return ConsoleColor.DarkBlue;
                case 3: return ConsoleColor.Red;
                case 4: return ConsoleColor.DarkMagenta;
                case 5: return ConsoleColor.DarkGreen;
                case 6: return ConsoleColor.Yellow;
                default: throw new Exception("ERROR: Color out of bounds");
            }
        }

        public void Display3D()
        {// Displays the cube as a 3D representation on a 2D screen
            int totalLines = this.SideLength * 8 - 1;
            for (int line = 0; line < totalLines; line++)
            {
                PrintSpacesFor3DView(line, totalLines);
                if ((line + 1) % 4 != 0)
                {
                    if (line < totalLines / 2)
                        PrintFaceRow(this.Up, line / 4);
                    else if (line > totalLines / 2)
                        PrintFaceRow(this.Front, (line - 4 * this.SideLength) / 4);
                }
                // Adjust Spaces for the rows where the right face is printing the second length 4 section of a cell
                if (line < totalLines / 2)
                {
                    if (line % 4 == 0)
                        Console.Write("  ");
                }
                else
                {
                    if ((line - 2) % 4 == 0)
                        Console.Write("  ");
                }
                PrintRightFace(line);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private void PrintSpacesFor3DView(int line, int totalLines)
        {// Adds the correct spaces at the beginning of a line to display 3D view of cube
            Console.BackgroundColor = GetColor(0);
            int numSpaces = Math.Abs(line - totalLines / 2);
            for (int i = 0; i < numSpaces; i++)
                Console.Write(" ");
            if (line == totalLines / 2 || (line + 1) % 4 == 0)
            {
                for (int i = 0; i < totalLines + 1; i++)
                    Console.Write(" ");
            }
        }

        private void PrintRightFace(int line)
        {// Writes on the line the cells of the right face of the cube
            if (line == 0 || line == (8 * this.SideLength - 2))
                return;
            List<int[]> cells = GetCellsOfRightFace(this.SideLength, line);
            switch (line % 4)
            {
                case 1:
                    for (int i = 0; i < cells.Count; i++)
                    {
                        Console.BackgroundColor = GetColor(this.Right[cells[i][0], cells[i][1]]);
                        Console.Write("  ");
                        Console.BackgroundColor = GetColor(0);
                        Console.Write("  ");
                    }
                    break;
                case 3:
                    for (int i = 0; i < cells.Count; i++)
                    {
                        Console.BackgroundColor = GetColor(this.Right[cells[i][0], cells[i][1]]);
                        Console.Write("      ");
                        Console.BackgroundColor = GetColor(0);
                        Console.Write("  ");
                    }
                    break;
                default:
                    for (int i = 0; i < cells.Count; i++)
                    {
                        Console.BackgroundColor = GetColor(this.Right[cells[i][0], cells[i][1]]);
                        Console.Write("    ");
                        Console.BackgroundColor = GetColor(0);
                        Console.Write("    ");
                    }
                    break;
            }
        }

        private List<int[]> GetCellsOfRightFace(int SideLength, int line)
        {// Finds the cells of the right face of the cube that are printed on the line
            List<int[]> cells = new List<int[]>();
            if (line == 1)
            {
                cells.Add(new int[] { 0, SideLength - 1 });
                return cells;
            }
            else if (line == SideLength * 8 - 3)
            {
                cells.Add(new int[] { SideLength - 1, 0 });
                return cells;
            }
            if (line % 4 == 1)
                cells = WeaveLists(GetDiagonalCells(SideLength, line), GetDiagonalCells(SideLength, line + 1));
            else
                cells = GetDiagonalCells(SideLength, line);
            return cells;
        }

        private List<int[]> GetDiagonalCells(int SideLength, int line)
        {// Determines which cells are on the the diagonal of the right face
            List<int[]> cells = new List<int[]>();
            int diagonal = (line - 2) / 4 + 1;
            int numOfCells = SideLength - Math.Abs(SideLength - diagonal);
            for (int i = 0; i < numOfCells; i++)
            {
                int[] cell = new int[2];
                if (diagonal <= SideLength)
                {
                    cell[0] = i;
                    cell[1] = SideLength - diagonal + i;
                }
                else
                {
                    cell[0] = diagonal - SideLength + i;
                    cell[1] = i;
                }
                cells.Add(cell);
            }
            return cells;
        }

        private List<int[]> WeaveLists(List<int[]> list1, List<int[]> list2)
        {// Combines two lists by alternating list items starting with the larger list
            List<int[]> wovenList = new List<int[]>();
            if (list1.Count < list2.Count)
            {
                var temp = list1;
                list1 = list2;
                list2 = temp;
            }
            for (int j = 0; j < list2.Count; j++)
            {
                wovenList.Add(list1[j]);
                wovenList.Add(list2[j]);
            }
            wovenList.Add(list1[list1.Count - 1]);
            return wovenList;
        }

    }
}

