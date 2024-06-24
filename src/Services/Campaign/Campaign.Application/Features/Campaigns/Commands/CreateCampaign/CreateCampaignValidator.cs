﻿using FluentValidation;

namespace Campaign.Application.Features.Campaigns.Commands.CreateCampaign;

public class CreateCampaignValidator : AbstractValidator<CreateCampaignCommand>
{
    public CreateCampaignValidator()
    {
        RuleFor(x => x.TemplateId)
            .NotEmpty();

        RuleFor(x => x.Query)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(x => x.Priority)
            .NotEmpty().Must(x => x > 0);

        RuleFor(x => x.Time)
            .NotEmpty();
    }
}
