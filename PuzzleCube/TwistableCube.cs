using System;
namespace PuzzleCube
{
	public class TwistableCube : BaseCube
	{
        public TwistableCube(int sideLength = 2) : base(sideLength)
        {
            List<string> newMoves = new List<string> { "U", "D", "R", "L", "F", "B" };
            this.PossibleMoves.AddRange(newMoves);
        }

        public void TwistUpSingleLayer(int n = 1)
        {
            if (n < 1 || n > this.SideLength)
                throw new Exception("ERROR: n is out of bounds");
            if(n == 1)
                this.Up.Rotate2DArray(1);
            if (n == this.SideLength)
                this.Down.Rotate2DArray(3);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetRow(n - 1);
            this.Front.AssignArrayToRow(n - 1, this.Right.GetRow(n - 1));
            this.Right.AssignArrayToRow(n - 1, this.Back.GetRow(n - 1));
            this.Back.AssignArrayToRow(n - 1, this.Left.GetRow(n - 1));
            this.Left.AssignArrayToRow(n - 1, temp);
            if (n == 1)
                this.UpdatePreviousMoves("U");
            else
                this.UpdatePreviousMoves($"U{n}");
        }

        public void TwistDownSingleLayer(int n = 1)
        {
            if (n < 1 || n > this.SideLength)
                throw new Exception("ERROR: n is out of bounds");
            if (n == 1)
                this.Down.Rotate2DArray(1);
            if (n == this.SideLength)
                this.Up.Rotate2DArray(3);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetRow(SideLength - n);
            this.Front.AssignArrayToRow(this.SideLength - n, this.Left.GetRow(this.SideLength - n));
            this.Left.AssignArrayToRow(this.SideLength - n, this.Back.GetRow(this.SideLength - n));
            this.Back.AssignArrayToRow(this.SideLength - n, this.Right.GetRow(this.SideLength - n));
            this.Right.AssignArrayToRow(this.SideLength - n, temp);
            if (n == 1)
                this.UpdatePreviousMoves("D");
            else
                this.UpdatePreviousMoves($"D{n}");
        }

        public void TwistRightSingleLayer(int n = 1)
        {
            if (n < 1 || n > this.SideLength)
                throw new Exception("ERROR: n is out of bounds");
            if (n == 1)
                this.Right.Rotate2DArray(1);
            if (n == this.SideLength)
                this.Left.Rotate2DArray(3);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetColumn(this.SideLength - n);
            this.Front.AssignArrayToColumn(this.SideLength - n, this.Down.GetColumn(this.SideLength - n));
            this.Down.AssignArrayToColumn(this.SideLength - n, this.Back.GetReverseColumn(n - 1));
            this.Back.AssignArrayToColumn(n - 1, this.Up.GetReverseColumn(this.SideLength - n));
            this.Up.AssignArrayToColumn(this.SideLength - n, temp);
            if (n == 1)
                this.UpdatePreviousMoves("R");
            else
                this.UpdatePreviousMoves($"R{n}");
        }

        public void TwistLeftSingleLayer(int n = 1)
        {
            if (n < 1 || n > this.SideLength)
                throw new Exception("ERROR: n is out of bounds");
            if (n == 1)
                this.Left.Rotate2DArray(1);
            if (n == this.SideLength)
                this.Right.Rotate2DArray(3);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetColumn(n - 1);
            this.Front.AssignArrayToColumn(n - 1, this.Up.GetColumn(n - 1));
            this.Up.AssignArrayToColumn(n - 1, this.Back.GetReverseColumn(this.SideLength - n));
            this.Back.AssignArrayToColumn(this.SideLength - n, this.Down.GetReverseColumn(n - 1));
            this.Down.AssignArrayToColumn(n - 1, temp);
            if (n == 1)
                this.UpdatePreviousMoves("L");
            else
                this.UpdatePreviousMoves($"L{n}");
        }

