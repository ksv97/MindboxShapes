using FluentValidation;

namespace MindboxShapes.Tests;

/// <summary>
/// Tests for <see cref="Triangle"/> class
/// </summary>
[TestClass]
public class TriangleTests
{
    /// <summary>
    /// Tests that initializing a <see cref="Triangle"/> with valid sides properly creates instance.
    /// </summary>
    [TestMethod]
    public void Constructor_ValidSides_ShouldCreateTriangle()
    {
        //Arrange
        double side1 = 3;
        double side2 = 4;
        double side3 = 5;

        // Act
        Triangle triangle = new Triangle(side1, side2, side3);

        // Assert
        Assert.IsNotNull(triangle);
    }

    /// <summary>
    /// Test that, when sides of <see cref="Triangle"/> are negative or zero, <see cref="ValidationException"/> is thrown.
    /// </summary>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    [TestMethod]
    [DataRow(3,4,0)]
    [DataRow(3, 0, 4)]
    [DataRow(0, 3, 4)]
    [DataRow(-1, 3, 4)]
    [DataRow(3, -1, 4)]
    [DataRow(3, 4, -1)]
    public void Constructor_SideIsNotPositive_ShouldThrowValidationException(double side1, double side2, double side3)
    {
        Assert.ThrowsException<ValidationException>(() => new Triangle(side1, side2, side3));
    }

    /// <summary>
    /// Tests that, if one side is more than or equal to sum of others, throws <see cref="ValidationException"/>
    /// This is because the rule for triangle: each side should be less than sum of others
    /// </summary>
    /// <param name="side1"></param>
    /// <param name="side2"></param>
    /// <param name="side3"></param>
    [TestMethod]
    [DataRow(3, 4, 7)]
    [DataRow(3, 7, 4)]
    [DataRow(7, 3, 4)]
    [DataRow(100, 1, 1)]
    [DataRow(1, 1, 100)]
    [DataRow(1, 100, 1)]
    public void Constructor_SideMoreThanOrEqualToSumOfOthers_ShouldThrowValidationException(double side1, double side2, double side3)
    {
        Assert.ThrowsException<ValidationException>(() => new Triangle(side1, side2, side3));
    }

    /// <summary>
    /// Tests that property for each side of <see cref="Triangle"/> return values initialized in Constructor
    /// </summary>
    [TestMethod]
    public void GetSides_AfterCreatingObject_ShouldReturnValuesInitializedInConstructor()
    {
        // Arrange
        Triangle triangle = new Triangle(3, 4, 5);

        // Act
        double side1 = triangle.Side1;
        double side2 = triangle.Side2;
        double side3 = triangle.Side3;

        //Assert
        Assert.AreEqual(3, side1);
        Assert.AreEqual(4, side2);
        Assert.AreEqual(5, side3);
    }

    /// <summary>
    /// Tests that Area returns correct value for <see cref="Triangle"/> instance.
    /// </summary>
    [TestMethod]
    public void Area_ValidTriangle_ShouldReturnCorrectValue()
    {
        // Arrange
        Triangle triangle = new Triangle(3,4,5);

        // Act
        double area = triangle.Area;

        // Assert
        Assert.AreEqual(6, area);
    }

    /// <summary>
    /// Tests that true is returned by IsRight method, when the <see cref="Triangle"/> is right.
    /// </summary>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    [TestMethod]
    [DataRow(3,4,5)]
    [DataRow(3, 5, 4)]
    [DataRow(5, 4, 3)]
    public void IsRight_RightTriangle_ReturnsTrue(double side1, double side2, double side3)
    {
        // Arrange
        Triangle triangle = new Triangle(side1, side2, side3);

        // Act
        bool isRight = triangle.IsRight;

        // Assert
        Assert.IsTrue(isRight);
    }

    /// <summary>
    /// Tests that false is returned by IsRight method, when the <see cref="Triangle"/> is right.
    /// </summary>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    [TestMethod]
    [DataRow(1,1,1)]
    [DataRow(2, 2, 3)]
    [DataRow(2, 3, 2)]
    [DataRow(3, 2, 2)]
    [DataRow(3, 4, 6)]
    [DataRow(3, 6, 4)]
    [DataRow(6, 4, 3)]
    public void IsRight_NotRightTriangle_ReturnsFalse(double side1, double side2, double side3)
    {
        // Arrange
        Triangle triangle = new Triangle(side1, side2, side3);

        // Act
        bool isRight = triangle.IsRight;

        // Assert
        Assert.IsFalse(isRight);
    }
}
