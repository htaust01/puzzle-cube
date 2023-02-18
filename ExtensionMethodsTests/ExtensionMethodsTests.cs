using PuzzleCube;

namespace ExtensionMethodsTests;

[TestClass]
public class TwoDimensionalArrayExtensionMethodTests
{
    [TestMethod]
    public void GetRow_Returns_Correct_Row()
    {
        // Arrange
        int[,] arr = new int[,] { { 1, 2 }, { 3, 4 } };
        int[] expected = new int[] { 3, 4 };

        // Act
        int[] result = arr.GetRow(1);

        // Assert
        Assert.AreEqual(expected[0], result[0]);
        Assert.AreEqual(expected[1], result[1]);
    }

    [TestMethod]
    public void GetColumn_Returns_Correct_Column()
    {
        // Arrange
        int[,] arr = new int[,] { { 1, 2 }, { 3, 4 } };
        int[] expected = new int[] { 2, 4 };

        // Act
        int[] result = arr.GetColumn(1);

        // Assert
        Assert.AreEqual(expected[0], result[0]);
        Assert.AreEqual(expected[1], result[1]);
    }

    [TestMethod]
    public void AssignArrayToColumn_Assigns_Array_To_Column()
    {
        // Arrange
        int[,] arr = new int[,] { { 1, 2 }, { 3, 4 } };
        int[] arrayToAssign = new int[] { 5, 6 };
        int[] expected = new int[] { 5, 6 };

        // Act
        arr.AssignArrayToColumn(1, arrayToAssign);
        int[] result = arr.GetColumn(1);

        //Assert
        Assert.AreEqual(expected[0], result[0]);
        Assert.AreEqual(expected[1], result[1]);
    }

    [TestMethod]
    public void AssignArrayToRow_Assigns_Array_To_Row()
    {
        // Arrange
        int[,] arr = new int[,] { { 1, 2 }, { 3, 4 } };
        int[] arrayToAssign = new int[] { 5, 6 };
        int[] expected = new int[] { 5, 6 };

        // Act
        arr.AssignArrayToRow(1, arrayToAssign);
        int[] result = arr.GetRow(1);

        //Assert
        Assert.AreEqual(expected[0], result[0]);
        Assert.AreEqual(expected[1], result[1]);
    }

    [TestMethod]
    public void Rotate2DArray_Rotates_2D_Array_90degrees()
    {
        // Arrange
        int[,] arr = new int[,] { { 1, 2 }, { 3, 4 } };
        int[,] expected = new int[,] { { 3, 1 }, { 4, 2 } };

        // Act
        arr.Rotate2DArray(1);

        //Assert
        Assert.AreEqual(expected[0, 0], arr[0, 0]);
        Assert.AreEqual(expected[1, 0], arr[1, 0]);
        Assert.AreEqual(expected[0, 1], arr[0, 1]);
        Assert.AreEqual(expected[1, 1], arr[1, 1]);
    }

    [TestMethod]
    public void Rotate2DArray_Rotates_2D_Array_180degrees()
    {
        // Arrange
        int[,] arr = new int[,] { { 1, 2 }, { 3, 4 } };
        int[,] expected = new int[,] { { 4, 3 }, { 2, 1 } };

        // Act
        arr.Rotate2DArray(2);

        //Assert
        Assert.AreEqual(expected[0, 0], arr[0, 0]);
        Assert.AreEqual(expected[1, 0], arr[1, 0]);
        Assert.AreEqual(expected[0, 1], arr[0, 1]);
        Assert.AreEqual(expected[1, 1], arr[1, 1]);
    }

    [TestMethod]
    public void Rotate2DArray_Rotates_2D_Array_270degrees()
    {
        // Arrange
        int[,] arr = new int[,] { { 1, 2 }, { 3, 4 } };
        int[,] expected = new int[,] { { 2, 4 }, { 1, 3 } };

        // Act
        arr.Rotate2DArray(3);

        //Assert
        Assert.AreEqual(expected[0, 0], arr[0, 0]);
        Assert.AreEqual(expected[1, 0], arr[1, 0]);
        Assert.AreEqual(expected[0, 1], arr[0, 1]);
        Assert.AreEqual(expected[1, 1], arr[1, 1]);
    }

    [TestMethod]
    public void Fill2DArray_Fills_Array_With_FillValue()
    {
        // Arrange
        int[,] arr = new int[2, 2];
        int[,] expected = new int[,] { { 7, 7 }, { 7, 7 } };

        // Act
        arr.Fill2DArray(7);

        //Assert
        Assert.AreEqual(expected[0, 0], arr[0, 0]);
        Assert.AreEqual(expected[1, 0], arr[1, 0]);
        Assert.AreEqual(expected[0, 1], arr[0, 1]);
        Assert.AreEqual(expected[1, 1], arr[1, 1]);
    }

    [TestMethod]
    public void AllCellsEqual_Returns_True_When_All_Cells_Equal()
    {
        // Arrange
        int[,] arr = new int[2, 2] { { 1, 1}, { 1, 1} };

        // Act
        bool result = arr.AllCellsEqual();

        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AllCellsEqual_Returns_False_When_All_Cells_Not_Equal()
    {
        // Arrange
        int[,] arr = new int[2, 2] { { 1, 1 }, { 1, 2 } };

        // Act
        bool result = arr.AllCellsEqual();

        //Assert
        Assert.IsFalse(result);
    }
}
