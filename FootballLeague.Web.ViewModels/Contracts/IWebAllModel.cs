namespace FootballLeague.Web.ViewModels.Contracts
{
    using System.Collections.Generic;

    public interface IWebAllModel<TKey>
    {
        ICollection<IWebDetailsModel<TKey>> Entities { get; set; }
    }
}
