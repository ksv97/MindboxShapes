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
    /// Validates an object or throws a ValidationException.
    /// </summary>
    protected abstract void Validate();
}
