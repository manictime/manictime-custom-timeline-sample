namespace ManicTime.CustomTimeline.Sample.Controllers.WindowsClient.Model;

public class Activity
{
    public string? DisplayName { get; set; }
    public string? GroupId { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}