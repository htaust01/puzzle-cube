using System.Data.Common;
using System.Drawing;
using PuzzleCube;

internal class Program
{
    public static ConsoleColor initialBackgroundColor = Console.BackgroundColor;

    private static void Main(string[] args)
    {
        Banner();
        int cubeSize = GetCubeSize();
        TwistableCube cube = new TwistableCube(cubeSize);
        cube.RandomizeCube();
        Console.Clear();
        Display3D(cube);
        bool viewAs3DCube = true;
        bool cheatMode = false;
        string command;
        do
        {
            command = GetCommand();
            Console.Clear();
            switch (command)
            {
                case "V":
                    viewAs3DCube = !viewAs3DCube;
                    break;
                case "UUDDLRLRBASTART":
                    cheatMode = !cheatMode;
                    if (cheatMode)
                        Console.WriteLine("Cheat Mode Activated");
                    else
                        Console.WriteLine("Cheat Mode Deactivated");
                    Console.WriteLine();
                    break;
                default:
                    if (cube.IsValidSequence(command))
                        cube.ProcessSequence(command);
                    else
                    {
                        Console.WriteLine("Invalid Command");
                        Console.WriteLine();
                    }
                    break;
            }
            if (viewAs3DCube)
                Display3D(cube);
            else
                Display2D(cube);
            if (cheatMode && cube.PreviousMoves.Count > 0)
                cube.PrintPreviousMoves();
            if (cube.IsSolved())
            {
                Console.WriteLine("You have solved the Cube!");
                Console.WriteLine();
            }
        } while (command != "Q");
    }

    static void Banner()
    {
        Console.WriteLine("         Welcome to Puzzle Cube!!!");
        Console.WriteLine();
        Console.WriteLine("            ______ ______ ______");
        Console.WriteLine("          /      /      /      /\\");
        Console.WriteLine("         /      /      /      /  \\");
        Console.WriteLine("        /______/______/______/    \\");
        Console.WriteLine("       /      /      /      /\\    /\\");
        Console.WriteLine("      /      /      /      /  \\  /  \\");
        Console.WriteLine("     /______/______/______/    \\/    \\");
        Console.WriteLine("    /      /      /      /\\    /\\    /\\");
        Console.WriteLine("   /      /      /      /  \\  /  \\  /  \\");
        Console.WriteLine("  /______/______/______/    \\/    \\/    \\");
        Console.WriteLine("  \\      \\      \\      \\    /\\    /\\    /");
        Console.WriteLine("   \\      \\      \\      \\  /  \\  /  \\  /");
        Console.WriteLine("    \\______\\______\\______\\/    \\/    \\/");
        Console.WriteLine("     \\      \\      \\      \\    /\\    /");
        Console.WriteLine("      \\      \\      \\      \\  /  \\  /");
        Console.WriteLine("       \\______\\______\\______\\/    \\/");
        Console.WriteLine("        \\      \\      \\      \\    /");
        Console.WriteLine("         \\      \\      \\      \\  /");
        Console.WriteLine("          \\______\\______\\______\\/");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("           Press Enter to Play");
        Console.ReadLine();
    }

    static int GetCubeSize()
    {
        string[] possibleCubeSizes = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string cubeSize;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Enter a number between '1' and '9' to choose the size cube you would like to solve.");
            Console.WriteLine("For example enter '3' if you would like to play with a 3x3x3 cube");
            Console.WriteLine("Note: It is difficult to play with the larger sizes as they don't fit on the screen well");
            Console.Write("Size: ");
            cubeSize = Console.ReadLine()!;
            if (!possibleCubeSizes.Contains(cubeSize))
                Console.WriteLine("You have entered an invalid size");
        } while (!possibleCubeSizes.Contains(cubeSize));
        return int.Parse(cubeSize);
    }

    static string GetCommand()
    {
        Console.WriteLine("Enter 'X', 'Y', or 'Z' to rotate the cube clockwise around that axis");
        Console.WriteLine("Enter 'U', 'D', 'R', 'L', 'F', or 'B' to twist that face of the cube clockwise");
        Console.WriteLine("Followed by a number for which layer you would like to twist");
        Console.WriteLine("Enter 'Q' to stop playing.");
        Console.Write("Command: ");
        string command = Console.ReadLine()!;
        command = command.ToUpper();
        return command;
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
                            PrintFaceRow(cube.Back, row);
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
        Console.WriteLine();
    }

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
            // Adjust Spaces for the rows where the right face is printing the second length 4 section of a cell
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
        List<int[]> cells = GetCells(cube.SideLength, line);
        switch(line % 4)
        {
            case 1:
                for(int i = 0; i < cells.Count; i++)
                {
                    Console.BackgroundColor = GetColor(cube.Right[cells[i][0], cells[i][1]]);
                    Console.Write("  ");
                    Console.BackgroundColor = GetColor(0);
                    Console.Write("  ");
                }
                break;
            case 3:
                for (int i = 0; i < cells.Count; i++)
                {
                    Console.BackgroundColor = GetColor(cube.Right[cells[i][0], cells[i][1]]);
                    Console.Write("      ");
                    Console.BackgroundColor = GetColor(0);
                    Console.Write("  ");
                }
                break;
            default:
                for(int i = 0; i < cells.Count; i++)
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
        if(line % 4 == 1)
            cells = WeaveLists(GetDiagonalCells(SideLength, line), GetDiagonalCells(SideLength, line + 1));
        else
            cells = GetDiagonalCells(SideLength, line);
        return cells;
    }

    static List<int[]> GetDiagonalCells(int SideLength, int line)
    {
        List<int[]> cells = new List<int[]>();
        int diagonal = (line - 2) / 4 + 1;
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
            cells.Add(cell);
        }
        return cells;
    }

    static List<int[]> WeaveLists(List<int[]> list1, List<int[]> list2)
    {
        List<int[]> wovenList = new List<int[]>();
        if(list1.Count < list2.Count)
        {
            var temp = list1;
            list1 = list2;
            list2 = temp;
        }
        for (int j = 0; j < list2.Count; j++)
        {
            wovenList.Add(list1[j]);
            wovenList.Add(list2[j]);
        }
        wovenList.Add(list1[list1.Count - 1]);
        return wovenList;
    }

    static ConsoleColor GetColor(int i)
    {
        switch (i)
        {
            case 0: return initialBackgroundColor;
            case 1: return ConsoleColor.White;
            case 2: return ConsoleColor.DarkBlue;
            case 3: return ConsoleColor.Red;
            case 4: return ConsoleColor.DarkMagenta;
            case 5: return ConsoleColor.DarkGreen;
            case 6: return ConsoleColor.Yellow;
            default: throw new Exception("ERROR: Color out of bounds");
        }
    }
}