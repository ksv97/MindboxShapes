namespace MindboxShapes.Tests;

using FluentValidation;
using MindboxShapes;

[TestClass]
public class CircleTests
{
    [TestMethod]
    public void Constructor_ValidRadius_ShouldCreateCircle()
    {
        // Arrange
        int radius = 10;

        // Act
        Circle circle = new Circle(radius);

        // Assert
        Assert.IsNotNull(circle);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void Constructor_RadiusLessThanOrEqualZero_ShouldThrowArgumentOutOfRangeException(double radius)
    {
        // Arrange
        Action actionWithException = () => new Circle(radius);

        // Act & Assert
        Assert.ThrowsException<ValidationException>(actionWithException);
    }

    [TestMethod]
    public void GetRadius_AfterCreatingObject_ShouldReturnRadiusInitializedInConstructor()
    {
        // Arrange
        Circle circle = new Circle(10);

        // Act
        double radius = circle.Radius;

        // Assert        
        Assert.AreEqual(10, circle.Radius);
    }

    public void Area_ValidRadius_ShouldReturnCorrectValue()
    {
        double radius = 1;

        Circle circle = new Circle(radius);

        Assert.AreEqual(3.14, circle.Area, 0.001);
    }
}