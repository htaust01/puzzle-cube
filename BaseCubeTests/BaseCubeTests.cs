using PuzzleCube;

namespace BaseCubeTests;

[TestClass]
public class BaseCubeTests
{
    [TestMethod]
    public void BaseCube_Constructs_Proper_Cube()
    {
        // Arrange
        BaseCube cube = new BaseCube(1);
        int[,] expectedUp = { { 1 } };
        int[,] expectedDown = { { 6 } };
        int[,] expectedRight = { { 2 } };
        int[,] expectedLeft = { { 5 } };
        int[,] expectedFront = { { 3 } };
        int[,] expectedBack = { { 4 } };

        // Act


        // Assert
        Assert.AreEqual(expectedUp[0, 0], cube.Up[0, 0]);
        Assert.AreEqual(expectedDown[0, 0], cube.Down[0, 0]);
        Assert.AreEqual(expectedRight[0, 0], cube.Right[0, 0]);
        Assert.AreEqual(expectedLeft[0, 0], cube.Left[0, 0]);
        Assert.AreEqual(expectedFront[0, 0], cube.Front[0, 0]);
        Assert.AreEqual(expectedBack[0, 0], cube.Back[0, 0]);
    }

    [TestMethod]
    public void IsSolved_Returns_True_If_Solved()
    {
        // Arrange
        BaseCube cube = new BaseCube(2);
        bool expected = true;

        // Act
        bool result = cube.IsSolved();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsSolved_Returns_False_If_Not_Solved()
    {
        // Arrange
        BaseCube cube = new BaseCube(2);
        cube.Up = new int[,] { { 1, 2}, { 3, 4} };
        bool expected = false;

        // Act
        bool result = cube.IsSolved();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
