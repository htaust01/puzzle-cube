using System.Data.Common;
using System.Drawing;
using PuzzleCube;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    public static ConsoleColor initialBackgroundColor = Console.BackgroundColor;
    public static string[] exitStrings = { "Q", "QUIT", "EXIT", "STOP", "END" };

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
        int cubeSize = GetCubeSizeFromUser();
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

    static int GetCubeSizeFromUser()
    {
        string[] possibleCubeSizes = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string cubeSize;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Enter a number between '1' and '9' to choose the size cube you would like to solve");
            Console.WriteLine("For example, enter '3' if you would like to play with a 3x3x3 cube");
            Console.WriteLine("Note: It is difficult to play with the larger sizes as they don't fit on the screen well");
            Console.WriteLine("Enter 'Q' to quit");
            Console.Write("Size: ");
            cubeSize = Console.ReadLine()!;
            if (exitStrings.Contains(cubeSize.ToUpper()))
                Environment.Exit(0);
            if (!possibleCubeSizes.Contains(cubeSize))
                Console.WriteLine("You have entered an invalid size");
        } while (!possibleCubeSizes.Contains(cubeSize));
        return int.Parse(cubeSize);
    }

    static string GetCommandFromUser()
    {
        Console.WriteLine("Enter 'X', 'Y', or 'Z' to rotate the cube clockwise a quarter turn around that axis.");
        Console.WriteLine("Enter 'U', 'D', 'R', 'L', 'F', or 'B' to twist that face of the cube clockwise a quarter turn");
        Console.WriteLine("Followed by a number corresponding to the layer you would like to twist.");
        Console.WriteLine("Enter 'MENU' to change cube size, 'HELP' for more information on the commands, or 'Q' to quit");
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
                cube.Display3D();
            else
                cube.Display2D();
            if (cheatModeActive)
                cube.PrintPreviousMoves();
            if (cube.IsSolved())
                Console.WriteLine("You have solved the Cube!\n");
            command = GetCommandFromUser();
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
                Console.Clear();
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