using FluentValidation;

namespace MindboxShapes;

/// <summary>
/// Validator for <see cref="Circle"/>
/// </summary>
public class CircleValidator: AbstractValidator<Circle>
{
    /// <summary>
    /// Creates an instance of <see cref="Circle"/> validator.
    /// Makes rule for radius: should be positive.
    /// </summary>
    public CircleValidator()
    {
        RuleFor(circle => circle.Radius).GreaterThan(0).WithMessage("Радиус должен быть положительной величиной");
    }
}
