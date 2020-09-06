namespace FootballLeague.Services.Models.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TeamServiceAllModel
    {
        ICollection<TeamServiceDetailsModel> Teams = new List<TeamServiceDetailsModel>();
    }
}
