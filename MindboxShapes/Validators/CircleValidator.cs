using FluentValidation;

namespace MindboxShapes;
public class CircleValidator: AbstractValidator<Circle>
{
    public CircleValidator()
    {
        RuleFor(circle => circle.Radius).GreaterThan(0).WithMessage("Радиус должен быть положительной величиной");
    }
}
