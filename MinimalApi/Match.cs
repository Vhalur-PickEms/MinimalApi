namespace MinimalApi;

public class Match
{

    public int? Id { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public DateTime Date { get; set; }
    public int Type { get; set; }
    public string? Winner { get; set; }

    public Match(int? id, string teamOne, string teamTwo, DateTime date, int type, string? winner)
    {
        Id = id;
        TeamOne = teamOne;
        TeamTwo = teamTwo;
        Date = date;
        Type = type;
        Winner = winner;
    }
}

