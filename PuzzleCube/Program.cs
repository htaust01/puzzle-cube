using System.Data.Common;
using System.Drawing;
using PuzzleCube;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    public static ConsoleColor initialBackgroundColor = Console.BackgroundColor;
    public static string[] exitStrings = { "Q", "QUIT", "EXIT" };

    private static void Main(string[] args)
    {
        
        WelcomeBanner();
        TwistableCube cube = new TwistableCube();
        while (true)
        {
            cube = MakePuzzleCube();
            PlayWithCube(cube);
        }
    }

    static void WelcomeBanner()
    {
        Console.WriteLine("         Welcome to Puzzle Cube!!!\n");
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
        Console.WriteLine("          \\______\\______\\______\\/\n\n");
        Console.Write("           Press Enter to Play");
        Console.ReadLine();
    }

    static TwistableCube MakePuzzleCube()
    {
        int cubeSize = GetCubeSize();
        TwistableCube cube = new TwistableCube(cubeSize);
        string fileName = $"cube{cubeSize.ToString()}.txt";
        if (File.Exists(fileName))
        {
            Console.Write("A saved cube of this size exists, would you like to restore this cube 'Y'/'N'? ");
            string loadFilePermission = Console.ReadLine()!;
            if (loadFilePermission.ToUpper() == "Y")
            {
                cube = LoadCubeFromFile(cubeSize);
                return cube;
            }
        }
        cube.RandomizeCube();
        return cube;
    }

    static int GetCubeSize()
    {
        string[] possibleCubeSizes = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string cubeSize;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Enter a number between '1' and '9' to choose the size cube you would like to solve.");
            Console.WriteLine("For example, enter '3' if you would like to play with a 3x3x3 cube.");
            Console.WriteLine("Note: It is difficult to play with the larger sizes as they don't fit on the screen well.");
            Console.WriteLine("Enter 'Q' to quit.");
            Console.Write("Size: ");
            cubeSize = Console.ReadLine()!;
            cubeSize = cubeSize.ToUpper();
            if (exitStrings.Contains(cubeSize))
                Environment.Exit(0);
            if (!possibleCubeSizes.Contains(cubeSize))
                Console.WriteLine("You have entered an invalid size");
        } while (!possibleCubeSizes.Contains(cubeSize));
        return int.Parse(cubeSize);
    }

    static string GetCommand()
    {
        Console.WriteLine("Enter 'X', 'Y', or 'Z' to rotate the cube clockwise a quarter turn around that axis.");
        Console.WriteLine("Enter 'U', 'D', 'R', 'L', 'F', or 'B' to twist that face of the cube clockwise a quarter turn");
        Console.WriteLine("Followed by a number corresponding to the layer you would like to twist.");
        Console.WriteLine("Enter 'MENU' to change cube size, 'HELP' for more information on the commands, or 'Q' to stop playing");
        Console.Write("Command: ");
        string command = Console.ReadLine()!;
        return command.ToUpper();
    }

    static void PlayWithCube(TwistableCube cube)
    {
        bool viewAs3DCube = true;
        bool cheatModeActive = false;
        string command = "";
        while (!exitStrings.Contains(command))
        {
            Console.Clear();
            if (viewAs3DCube)
                Display3D(cube);
            else
                Display2D(cube);
            if (cheatModeActive)
                cube.PrintPreviousMoves();
            if (cube.IsSolved())
                Console.WriteLine("You have solved the Cube!\n");
            command = GetCommand();
            if (exitStrings.Contains(command))
            {
                AskToSaveCube(cube);
                Environment.Exit(0);
            }
            if (command == "MENU")
            {
                AskToSaveCube(cube);
                Console.Clear();
                return;
            }
            if (command == "V")
                viewAs3DCube = !viewAs3DCube;
            else if (command == "UUDDLRLRBASTART")
                cheatModeActive = !cheatModeActive;
            else if (command == "HELP")
            {
                string helpText = System.IO.File.ReadAllText(@"../../../help.txt");
                Console.WriteLine(helpText);
                Console.ReadLine();
                Console.Clear();
            }
            else if (cube.IsValidSequence(command))
                cube.ProcessSequence(command);
            else
                Console.WriteLine("Invalid Command\n");
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
    {// Helper function that prints one row of a face on a single line
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
            PrintSpacesFor3DView(line, totalLines);
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

    static void PrintSpacesFor3DView(int line, int totalLines)
    {// Adds the correct spaces at the beginning of a line to display 3D view of cube
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
    {// Writes on the line the cells of the right face of the cube
        if (line == 0 || line == (8 * cube.SideLength - 2))
            return;
        List<int[]> cells = GetCellsOfRightFace(cube.SideLength, line);
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

    static List<int[]> GetCellsOfRightFace(int SideLength, int line)
    {// Finds the cells of the right face of the cube that are printed on the line
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
    {// Determines which cells are on the the diagonal of the right face
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
    {// Combines two lists by alternating list items starting with the larger list
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

    static void AskToSaveCube(TwistableCube cube)
    {
        if (cube.IsSolved()) return;
        Console.Write("Would you like to save this cube for later 'Y'/'N'? ");
        string command = Console.ReadLine()!;
        if (command.ToUpper() != "Y") return;
        string fileName = $"cube{cube.SideLength.ToString()}.txt";
        if (File.Exists(fileName))
        {
            Console.Write("A save file already exists, do you want to overwrite it 'Y'/'N'? ");
            command = Console.ReadLine()!;
            if (command.ToUpper() != "Y") return;
        }
        Task saveFileTask = SaveCubeToFile(cube);
        return;
    }

    static async Task SaveCubeToFile(BaseCube cube)
    {
        string textToSave = String.Join("", cube.PreviousMoves);
        string fileName = $"cube{cube.SideLength.ToString()}.txt";
        await File.WriteAllTextAsync(fileName, textToSave);
    }

    static TwistableCube LoadCubeFromFile(int cubeSize)
    {
        TwistableCube cube = new TwistableCube(cubeSize);
        string fileName = $"cube{cubeSize.ToString()}.txt";
        string sequenceToProcess = System.IO.File.ReadAllText(fileName);
        cube.ProcessSequence(sequenceToProcess);
        return cube;
    }
}