using System.ComponentModel.DataAnnotations;
using ManicTime.CustomTimeline.Sample.Controllers.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace ManicTime.CustomTimeline.Sample.Controllers.Server;

[ApiController]
[Route("/server")]
[Produces("application/json")]
public class ServerController : ControllerBase
{
    [HttpGet("time-only")]
    public ActionResult<Timeline> OnlyTimes([Required] DateTime fromTime, [Required] DateTime toTime)
    {
        if (fromTime >= toTime)
        {
            ModelState.AddModelError(nameof(toTime), "toTime must be greater than fromTime");
            return ValidationProblem();
        }

        return new Timeline(
            Color: null,
            Activities: new Activity[]
            {
                new(Name: null, GroupId: null, fromTime, toTime)
            },
            Groups: null);
    }

    [HttpGet("times-and-title")]
    public ActionResult<Timeline> TimesAndTitle([Required] DateTime fromTime, [Required] DateTime toTime)
    {
        if (fromTime >= toTime)
        {
            ModelState.AddModelError(nameof(toTime), "toTime must be greater than fromTime");
            return ValidationProblem();
        }

        return new Timeline(
            Color: "0080FF",
            Activities: new Activity[]
            {
                new(Name: "My activity", GroupId: null, fromTime, toTime)
            },
            Groups: null);
    }

    [HttpGet("activities-and-groups")]
    public ActionResult<Timeline> ActivitiesAndGroups([Required] DateTime fromTime, [Required] DateTime toTime)
    {
        if (fromTime >= toTime)
        {
            ModelState.AddModelError(nameof(toTime), "toTime must be greater than fromTime");
            return ValidationProblem();
        }

        return new Timeline(
            Color: null,
            Activities: new Activity[]
            {
                new(Name: "My activity", GroupId: "1", fromTime, toTime)
            },
            Groups: new Group[]
            {
                new(GroupId: "1", Name: "My group", Color: "0080FF")
            });
    }
}