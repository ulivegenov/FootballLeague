namespace FootballLeague.Services.Models.Contracts
{
    public interface IServiceDetailsModel<TKey>
    {
        TKey Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
