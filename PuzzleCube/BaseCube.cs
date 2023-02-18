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

        public BaseCube(int sideLength)
		{
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

        //public void TwistU()
        //{
        //    int temp = Up[0, 0];
        //    Up[0, 0] = Up[1, 0];
        //    Up[1, 0] = Up[1, 1];
        //    Up[1, 1] = Up[0, 1];
        //    Up[0, 1] = temp;
        //    temp = Front[0, 0];
        //    int temp2 = Front[0, 1];
        //    Front[0, 0] = Right[0, 0];
        //    Front[0, 1] = Right[0, 1];
        //    Right[0, 0] = Back[0, 0];
        //    Right[0, 1] = Back[0, 1];
        //    Back[0, 0] = Left[0, 0];
        //    Back[0, 1] = Left[0, 1];
        //    Left[0, 0] = temp;
        //    Left[0, 1] = temp2;
        //}

        //public void TwistD()
        //{
        //    int temp = Down[0, 0];
        //    Down[0, 0] = Down[1, 0];
        //    Down[1, 0] = Down[1, 1];
        //    Down[1, 1] = Down[0, 1];
        //    Down[0, 1] = temp;
        //    temp = Front[1, 0];
        //    int temp2 = Front[1, 1];
        //    Front[1, 0] = Left[1, 0];
        //    Front[1, 1] = Left[1, 1];
        //    Left[1, 0] = Back[1, 0];
        //    Left[1, 1] = Back[1, 1];
        //    Back[1, 0] = Right[1, 0];
        //    Back[1, 1] = Right[1, 1];
        //    Right[1, 0] = temp;
        //    Right[1, 1] = temp2;
        //}

        //public void TwistR()
        //{
        //    int temp = Right[0, 0];
        //    Right[0, 0] = Right[1, 0];
        //    Right[1, 0] = Right[1, 1];
        //    Right[1, 1] = Right[0, 1];
        //    Right[0, 1] = temp;
        //    temp = Front[0, 1];
        //    int temp2 = Front[1, 1];
        //    Front[0, 1] = Down[0, 1];
        //    Front[1, 1] = Down[1, 1];
        //    Down[0, 1] = Back[1, 0];
        //    Down[1, 1] = Back[0, 0];
        //    Back[1, 0] = Up[0, 1];
        //    Back[0, 0] = Up[1, 1];
        //    Up[0, 1] = temp;
        //    Up[1, 1] = temp2;
        //}

        //public void TwistL()
        //{
        //    int temp = Left[0, 0];
        //    Left[0, 0] = Left[1, 0];
        //    Left[1, 0] = Left[1, 1];
        //    Left[1, 1] = Left[0, 1];
        //    Left[0, 1] = temp;
        //    temp = Front[0, 0];
        //    int temp2 = Front[1, 0];
        //    Front[0, 0] = Up[0, 0];
        //    Front[1, 0] = Up[1, 0];
        //    Up[0, 0] = Back[1, 1];
        //    Up[1, 0] = Back[0, 1];
        //    Back[1, 1] = Down[0, 0];
        //    Back[0, 1] = Down[1, 0];
        //    Down[0, 0] = temp;
        //    Down[1, 0] = temp2;
        //}

        //public void TwistF()
        //{
        //    int temp = Front[0, 0];
        //    Front[0, 0] = Front[1, 0];
        //    Front[1, 0] = Front[1, 1];
        //    Front[1, 1] = Front[0, 1];
        //    Front[0, 1] = temp;
        //    temp = Up[1, 0];
        //    int temp2 = Up[1, 1];
        //    Up[1, 0] = Left[1, 1];
        //    Up[1, 1] = Left[0, 1];
        //    Left[1, 1] = Down[0, 1];
        //    Left[0, 1] = Down[0, 0];
        //    Down[0, 1] = Right[0, 0];
        //    Down[0, 0] = Right[1, 0];
        //    Right[0, 0] = temp;
        //    Right[1, 0] = temp2;
        //}

        //public void TwistB()
        //{
        //    int temp = Back[0, 0];
        //    Back[0, 0] = Back[1, 0];
        //    Back[1, 0] = Back[1, 1];
        //    Back[1, 1] = Back[0, 1];
        //    Back[0, 1] = temp;
        //    temp = Up[0, 0];
        //    int temp2 = Up[0, 1];
        //    Up[0, 0] = Right[0, 1];
        //    Up[0, 1] = Right[1, 1];
        //    Right[0, 1] = Down[1, 1];
        //    Right[1, 1] = Down[1, 0];
        //    Down[1, 1] = Left[1, 0];
        //    Down[1, 0] = Left[0, 0];
        //    Left[1, 0] = temp;
        //    Left[0, 0] = temp2;
        //}
    }
}

