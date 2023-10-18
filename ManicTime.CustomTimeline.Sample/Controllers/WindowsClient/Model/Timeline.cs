namespace ManicTime.CustomTimeline.Sample.Controllers.WindowsClient.Model;

public class Timeline
{
    public string? Color { get; set; }
    public required Activity[] Activities { get; set; }
    public Group[]? Groups { get; set; }
}