        public void TwistFrontSingleLayer(int n = 1)
        {
            if (n < 1 || n > this.SideLength)
                throw new Exception("ERROR: n is out of bounds");
            if (n == 1)
                this.Front.Rotate2DArray(1);
            if (n == this.SideLength)
                this.Back.Rotate2DArray(3);
            int[] temp = new int[this.SideLength];
            temp = this.Up.GetRow(this.SideLength - n);
            this.Up.AssignArrayToRow(this.SideLength - n, this.Left.GetReverseColumn(this.SideLength - n));
            this.Left.AssignArrayToColumn(this.SideLength - n, this.Down.GetRow(n - 1));
            this.Down.AssignArrayToRow(n - 1, this.Right.GetReverseColumn(n - 1));
            this.Right.AssignArrayToColumn(n - 1, temp);
            if (n == 1)
                this.UpdatePreviousMoves("F");
            else
                this.UpdatePreviousMoves($"F{n}");
        }

        public void TwistBackSingleLayer(int n = 1)
        {
            if (n < 1 || n > this.SideLength)
                throw new Exception("ERROR: n is out of bounds");
            if (n == 1)
                this.Back.Rotate2DArray(1);
            if (n == this.SideLength)
                this.Front.Rotate2DArray(3);
            int[] temp = new int[this.SideLength];
            temp = this.Up.GetReverseRow(n- 1);
            this.Up.AssignArrayToRow(n - 1, this.Right.GetColumn(this.SideLength - n));
            this.Right.AssignArrayToColumn(this.SideLength - n, this.Down.GetReverseRow(this.SideLength - n));
            this.Down.AssignArrayToRow(this.SideLength - n, this.Left.GetColumn(n - 1));
            this.Left.AssignArrayToColumn(n - 1, temp);
            if(n == 1)
                this.UpdatePreviousMoves("B");
            else
                this.UpdatePreviousMoves($"B{n}");
        }

        public void PrintPreviousMoves()
        {
            for (int i = 0; i < this.PreviousMoves.Count; i++)
                Console.Write(this.PreviousMoves[i]);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void RandomizeCube()
        {
            Random rnd = new Random();
            int numMoves = (this.SideLength - 1) * 11 + rnd.Next(this.SideLength);
            List<string> twists = new List<string> { "U", "D", "F", "B", "R", "L" };
            int lastIndex = rnd.Next(6);
            int nextIndex;
            for(int i = 0; i < numMoves; i++)
            {
                int numberOfQuarterTurns = rnd.Next(3) + 1;
                int randomLayer = rnd.Next(this.SideLength / 2) + 1;
                switch (twists[lastIndex])
                {
                    case "U":
                        for(int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistUpSingleLayer(randomLayer);
                        break;
                    case "D":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistDownSingleLayer(randomLayer);
                        break;
                    case "F":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistFrontSingleLayer(randomLayer);
                        break;
                    case "B":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistBackSingleLayer(randomLayer);
                        break;
                    case "R":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistRightSingleLayer(randomLayer);
                        break;
                    case "L":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistLeftSingleLayer(randomLayer);
                        break;
                    default:
                        throw new Exception("Randomize Error: Unknown Twist");
                }
                do
                {
                    nextIndex = rnd.Next(6);
                } while (nextIndex == lastIndex);
                lastIndex = nextIndex;
            }
        }

        public override void ProcessSequence(string sequence)
        {
            List<string> numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int index = 0;
            while (index < sequence.Length)
            {
                string move = sequence[index].ToString();
                index++;
                int number = 1;
                if (index < sequence.Length)
                {
                    if (numbers.Contains(sequence[index].ToString()))
                    {
                        if (int.TryParse(sequence[index].ToString(), out number))
                            index++;
                    }
                }
                switch (move)
                {
                    case "X":
                        for (int times = 0; times < number; times++)
                            this.RotateX();
                        break;
                    case "Y":
                        for (int times = 0; times < number; times++)
                            this.RotateY();
                        break;
                    case "Z":
                        for (int times = 0; times < number; times++)
                            this.RotateZ();
                        break;
                    case "U":
                        this.TwistUpSingleLayer(number);
                        break;
                    case "D":
                        this.TwistDownSingleLayer(number);
                        break;
                    case "R":
                        this.TwistRightSingleLayer(number);
                        break;
                    case "L":
                        this.TwistLeftSingleLayer(number);
                        break;
                    case "F":
                        this.TwistFrontSingleLayer(number);
                        break;
                    case "B":
                        this.TwistBackSingleLayer(number);
                        break;
                    default:
                        throw new Exception("ERROR: Unkown Move");
                }
            }
        }
    }
}

