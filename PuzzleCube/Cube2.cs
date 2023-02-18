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
        }
    }
}

