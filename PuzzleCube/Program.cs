using System.Data.Common;
using System.Drawing;
using PuzzleCube;

internal class Program
{
    public static ConsoleColor initialBackgroundColor = Console.BackgroundColor;

    private static void Main(string[] args)
    {
        BaseCube cube = new BaseCube(2);
        bool viewAs3DCube = true;
        Console.WriteLine("Welcome to Puzzle Cube!!!");
        Console.WriteLine();
        Console.WriteLine("Press Enter to Play");
        Console.ReadLine();
        Console.Clear();
        Display3D(cube);
        Console.WriteLine("Enter 'X', 'Y', or 'Z' to rotate the cube clockwise around that axis");
        Console.WriteLine("Enter 'U', 'D', 'R', 'L', 'F', or 'B' to twist that face of the cube clockwise");
        Console.WriteLine("Enter 'exit' to stop playing.");
        Console.Write("Command: ");
        string input = Console.ReadLine();
        input = input.ToLower();
        while(input != "exit")
        {
            Console.Clear();
            switch(input)
            {
                case "x":
                    cube.RotateX();
                    break;
                case "y":
                    cube.RotateY();
                    break;
                case "z":
                    cube.RotateZ();
                    break;
                case "u":
                    cube.TwistU();
                    break;
                case "d":
                    cube.TwistD();
                    break;
                case "r":
                    cube.TwistR();
                    break;
                case "l":
                    cube.TwistL();
                    break;
                case "f":
                    cube.TwistF();
                    break;
                case "b":
                    cube.TwistB();
                    break;
                case "v":
                    viewAs3DCube = !viewAs3DCube;
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
            if (viewAs3DCube)
                Display3D(cube);
            else
                Display2D(cube);
            Console.WriteLine();
            if(cube.IsSolved())
            {
                Console.WriteLine("You have solved the Cube!");
                Console.WriteLine();
            }
            Console.WriteLine("Enter 'X', 'Y', or 'Z' to rotate the cube clockwise around that axis");
            Console.WriteLine("Enter 'U', 'D', 'R', 'L', 'F', or 'B' to twist that face of the cube clockwise");
            Console.WriteLine("Enter 'exit' to stop playing.");
            Console.Write("Command: ");
            input = Console.ReadLine();
            input = input.ToLower();
        }
        
    }

    static void Display2D(BaseCube cube)
    {
        int[,] blankFace = new int[cube.SideLength, cube.SideLength];
        for(int faceRow = 0; faceRow < 3; faceRow++)
        {
            for(int row = 0; row < cube.SideLength; row++)
            {
                for(int repeat = 0; repeat < 3; repeat++)
                {
                    switch (faceRow)
                    {
                        case 0:
                            PrintFaceRow(blankFace, row);
                            PrintFaceRow(cube.Up, row);
                            Console.WriteLine();
                            break;
                        case 1:
                            PrintFaceRow(cube.Left, row);
                            PrintFaceRow(cube.Front, row);
                            PrintFaceRow(cube.Right, row);
                            Console.WriteLine();
                            break;
                        case 2:
                            PrintFaceRow(blankFace, row);
                            PrintFaceRow(cube.Down, row);
                            Console.WriteLine();
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }

    // Display2D helper function
    static void PrintFaceRow(int[,] face, int row)
    {
        for(int column = 0; column < face.GetLength(1); column++)
        {
            Console.BackgroundColor = getColor(face[row, column]);
            Console.Write("      ");
            Console.BackgroundColor = getColor(0);
            Console.Write("  ");
        }
    }

    static void Display3D(BaseCube cube)
    {
        int[,] up = cube.Up;
        int[,] front = cube.Front;
        int[,] right = cube.Right;

        ConsoleColor initialBackgroundColor = Console.BackgroundColor;
        Console.WriteLine();
        Console.Write("      ");
        Console.BackgroundColor = getColor(up[0, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(up[0, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.WriteLine();
        Console.Write("     ");
        Console.BackgroundColor = getColor(up[0, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(up[0, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right1
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[0, 1]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        // end right1
        Console.WriteLine();
        Console.Write("    ");
        Console.BackgroundColor = getColor(up[0, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(up[0, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right2
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[0, 1]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        // end right2
        Console.WriteLine();
        // right3
        Console.Write("                   ");
        Console.BackgroundColor = getColor(right[0, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // end right3
        Console.WriteLine();
        Console.Write("  ");
        Console.BackgroundColor = getColor(up[1, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(up[1, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right4
        Console.Write("    ");
        Console.BackgroundColor = getColor(right[0, 1]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        //end right4
        Console.WriteLine();
        Console.Write(" ");
        Console.BackgroundColor = getColor(up[1, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(up[1, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right5
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[0, 0]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[0, 1]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[1, 1]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        //end right5
        Console.WriteLine();
        Console.Write("");
        Console.BackgroundColor = getColor(up[1, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(up[1, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right6
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[0, 0]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("    ");
        Console.BackgroundColor = getColor(right[1, 1]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        // end right6
        Console.WriteLine();
        // right7
        Console.Write("               ");
        Console.BackgroundColor = getColor(right[0, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[1, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        //end right7
        Console.WriteLine();
        Console.Write("");
        Console.BackgroundColor = getColor(front[0, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(front[0, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right8
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[0, 0]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("    ");
        Console.BackgroundColor = getColor(right[1, 1]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        //end right8
        Console.WriteLine();
        Console.Write(" ");
        Console.BackgroundColor = getColor(front[0, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(front[0, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right9
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[0, 0]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[1, 0]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[1, 1]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        // end right9
        Console.WriteLine();
        Console.Write("  ");
        Console.BackgroundColor = getColor(front[0, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(front[0, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right10
        Console.Write("    ");
        Console.BackgroundColor = getColor(right[1, 0]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        // end right10
        Console.WriteLine();
        // right11
        Console.Write("                   ");
        Console.BackgroundColor = getColor(right[1, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        //end right11
        Console.WriteLine();
        Console.Write("    ");
        Console.BackgroundColor = getColor(front[1, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(front[1, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right12
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[1, 0]);
        Console.Write("    ");
        Console.BackgroundColor = initialBackgroundColor;
        // end right12
        Console.WriteLine();
        Console.Write("     ");
        Console.BackgroundColor = getColor(front[1, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(front[1, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        // right13
        Console.Write("  ");
        Console.BackgroundColor = getColor(right[1, 0]);
        Console.Write("  ");
        Console.BackgroundColor = initialBackgroundColor;
        //end right13
        Console.WriteLine();
        Console.Write("      ");
        Console.BackgroundColor = getColor(front[1, 0]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write("  ");
        Console.BackgroundColor = getColor(front[1, 1]);
        Console.Write("      ");
        Console.BackgroundColor = initialBackgroundColor;
        Console.WriteLine();
        Console.WriteLine();
    }

    static ConsoleColor getColor(int i)
    {
        switch (i)
        {
            case 0:
                return initialBackgroundColor;
            case 1:
                return ConsoleColor.White;
            case 2:
                return ConsoleColor.DarkBlue;
            case 3:
                return ConsoleColor.Red;
            case 4:
                return ConsoleColor.DarkMagenta;
            case 5:
                return ConsoleColor.DarkGreen;
            case 6:
                return ConsoleColor.Yellow;
            default:
                return ConsoleColor.Gray;
        }
    }
}


//     _ _
//   /_/_/\
//  /_/_/\/\
//  \_\_\/\/
//   \_\_\/
//  
//         _____ _____
//       /     /     /\
//      /  W  /  W  /  \
//     /_____/_____/    \
//    / __  /     /\    /\
//   / /_/ /  W  /  \  /  \
//  /_____/_____/ /\ \/    \
//  \  __ \     \ \/ /\    /
//   \ \_\ \     \  /  \  /
//    \_____\_____\/    \/
//     \     \     \    /
//      \     \     \  /
//       \_____\_____\/
//
//         ______ ______
//       /      /      /\
//      /      /      /  \
//     /______/______/    \
//    /      /      /\    /\
//   /      /      /  \  /  \
//  /______/______/    \/    \
//  \      \      \    /\    /
//   \      \      \  /  \  /
//    \______\______\/    \/
//     \      \      \    /
//      \      \      \  /
//       \______\______\/
//
//            ______ ______ ______
//          /      /      /      /\
//         /      /      /      /  \
//        /______/______/______/    \
//       /      /      /      /\    /\
//      /      /      /      /  \  /  \
//     /______/______/______/    \/    \
//    /      /      /      /\    /\    /\
//   /      /      /      /  \  /  \  /  \
//  /______/______/______/    \/    \/    \
//  \      \      \      \    /\    /\    /
//   \      \      \      \  /  \  /  \  /
//    \______\______\______\/    \/    \/
//     \      \      \      \    /\    /
//      \      \      \      \  /  \  /
//       \______\______\______\/    \/
//        \      \      \      \    /
//         \      \      \      \  /
//          \______\______\______\/
//