using FluentValidation;
using System.Reflection.Metadata.Ecma335;

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
    /// Creates an instance of <see cref="Circle"/>, performing validation
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
    protected override IValidator Validator => new CircleValidator();

    /// <inheritdoc/> 
    public override IValidationContext ValidationContext => new ValidationContext<Circle>(this);
}
