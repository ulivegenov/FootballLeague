namespace FootballLeague.Web.ViewModels.Teams
{
    using FootballLeague.Web.ViewModels.Contracts;
    using System.Collections.Generic;

    public class TeamWebAllModel : IWebAllModel<int>
    {
        public ICollection<IWebDetailsModel<int>> Entities { get; set; } = new List<IWebDetailsModel<int>>();
    }
}
