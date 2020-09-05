namespace FootballLeague.Web.ViewModels.Contracts
{
    public interface IWebDetailsModel<TKey>
    {
        TKey Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
