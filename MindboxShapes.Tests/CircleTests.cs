namespace MindboxShapes.Tests;

using FluentValidation;
using MindboxShapes;

/// <summary>
/// <see cref="Circle"/> class tests
/// </summary>
[TestClass]
public class CircleTests
{
    /// <summary>
    /// Tests that circle is created when radius is valid.
    /// </summary>
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

    /// <summary>
    /// Tests that when radius of created circle is less than or equal zero, throws <see cref="ValidationException"/>
    /// </summary>
    /// <param name="radius">Radius of circle to be created.</param>
    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void Constructor_RadiusLessThanOrEqualZero_ShouldThrowValidationException(double radius)
    {
        // Arrange
        Action actionWithException = () => new Circle(radius);

        // Act & Assert
        Assert.ThrowsException<ValidationException>(actionWithException);
    }

    /// <summary>
    /// Tests that after creating an object Radius property of <see cref="Circle"/> is properly initialized.
    /// </summary>
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

    /// <summary>
    /// Tests that valid radius is returned by Area property of a <see cref="Circle"/>instance
    /// </summary>
    public void Area_ValidRadius_ShouldReturnCorrectValue()
    {
        double radius = 1;

        Circle circle = new Circle(radius);

        Assert.AreEqual(3.14, circle.Area, 0.001);
    }
}