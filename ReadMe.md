# Puzzle Cube

## About
PuzzleCube is a console application that simulates a twistable cube puzzle, like a Rubik's cube. It allows you to manipulate a puzzle cube from a 2x2x2 cube up to a 9x9x9 cube. You can rotate the cube along the x axis, y axis, and z axis. You can twist any single layer of the cube by entering the face and layer you would like to twist. The faces are front(F), back(B), up(U), down(D), right(R), and left(L). If no layer is entered it defaults to the first layer. You can also input sequences of moves.
Example for 3x3x3 cube: R2
This corresponds to the second layer of the right face of the cube and twists that layer one quarter turn clockwise relative to the right face.
Example sequence: U1L1U1U1U1R1U1 or ULUUURU
The cube is displayed with color as a 3D model of a cube, or a 2D model. You can toggle between 3D and 2D by typing 'V'.
There is also a cheat/debug mode that shows you all the previous moves from the last solved position. Use the Konami code to access this mode. From there you can enter the moves backwards so they occur in fours to solve the cube.
A cube can be saved for later if desired by typing SAVE. This saves the previous moves performed on the cube to a text file so the cube can be restored.

## Features
- Implement a "master loop"
- Create an additional class that inherits properties from its parent
- Create a list, populate the list, and retrieve values from the list
- Create 3 or more unit tests
- Read/Write data from/to an external file and use the data