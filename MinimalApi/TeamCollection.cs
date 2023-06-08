using Microsoft.EntityFrameworkCore;

namespace MinimalApi;

public class TeamCollection : ITeamCollection
{
    private readonly DataContext _dbContext;

    public TeamCollection(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Team>> GetAll()
    {
        return await _dbContext.Team.ToListAsync();
    }
}
