using FluentValidation;

namespace Campaign.Application.Features.Campaigns.Commands.CreateCampaign;

public class CreateCampaignValidator : AbstractValidator<CreateCampaignCommand>
{
    private const int MaxNameLength = 256;

    public CreateCampaignValidator()
    {
        RuleFor(x => x.TemplateId)
            .NotEmpty();

        RuleFor(x => x.Query)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(MaxNameLength);

        RuleFor(x => x.Priority)
            .NotEmpty().Must(x => x > 0);

        RuleFor(x => x.Time)
            .NotEmpty();
    }
}
