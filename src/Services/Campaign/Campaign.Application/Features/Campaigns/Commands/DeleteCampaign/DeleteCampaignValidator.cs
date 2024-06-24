using Campaign.Application.Features.Campaigns.Commands.CreateCampaign;
using Campaign.Application.Constants.Messages.CampaignMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campaign.Application.Features.Campaigns.Commands.DeleteCampaign;

namespace Campaign.Application.Features.Campaigns.Commands.CreateCampaign
{
    public class DeleteCampaignValidator : AbstractValidator<DeleteCampaignCommand>
    {
        public DeleteCampaignValidator()
        {
        }
    }
}
