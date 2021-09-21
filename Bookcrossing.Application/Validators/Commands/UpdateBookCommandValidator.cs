using Bookcrossing.Application.Commands.Book;
using FluentValidation;

namespace Bookcrossing.Application.Validators.Commands
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Book.Name).NotEmpty();
            RuleFor(x => x.Book.Description).NotEmpty();
            RuleFor(x => x.Book.ISBIN).NotEmpty();
        }
    }
}
