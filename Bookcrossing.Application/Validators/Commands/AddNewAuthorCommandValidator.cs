using Bookcrossing.Application.Commands.Author;
using FluentValidation;

namespace Bookcrossing.Application.Validators.Commands
{
    public class AddNewAuthorCommandValidator : AbstractValidator<AddNewAuthorCommand>
    {
        public AddNewAuthorCommandValidator()
        {
            RuleFor(x => x.Author.Name).NotEmpty();
            RuleFor(x => x.Author.Birthday).LessThan(System.DateTime.Now);
        }
    }
}
