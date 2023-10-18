namespace ManicTime.CustomTimeline.Sample.Controllers.Server.Model;

public record Timeline(string? Color, Activity[] Activities, Group[]? Groups);