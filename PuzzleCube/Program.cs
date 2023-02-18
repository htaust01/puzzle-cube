using System.Data.Common;
using System.Drawing;
using PuzzleCube;

internal class Program
{
    public static ConsoleColor initialBackgroundColor = Console.BackgroundColor;

    private static void Main(string[] args)
    {
        Cube2 cube = new Cube2(4);
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
            Console.BackgroundColor = GetColor(face[row, column]);
            Console.Write("      ");
            Console.BackgroundColor = GetColor(0);
            Console.Write("  ");
        }
    }

    static void Display3D(BaseCube cube)
    {
        int totalLines = cube.SideLength * 8 - 1;
        for (int line = 0; line < totalLines; line++)
        {
            PrintSpaces(line, totalLines);
            if((line + 1) % 4 != 0)
            {
                if (line < totalLines / 2)
                    PrintFaceRow(cube.Up, line / 4);
                else if (line > totalLines / 2)
                    PrintFaceRow(cube.Front, (line - 4 * cube.SideLength) / 4);
            }
            // Adjust Spaces for some rows
            if(line < totalLines / 2)
            {
                if(line % 4 == 0)
                    Console.Write("  ");
            }
            else
            {
                if ((line - 2) % 4 == 0)
                    Console.Write("  ");
            }

            PrintRightFace(cube, line);
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void PrintSpaces(int line, int totalLines)
    {
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

    static void PrintRightFace(BaseCube cube, int line)
    {
        if (line == 0 || line == (8 * cube.SideLength - 2))
            return;
        int totalLines = cube.SideLength * 8 - 1;
        int halfLine = totalLines / 2;
        int absDiff = Math.Abs(halfLine - line);
        int pointsToAdd = cube.SideLength;
        int cellsToPrint = 0;
        if(absDiff <= 2)
        {
            cellsToPrint += pointsToAdd;
        }
        absDiff -= 2;
        pointsToAdd--;
        while (absDiff >= 0)
        {
            if(absDiff <= 4)
            {
                cellsToPrint += pointsToAdd;
            }
            absDiff -= 4;
            pointsToAdd--;
        }
        List<int[]> cells = GetCells(cube.SideLength, line);
        switch(line % 4)
        {
            case 1:
                for(int i = 0; i < cellsToPrint; i++)
                {
                    Console.BackgroundColor = GetColor(cube.Right[cells[i][0], cells[i][1]]);
                    Console.Write("  ");
                    Console.BackgroundColor = GetColor(0);
                    Console.Write("  ");
                }
                break;
            case 3:
                for (int i = 0; i < cellsToPrint; i++)
                {
                    Console.BackgroundColor = GetColor(cube.Right[cells[i][0], cells[i][1]]);
                    Console.Write("      ");
                    Console.BackgroundColor = GetColor(0);
                    Console.Write("  ");
                }
                break;
            default:
                for(int i = 0; i < cellsToPrint; i++)
                {
                    Console.BackgroundColor = GetColor(cube.Right[cells[i][0], cells[i][1]]);
                    Console.Write("    ");
                    Console.BackgroundColor = GetColor(0);
                    Console.Write("    ");
                }
                break;
        }
    }

    static List<int[]> GetCells(int SideLength, int line)
    {
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
        int diagonal = (line - 2) / 4 + 1;
        if(line % 4 == 1)
        {
            // use same algorithm as below to make two lists then weave lists together
            List<int[]> cells1 = new List<int[]>();
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
                cells1.Add(cell);
            }
            diagonal++;
            List<int[]> cells2 = new List<int[]>();
            numOfCells = SideLength - Math.Abs(SideLength - diagonal);
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
                cells2.Add(cell);
            }
            if(cells1.Count > cells2.Count)
            {
                for(int j = 0; j < cells2.Count; j++)
                {
                    cells.Add(cells1[j]);
                    cells.Add(cells2[j]);
                }
                cells.Add(cells1[cells1.Count - 1]);
            }
            else
            {
                for (int j = 0; j < cells1.Count; j++)
                {
                    cells.Add(cells2[j]);
                    cells.Add(cells1[j]);
                }
                cells.Add(cells2[cells2.Count - 1]);
            }
        }
        else
        {
            int numOfCells = SideLength - Math.Abs(SideLength - diagonal);
            for(int i = 0; i < numOfCells; i++)
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
        }
        return cells;
    }

    static ConsoleColor GetColor(int i)
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