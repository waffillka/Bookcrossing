using Bookcrossing.Application.Commands.Publisher;
using FluentValidation;

namespace Bookcrossing.Application.Validators.Commands
{
    public class AddNewPublisherCommandValidator : AbstractValidator<AddNewPublisherCommand>
    {
        public AddNewPublisherCommandValidator()
        {
            RuleFor(x => x.Publisher.Name).NotEmpty();
        }
    }
}
