using PuzzleCube;

internal class Program
{
    private static void Main(string[] args)
    {
        BaseCube cube = new BaseCube(2);
        Console.WriteLine("Welcome to Puzzle Cube!!!");
        Console.WriteLine();
        Console.WriteLine("Press Enter to Play");
        Console.ReadLine();
        Console.Clear();
        drawCube(cube);
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
                    drawCube(cube);
                    break;
                case "y":
                    cube.RotateY();
                    drawCube(cube);
                    break;
                case "z":
                    cube.RotateZ();
                    drawCube(cube);
                    break;
                case "u":
                    cube.TwistU();
                    drawCube(cube);
                    break;
                case "d":
                    cube.TwistD();
                    drawCube(cube);
                    break;
                case "r":
                    cube.TwistR();
                    drawCube(cube);
                    break;
                case "l":
                    cube.TwistL();
                    drawCube(cube);
                    break;
                case "f":
                    cube.TwistF();
                    drawCube(cube);
                    break;
                case "b":
                    cube.TwistB();
                    drawCube(cube);
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Enter 'X', 'Y', or 'Z' to rotate the cube clockwise around that axis");
            Console.WriteLine("Enter 'U', 'D', 'R', 'L', 'F', or 'B' to twist that face of the cube clockwise");
            Console.WriteLine("Enter 'exit' to stop playing.");
            Console.Write("Command: ");
            input = Console.ReadLine();
            input = input.ToLower();
        }
        
    }

    static void drawCube(BaseCube cube)
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
        switch(i)
        {
            case 1:
                return ConsoleColor.White;
            case 2:
                return ConsoleColor.DarkGreen;
            case 3:
                return ConsoleColor.Red;
            case 4:
                return ConsoleColor.DarkMagenta;
            case 5:
                return ConsoleColor.DarkBlue;
            case 6:
                return ConsoleColor.Yellow;
            default:
                return ConsoleColor.Gray;
        }
    }

    static void colorCube()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("     _ _    ");
        Console.Write("   ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("/_/_");
        Console.BackgroundColor = ConsoleColor.White;
        //Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("/\\");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("   ");
        Console.Write("  ");
        Console.BackgroundColor = ConsoleColor.Red;
        //Console.ForegroundColor = ConsoleColor.White;
        Console.Write("/_/_");
        Console.BackgroundColor = ConsoleColor.White;
        //Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("/\\/\\");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("  ");
        Console.Write("  ");
        Console.BackgroundColor = ConsoleColor.Blue;
        //Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\\_\\_");
        Console.BackgroundColor = ConsoleColor.White;
        //Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("\\/\\/");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("  ");
        Console.Write("   ");
        Console.BackgroundColor = ConsoleColor.Blue;
        //Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\\_\\_");
        Console.BackgroundColor = ConsoleColor.White;
        //Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("\\/");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("   ");
        Console.WriteLine("            ");
        Console.WriteLine();
        Console.WriteLine();
        Console.ReadLine();
    }
}



//  
//  
//  
//  
//  
//  
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
//
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
//
//
//
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
//
//