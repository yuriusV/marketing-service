using Campaign.Application.Features.Campaigns.Commands.CreateCampaign;
using Campaign.Application.Constants.Messages.CampaignMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campaign.Application.Features.Campaigns.Commands.DeleteCampaign;
using Campaign.Application.Features.Templates.Commands.DeleteTemplate;

namespace Campaign.Application.Features.Templates.Commands.DeleteTemplate
{
    public class DeleteTemplateValidator : AbstractValidator<DeleteTemplateCommand>
    {
        public DeleteTemplateValidator()
        {
        }
    }
}
