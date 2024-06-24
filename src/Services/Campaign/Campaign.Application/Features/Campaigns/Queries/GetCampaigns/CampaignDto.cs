﻿namespace Campaign.Application.Features.Campaigns.Queries.GetCampaigns;

public class CampaignDto
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }

    public string? Query { get; set; }

    public TimeSpan? Time { get; set; }

    public int? Priority { get; set; }

    public Guid? TemplateId { get; set; }
}
