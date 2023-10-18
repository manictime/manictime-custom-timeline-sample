namespace ManicTime.CustomTimeline.Sample.Controllers.Server.Model;

public record Activity(string? Name, string? GroupId, DateTimeOffset StartTime, DateTimeOffset EndTime);