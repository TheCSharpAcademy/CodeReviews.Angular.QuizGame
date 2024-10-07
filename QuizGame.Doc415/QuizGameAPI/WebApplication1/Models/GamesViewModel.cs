namespace WebApplication1.Models;

public record GamesViewModel
{
    public ICollection<GameInformation> Games { get; set; }
    public int TotalRecords { get; set; }
}
