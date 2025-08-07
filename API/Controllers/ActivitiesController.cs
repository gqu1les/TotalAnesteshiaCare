using Application.Activities.Commands;
using Application.TotalAnesthesia.Commands;
using Application.TotalAnesthesia.DTO;
using Application.TotalAnesthesia.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace API.Controllers;

public class ActivitiesController : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activityDto)
    {
        return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }));
    }

    [HttpPut] 
    public async Task<ActionResult> EditActivity(EditActivityDTO activity)
    {
       return HandleResult(await Mediator.Send(new EditActivity.Command { ActivityDTO = activity }));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
    }
}

