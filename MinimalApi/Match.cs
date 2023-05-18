namespace MinimalApi;

public class Match
{
    public int? Id { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public DateTime Date { get; set; }
    public int Type { get; set; }
    public string? Winner { get; set; }
}
