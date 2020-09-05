﻿namespace FootballLeague.Web.ViewModels.Games
{
    using System.Collections.Generic;

    using FootballLeague.Web.ViewModels.Contracts;

    public class GamesWebAllModel : IWebAllModel<int>
    {
        public ICollection<IWebDetailsModel<int>> Entities { get; set; } = new List<IWebDetailsModel<int>>();
    }
}
