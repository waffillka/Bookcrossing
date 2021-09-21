using Bookcrossing.Application.Commands.Author;
using FluentValidation;

namespace Bookcrossing.Application.Validators.Commands
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Author.Name).NotEmpty();
            RuleFor(x => x.Author.Birthday).LessThan(System.DateTime.Now);
        }
    }
}
