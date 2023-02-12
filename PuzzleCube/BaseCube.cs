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

        public BaseCube(int sides)
		{
			this.SideLength = sides;
			Up = new int[,] { { 1, 1 }, { 1, 1 } };
            Down = new int[,] { { 6, 6 }, { 6, 6 } };
            Right = new int[,] { { 5, 5 }, { 5, 5 } };
            Left = new int[,] { { 2, 2 }, { 2, 2 } };
            Front = new int[,] { { 3, 3 }, { 3, 3 } };
            Back = new int[,] { { 4, 4 }, { 4, 4 } };
        }

        public void RotateX()
        {
            var temp = Up;
            Up = Front;
            Front = Down;
            Down = Back;
            Back = temp;
            int temp2 = Right[0, 0];
            Right[0, 0] = Right[1, 0];
            Right[1, 0] = Right[1, 1];
            Right[1, 1] = Right[0, 1];
            Right[0, 1] = temp2;
            temp2 = Left[0, 0];
            Left[0, 0] = Left[0, 1];
            Left[0, 1] = Left[1, 1];
            Left[1, 1] = Left[1, 0];
            Left[1, 0] = temp2;
        }

        public void RotateY()
        {
            var temp = Front;
            Front = Right;
            Right = Back;
            Back = Left;
            Left = temp;
            int temp2 = Up[0, 0];
            Up[0, 0] = Up[1, 0];
            Up[1, 0] = Up[1, 1];
            Up[1, 1] = Up[0, 1];
            Up[0, 1] = temp2;
            temp2 = Down[0, 0];
            Down[0, 0] = Down[0, 1];
            Down[0, 1] = Down[1, 1];
            Down[1, 1] = Down[1, 0];
            Down[1, 0] = temp2;
        }

        public void RotateZ()
        {
            var temp = Up;
            Up = Left;
            Left = Down;
            Down = Right;
            Right = temp;
            int temp2 = Front[0, 0];
            Front[0, 0] = Front[1, 0];
            Front[1, 0] = Front[1, 1];
            Front[1, 1] = Front[0, 1];
            Front[0, 1] = temp2;
            temp2 = Back[0, 0];
            Back[0, 0] = Back[0, 1];
            Back[0, 1] = Back[1, 1];
            Back[1, 1] = Back[1, 0];
            Back[1, 0] = temp2;
        }

        public void TwistU()
        {
            int temp = Up[0, 0];
            Up[0, 0] = Up[1, 0];
            Up[1, 0] = Up[1, 1];
            Up[1, 1] = Up[0, 1];
            Up[0, 1] = temp;
            temp = Front[0, 0];
            int temp2 = Front[0, 1];
            Front[0, 0] = Right[0, 0];
            Front[0, 1] = Right[0, 1];
            Right[0, 0] = Back[0, 0];
            Right[0, 1] = Back[0, 1];
            Back[0, 0] = Left[0, 0];
            Back[0, 1] = Left[0, 1];
            Left[0, 0] = temp;
            Left[0, 1] = temp2;
        }

        public void TwistD()
        {
            int temp = Down[0, 0];
            Down[0, 0] = Down[1, 0];
            Down[1, 0] = Down[1, 1];
            Down[1, 1] = Down[0, 1];
            Down[0, 1] = temp;
            temp = Front[1, 0];
            int temp2 = Front[1, 1];
            Front[1, 0] = Left[1, 0];
            Front[1, 1] = Left[1, 1];
            Left[1, 0] = Back[1, 0];
            Left[1, 1] = Back[1, 1];
            Back[1, 0] = Right[1, 0];
            Back[1, 1] = Right[1, 1];
            Right[1, 0] = temp;
            Right[1, 1] = temp2;
        }

        public void TwistR()
        {
            int temp = Right[0, 0];
            Right[0, 0] = Right[1, 0];
            Right[1, 0] = Right[1, 1];
            Right[1, 1] = Right[0, 1];
            Right[0, 1] = temp;
            temp = Front[0, 1];
            int temp2 = Front[1, 1];
            Front[0, 1] = Down[0, 1];
            Front[1, 1] = Down[1, 1];
            Down[0, 1] = Back[1, 0];
            Down[1, 1] = Back[0, 0];
            Back[1, 0] = Up[0, 1];
            Back[0, 0] = Up[1, 1];
            Up[0, 1] = temp;
            Up[1, 1] = temp2;
        }

        public void TwistL()
        {
            int temp = Left[0, 0];
            Left[0, 0] = Left[1, 0];
            Left[1, 0] = Left[1, 1];
            Left[1, 1] = Left[0, 1];
            Left[0, 1] = temp;
            temp = Front[0, 0];
            int temp2 = Front[1, 0];
            Front[0, 0] = Up[0, 0];
            Front[1, 0] = Up[1, 0];
            Up[0, 0] = Back[1, 1];
            Up[1, 0] = Back[0, 1];
            Back[1, 1] = Down[0, 0];
            Back[0, 1] = Down[1, 0];
            Down[0, 0] = temp;
            Down[1, 0] = temp2;
        }

        public void TwistF()
        {
            int temp = Front[0, 0];
            Front[0, 0] = Front[1, 0];
            Front[1, 0] = Front[1, 1];
            Front[1, 1] = Front[0, 1];
            Front[0, 1] = temp;
            temp = Up[1, 0];
            int temp2 = Up[1, 1];
            Up[1, 0] = Left[1, 1];
            Up[1, 1] = Left[0, 1];
            Left[1, 1] = Down[0, 1];
            Left[0, 1] = Down[0, 0];
            Down[0, 1] = Right[0, 0];
            Down[0, 0] = Right[1, 0];
            Right[0, 0] = temp;
            Right[1, 0] = temp2;
        }

        public void TwistB()
        {
            int temp = Back[0, 0];
            Back[0, 0] = Back[1, 0];
            Back[1, 0] = Back[1, 1];
            Back[1, 1] = Back[0, 1];
            Back[0, 1] = temp;
            temp = Up[0, 0];
            int temp2 = Up[0, 1];
            Up[0, 0] = Right[0, 1];
            Up[0, 1] = Right[1, 1];
            Right[0, 1] = Down[1, 1];
            Right[1, 1] = Down[1, 0];
            Down[1, 1] = Left[1, 0];
            Down[1, 0] = Left[0, 0];
            Left[1, 0] = temp;
            Left[0, 0] = temp2;
        }
    }
}

