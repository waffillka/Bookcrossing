using Bookcrossing.Application.Commands.Publisher;
using FluentValidation;

namespace Bookcrossing.Application.Validators.Commands
{
    public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
    {
        public UpdatePublisherCommandValidator()    
        {
            RuleFor(x => x.Publisher.Name).NotEmpty();
        }
    }
}
