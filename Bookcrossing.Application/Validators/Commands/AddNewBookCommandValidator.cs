using Bookcrossing.Application.Commands.Book;
using FluentValidation;

namespace Bookcrossing.Application.Validators.Commands
{
    public class AddNewBookCommandValidator : AbstractValidator<AddNewBookCommand>
    {
        public AddNewBookCommandValidator()
        {
            RuleFor(x => x.Book.Name).NotEmpty();
            RuleFor(x => x.Book.Description).NotEmpty();
            RuleFor(x => x.Book.ISBIN).NotEmpty();
        }
    }
}
