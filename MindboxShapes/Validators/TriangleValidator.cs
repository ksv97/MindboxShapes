using FluentValidation;

namespace MindboxShapes;
internal class TriangleValidator: AbstractValidator<Triangle>
{
    public TriangleValidator()
    {
        RuleFor(triangle => triangle.Side1).GreaterThan(0).WithMessage("Сторона 1 должна быть положительным числом.");
        RuleFor(triangle => triangle.Side2).GreaterThan(0).WithMessage("Сторона 2 должна быть положительным числом.");
        RuleFor(triangle => triangle.Side3).GreaterThan(0).WithMessage("Сторона 3 должна быть положительным числом.");

        RuleFor(triangle => triangle).Must((triangle) =>            
        triangle.Side1 + triangle.Side2 > triangle.Side3 &&
        triangle.Side2 + triangle.Side3 > triangle.Side1 &&
        triangle.Side1 + triangle.Side3 > triangle.Side2)
            .WithMessage("Невозможно составить треугольник с такими сторонами. Каждая из сторон должна быть меньше суммы двух других.");        
    }
}
