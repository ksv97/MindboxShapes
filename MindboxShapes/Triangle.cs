using FluentValidation;

namespace MindboxShapes;

/// <summary>
/// The triangle shape.
/// </summary>
public class Triangle : ShapeBase
{
    /// <summary>
    /// Gets the first side of a triangle.
    /// </summary>
    public double Side1 { get; }

    /// <summary>
    /// Gets the second side of a triangle.
    /// </summary>
    public double Side2 { get; }

    /// <summary>
    /// Gets the third side of a triangle.
    /// </summary>
    public double Side3 { get; }

    /// <summary>
    /// Creates an instance of a triangle, performing validation
    /// </summary>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    public Triangle(double side1, double side2, double side3) 
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
        Validate();
    }

    /// <inheritdoc/>    
    public override double Area
    {
        get
        {
            double semiPerimeter = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - Side1) * (semiPerimeter - Side2) * (semiPerimeter - Side3));
        }
    }

    /// <summary>
    /// True if the triangle is right.
    /// </summary>
    public bool IsRight  {
        get
        {
            return IsHypothenuse(Side1, Side2, Side3) 
                || IsHypothenuse(Side2, Side1, Side3) 
                || IsHypothenuse(Side3, Side2, Side1);

            // Whether the side1 parameter is hypothenuse
            bool IsHypothenuse(double side1, double side2, double side3)
            {
                return Math.Pow(side1,2) == Math.Pow(side2,2) + Math.Pow(side3,2);
            }
        }
    }

    /// <inheritdoc/> 
    protected override IValidator Validator => new TriangleValidator();

    /// <inheritdoc/> 
    public override IValidationContext ValidationContext => new ValidationContext<Triangle>(this);
}
