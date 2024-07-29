using FluentValidation;

namespace MindboxShapes;

/// <summary>
/// The circle shape.
/// </summary>
public class Circle : ShapeBase
{
    /// <summary>
    /// Gets the radius of a circle.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Creates an instance of circle, performing validation
    /// </summary>
    /// <param name="radius">Radius of a circle</param>
    public Circle(double radius): base()
    {
        Radius = radius;
        Validate();
    }

    /// <inheritdoc/>    
    public override double Area => Math.PI * Radius * Radius;

    /// <inheritdoc/>    
    protected override void Validate()
    {
        CircleValidator validationRules = new CircleValidator();
        validationRules.ValidateAndThrow(this);
    }
}
