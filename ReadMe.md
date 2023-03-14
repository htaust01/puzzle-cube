# Puzzle Cube

## About
PuzzleCube is a console application that simulates a twistable cube puzzle, like a Rubik's cube. It allows you to manipulate a puzzle cube from a 2x2x2 cube up to a 9x9x9 cube. You can rotate the cube along the x axis, y axis, and z axis. You can twist any single layer of the cube by entering the face and layer you would like to twist. The faces are front(F), back(B), up(U), down(D), right(R), and left(L). If no layer is entered it defaults to the first layer. You can also input sequences of moves.

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
- Implement a "master loop"
- Create an additional class that inherits properties from its parent
- Create a list, populate the list, and retrieve values from the list
- Create 3 or more unit tests
- Read/Write data from/to an external file and use the data