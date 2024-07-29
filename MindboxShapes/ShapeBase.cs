using FluentValidation;

namespace MindboxShapes;

/// <summary>
/// Base class for shapes
/// </summary>
public abstract class ShapeBase : IShape
{    
    /// <inheritdoc/>  
    public abstract double Area { get; }

    /// <summary>
    /// Validator for the current shape.
    /// </summary>
    protected abstract IValidator Validator { get; }

    /// <summary>
    /// Validation context for the current shape.
    /// </summary>
    public abstract IValidationContext ValidationContext{ get; }

    /// <summary>
    /// Validates an object or throws a ValidationException.
    /// </summary>
    protected void Validate()
    {
        var validationResult = Validator.Validate(ValidationContext);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }
}
