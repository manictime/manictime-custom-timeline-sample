using System.ComponentModel.DataAnnotations;
using ManicTime.CustomTimeline.Sample.Controllers.WindowsClient.Model;
using Microsoft.AspNetCore.Mvc;

namespace ManicTime.CustomTimeline.Sample.Controllers.WindowsClient;

[ApiController]
[Route("/windows-client")]
[Produces("application/xml")]
public class WindowsClientController : ControllerBase
{
    [HttpGet("time-only")]
    public ActionResult<Timeline> OnlyTimes([Required] DateTime fromTime, [Required] DateTime toTime)
    {
        if (fromTime >= toTime)
        {
            ModelState.AddModelError(nameof(toTime), "toTime must be greater than fromTime");
            return ValidationProblem();
        }

        return new Timeline
        {
            Activities = new Activity[]
            {
                new()
                {
                    StartTime = fromTime,
                    EndTime = toTime
                }
            }
        };
    }

    [HttpGet("times-and-title")]
    public ActionResult<Timeline> TimesAndTitle([Required] DateTime fromTime, [Required] DateTime toTime)
    {
        if (fromTime >= toTime)
        {
            ModelState.AddModelError(nameof(toTime), "toTime must be greater than fromTime");
            return ValidationProblem();
        }

        return new Timeline
        {
            Color = "0080FF",
            Activities = new Activity[]
            {
                new()
                {
                    DisplayName = "My activity",
                    StartTime = fromTime,
                    EndTime = toTime
                }
            }
        };
    }

    [HttpGet("activities-and-groups")]
    public ActionResult<Timeline> ActivitiesAndGroups([Required] DateTime fromTime, [Required] DateTime toTime)
    {
        if (fromTime >= toTime)
        {
            ModelState.AddModelError(nameof(toTime), "toTime must be greater than fromTime");
            return ValidationProblem();
        }

        return new Timeline
        {
            Color = null,
            Activities = new Activity[]
            {
                new()
                {
                    DisplayName = "My activity",
                    GroupId = "1",
                    StartTime = fromTime,
                    EndTime = toTime
                }
            },
            Groups = new Group[]
            {
                new()
                {
                    GroupId = "1",
                    DisplayName = "My group",
                    DisplayKey = "MyGroup",
                    Color = "0080FF"
                }
            }
        };
    }
}