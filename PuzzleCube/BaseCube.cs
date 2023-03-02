using System;
namespace PuzzleCube
{
	public class BaseCube
	{
		public int SideLength { get; set; }

		public int[,] Up { get; set; }
        public int[,] Down { get; set; }
        public int[,] Right { get; set; }
        public int[,] Left { get; set; }
        public int[,] Front { get; set; }
        public int[,] Back { get; set; }

        public List<string> PossibleMoves { get; set; }
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

        public void RotateX()
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

        public void RotateY()
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

        public void RotateZ()
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
            if (!Up.AllCellsEqual())
                return false;
            if (!Down.AllCellsEqual())
                return false;
            if (!Right.AllCellsEqual())
                return false;
            if (!Left.AllCellsEqual())
                return false;
            if (!Front.AllCellsEqual())
                return false;
            if (!Back.AllCellsEqual())
                return false;
            return true;
        }

        public void UpdatePreviousMoves(string move)
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
                if (!this.PossibleMoves.Contains(sequence[index].ToString()))
                {
                    return false;
                }
                index++;
                if (index < sequence.Length)
                {
                    if (numbers.Contains(sequence[index].ToString()))
                    {
                        int number = int.Parse(sequence[index].ToString());
                        if (rotations.Contains(sequence[index - 1].ToString()))
                        {
                            if (number < 1 || number > 3)
                                return false;
                        }
                        else
                        {
                            if (number < 1 || number > this.SideLength)
                                return false;
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
                    if (int.TryParse(sequence[index].ToString(), out totalQuarterTurns))
                        index++;
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

        // Need to do research on whether a class method can return an object of said class
        //public void SaveCubeToFile()
        //{

        //}
    }
}

