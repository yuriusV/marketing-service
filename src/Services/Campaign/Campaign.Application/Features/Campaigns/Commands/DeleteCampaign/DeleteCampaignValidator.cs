using FluentValidation;
using Campaign.Application.Features.Campaigns.Commands.DeleteCampaign;

namespace Campaign.Application.Features.Campaigns.Commands.CreateCampaign;

public class DeleteCampaignValidator : AbstractValidator<DeleteCampaignCommand>
{
    public DeleteCampaignValidator()
    {
    }
}
