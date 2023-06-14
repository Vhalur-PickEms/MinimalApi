namespace MinimalApi;

public class Team
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string? LogoUrl { get; set; }

    public Team(int? id, string name, string? logoUrl)
    {
        Id = id;
        Name = name;
        LogoUrl = logoUrl;
    }
}
