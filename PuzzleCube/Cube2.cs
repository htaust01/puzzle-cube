using System;
namespace PuzzleCube
{
	public class Cube2 : BaseCube
	{
        public Cube2(int sideLength = 2) : base(sideLength)
        {
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
            this.Down.AssignArrayToColumn(this.SideLength - 1, this.Back.GetColumn(0));
            this.Back.AssignArrayToColumn(0, this.Up.GetColumn(this.SideLength - 1));
            this.Up.AssignArrayToColumn(this.SideLength - 1, temp);
            this.UpdatePreviousMoves("R");
        }

        public void TwistL()
        {
            this.Left.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Front.GetColumn(0);
            this.Front.AssignArrayToColumn(0, this.Up.GetColumn(0));
            this.Up.AssignArrayToColumn(0, this.Back.GetColumn(this.SideLength - 1));
            this.Back.AssignArrayToColumn(this.SideLength - 1, this.Down.GetColumn(0));
            this.Down.AssignArrayToColumn(0, temp);
            this.UpdatePreviousMoves("L");
        }

        public void TwistF()
        {
            this.Front.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Up.GetRow(this.SideLength - 1);
            this.Up.AssignArrayToRow(this.SideLength - 1, this.Left.GetColumn(this.SideLength - 1));
            this.Left.AssignArrayToColumn(this.SideLength - 1, this.Down.GetRow(0));
            this.Down.AssignArrayToRow(0, this.Right.GetColumn(0));
            this.Right.AssignArrayToColumn(0, temp);
            this.UpdatePreviousMoves("F");
        }

        public void TwistB()
        {
            this.Back.Rotate2DArray(1);
            int[] temp = new int[this.SideLength];
            temp = this.Up.GetRow(0);
            this.Up.AssignArrayToRow(0, this.Right.GetColumn(this.SideLength - 1));
            this.Right.AssignArrayToColumn(this.SideLength - 1, this.Down.GetRow(this.SideLength - 1));
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
            List<string> possibleMoves = new List<string> { "U", "D", "F", "B", "R", "L" };
            int lastIndex = rnd.Next(6);
            int nextIndex;
            for(int i = 0; i < numMoves; i++)
            {
                int numTwists = rnd.Next(3) + 1;
                switch (possibleMoves[lastIndex])
                {
                    case "U":
                        for(int j = 0; j < numTwists; j++)
                            this.TwistU();
                        break;
                    case "D":
                        for (int j = 0; j < numTwists; j++)
                            this.TwistD();
                        break;
                    case "F":
                        for (int j = 0; j < numTwists; j++)
                            this.TwistF();
                        break;
                    case "B":
                        for (int j = 0; j < numTwists; j++)
                            this.TwistB();
                        break;
                    case "R":
                        for (int j = 0; j < numTwists; j++)
                            this.TwistR();
                        break;
                    case "L":
                        for (int j = 0; j < numTwists; j++)
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
    }
}

