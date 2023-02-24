using System;
namespace PuzzleCube
{
	public class Cube2 : BaseCube
	{
        public Cube2(int sideLength = 2) : base(sideLength)
        {
            List<string> newMoves = new List<string> { "U", "D", "R", "L", "F", "B" };
            this.PossibleMoves.AddRange(newMoves);
        }

        public void TwistU()
        {
            this.Up.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetRow(0);
            this.Front.AssignArrayToRow(0, this.Right.GetRow(0));
            this.Right.AssignArrayToRow(0, this.Back.GetRow(0));
            this.Back.AssignArrayToRow(0, this.Left.GetRow(0));
            this.Left.AssignArrayToRow(0, temp);
            this.UpdatePreviousMoves("U");
        }

        public void TwistD()
        {
            this.Down.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetRow(SideLength - 1);
            this.Front.AssignArrayToRow(SideLength - 1, this.Left.GetRow(SideLength - 1));
            this.Left.AssignArrayToRow(SideLength - 1, this.Back.GetRow(SideLength - 1));
            this.Back.AssignArrayToRow(SideLength - 1, this.Right.GetRow(SideLength - 1));
            this.Right.AssignArrayToRow(SideLength - 1, temp);
            this.UpdatePreviousMoves("D");
        }

        public void TwistR()
        {
            this.Right.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetColumn(this.SideLength - 1);
            this.Front.AssignArrayToColumn(this.SideLength - 1, this.Down.GetColumn(this.SideLength - 1));
            this.Down.AssignArrayToColumn(this.SideLength - 1, this.Back.GetReverseColumn(0));
            this.Back.AssignArrayToColumn(0, this.Up.GetReverseColumn(this.SideLength - 1));
            this.Up.AssignArrayToColumn(this.SideLength - 1, temp);
            this.UpdatePreviousMoves("R");
        }

        public void TwistL()
        {
            this.Left.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetColumn(0);
            this.Front.AssignArrayToColumn(0, this.Up.GetColumn(0));
            this.Up.AssignArrayToColumn(0, this.Back.GetReverseColumn(this.SideLength - 1));
            this.Back.AssignArrayToColumn(this.SideLength - 1, this.Down.GetReverseColumn(0));
            this.Down.AssignArrayToColumn(0, temp);
            this.UpdatePreviousMoves("L");
        }

        public void TwistF()
        {
            this.Front.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Up.GetRow(this.SideLength - 1);
            this.Up.AssignArrayToRow(this.SideLength - 1, this.Left.GetReverseColumn(this.SideLength - 1));
            this.Left.AssignArrayToColumn(this.SideLength - 1, this.Down.GetRow(0));
            this.Down.AssignArrayToRow(0, this.Right.GetReverseColumn(0));
            this.Right.AssignArrayToColumn(0, temp);
            this.UpdatePreviousMoves("F");
        }

        public void TwistB()
        {
            this.Back.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Up.GetReverseRow(0);
            this.Up.AssignArrayToRow(0, this.Right.GetColumn(this.SideLength - 1));
            this.Right.AssignArrayToColumn(this.SideLength - 1, this.Down.GetReverseRow(this.SideLength - 1));
            this.Down.AssignArrayToRow(this.SideLength - 1, this.Left.GetColumn(0));
            this.Left.AssignArrayToColumn(0, temp);
            this.UpdatePreviousMoves("B");
        }

        public void PrintPreviousMoves()
        {
            for (int i = 0; i < this.PreviousMoves.Count; i++)
                Console.Write(this.PreviousMoves[i]);
            Console.WriteLine();
        }

        public void RandomizeCube()
        {
            Random rnd = new Random();
            int numMoves = (this.SideLength - 1) * 11 + rnd.Next(SideLength);
            List<string> twists = new List<string> { "U", "D", "F", "B", "R", "L" };
            int lastIndex = rnd.Next(6);
            int nextIndex;
            for(int i = 0; i < numMoves; i++)
            {
                int numberOfQuarterTurns = rnd.Next(3) + 1;
                switch (twists[lastIndex])
                {
                    case "U":
                        for(int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistU();
                        break;
                    case "D":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistD();
                        break;
                    case "F":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistF();
                        break;
                    case "B":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistB();
                        break;
                    case "R":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistR();
                        break;
                    case "L":
                        for (int j = 0; j < numberOfQuarterTurns; j++)
                            this.TwistL();
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
            for (int index = 0; index < sequence.Length; index++)
            {
                switch (sequence[index].ToString())
                {
                    case "X":
                        this.RotateX();
                        break;
                    case "Y":
                        this.RotateY();
                        break;
                    case "Z":
                        this.RotateZ();
                        break;
                    case "U":
                        this.TwistU();
                        break;
                    case "D":
                        this.TwistD();
                        break;
                    case "R":
                        this.TwistR();
                        break;
                    case "L":
                        this.TwistL();
                        break;
                    case "F":
                        this.TwistF();
                        break;
                    case "B":
                        this.TwistB();
                        break;
                    default:
                        throw new Exception("ERROR: Unkown Move");
                }
            }
        }
    }
}

