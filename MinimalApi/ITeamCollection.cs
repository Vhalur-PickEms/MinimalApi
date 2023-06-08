namespace MinimalApi;

public interface ITeamCollection
{
    Task<List<Team>> GetAll();
}
