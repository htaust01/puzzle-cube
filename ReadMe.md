# Puzzle Cube

## About
PuzzleCube is a console application, developed with C# and .NET 7, that simulates a twistable cube puzzle, like a Rubik's cube. It allows you to manipulate a puzzle cube from a 2x2x2 cube up to a 9x9x9 cube. You can rotate the cube along the x axis, y axis, and z axis. You can twist any single layer of the cube by entering the face and layer you would like to twist. The faces are front(F), back(B), up(U), down(D), right(R), and left(L). If no layer is entered it defaults to the first layer. You can also input sequences of moves.

Example for 3x3x3 cube: R2

This corresponds to the second layer of the right face of the cube and twists that layer one quarter turn clockwise relative to the right face.

Example sequence: U1L1U1U1U1R1U1 or ULUUURU

The cube is displayed with color as a 3D model of a cube, or a 2D model. You can toggle between 3D and 2D by typing 'V'.

There is also a cheat/debug mode that shows you all the previous moves from the last solved position. Use the Konami code to access this mode. From there you can enter the moves backwards so they occur in fours to solve the cube.

An unsolved cube can be saved for later if desired by exiting the program or typing MENU to change cube size. You will then be asked if you would like to save. This saves the previous moves performed on the cube to a text file so the cube can be restored.

If you need help with commands and what they do you type HELP after you have selected cube size and the program displays the contents of help.txt in the console window.

## How to Use
You begin with a title screen where you have to hit enter. You are then asked to enter the size of the cube you would like to play with. If there is a saved cube file you will be asked if you want to restore that cube. If there is no file or you do not wish to restore the cube you will be given a cube that has been randomly twisted. From here you can twist any face and layer clockwise by entering commands that consist of the face you wish to turn and which layer of that face. The faces are Up, Down, Right, Left, Front, and Back and you type the first letter of the face followed by a number representing the layer. If no layer is mentioned it defaults to the first layer. You can also enter the Konami code(UUDDLRLRBASTART) and all previous moves performed on the cube from its last solved state will be displayed. You can use these moves to solve the cube by entering corresponding moves that add up to four in reverse order. If you wish to exit you can type Q at any time to close the program. If you want to change cube size you can type MENU. If you type menu or exit the program while the cube is in an unsolved state you will be given the option to save the cube for later. Each cube size can have one saved cube. If a saved cube of that size exists you will be warned that you will overwrite the previous saved file if you want to save your current cube.

## Features
- Implement a "master loop" : A master loop is implemented in the Main method where there is a while(true) loop that makes a call to MakePuzzleCube and PlayWithCube. The MakePuzzleCube method makes a call to the GetCubeSizeFromUser method that contains a do while loop that exits the app if the user inputs an exit string. Similarly the PlayWithCube method implements a while loop that exits the app if the user inputs an exit string.
- Create an additional class that inherits properties from its parent : There is a parent class, BaseCube, that creates an object with 6 faces that are 2D arrays of numbers. BaseCube has methods that allow the cube to be rotated around the x axis, y axis, and z axis. It also contains methods to display the cube in the console either as a 3D view or as a 2D net of the cube. There is a child class, TwistableCube, that inherits from BaseCube. TwistableCube has methods that allow the faces of the cube and their layers to be twisted like in a Rubik's cube. It also contains a method, ProcessSequence, which is an override of the same method in BaseCube as it has a larger PossibleMoves list. 
- Create a list, populate the list, and retrieve values from the list : Lists are used in several places in the program. In particular the BaseCube class has a property PreviousMoves that is a list of all the previous twists or rotations that have been performed on the cube since the last time the cube was in a solved state.
- Create 3 or more unit tests : The BaseCube and TwistableCube class contain several properties that are 2D arrays. In order to make working with these 2D arrays easier several extension methods for 2D arrays were created. Several unit tests were created to verify these methods function properly. There were also a few unit tests created to verify that some of the BaseCube methods function correctly.
- Read/Write data from/to an external file and use the data : The method SaveCubeToFile writes the PreviousMoves property of the cube to a text file. The method LoadCubeFromFile reads a string from a text file and then uses the ProcessSequence method to turn that file into a cube.