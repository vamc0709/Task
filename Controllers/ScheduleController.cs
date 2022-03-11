using Task.DTOs;
using Task.Models;
using Task.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers;


[ApiController]
[Route("Api/ScheduleController")]

public class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;
    private readonly IScheduleRepository _Schedule;

    public ScheduleController(ILogger<ScheduleController> logger, IScheduleRepository Schedule)
    {
        _logger = logger;
        _Schedule = Schedule;
    }
    [HttpGet]
    public async Task<ActionResult<List<ScheduleDTO>>> GetAllUsers()
    {
        var usersList = await _Schedule.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpPost]
    public async Task<ActionResult<ScheduleDTO>> CreateSchedule([FromBody] ScheduleCreateDTO Data)
    {
        var toCreateSchedule = new Schedule
        {
            ScheduleId = Data.ScheduleId,
            RoomId = Data.RoomId,
            GuestId = Data.GuestId,
            CheckIn = Data.CheckIn,
            CheckOut = Data.CheckOut
        };
        var createdRoom = await _Schedule.Create(toCreateSchedule);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpGet("{stay_schedule_id}")]
    public async Task<ActionResult<ScheduleDTO>> GetUserById([FromRoute] long stay_schedule_id)
    {
        var user = await _Schedule.GetById(stay_schedule_id);

        if (user is null)
            return NotFound("No user found with given stay schedule id");

        return Ok(user.asDTO);
    }
    

    [HttpDelete("{stay_schedule_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long stay_schedule_id)
    {
        var existing = await _Schedule.GetById(stay_schedule_id);
        if (existing is null)
            return NotFound("No user found with given stay schedule id");

        var didDelete = await _Schedule.Delete(stay_schedule_id);

        return NoContent();
    }
}
