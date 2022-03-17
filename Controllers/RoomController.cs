using Task.DTOs;
using Task.Models;
using Task.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers;


[ApiController]
[Route("api/room")]

public class RoomController : ControllerBase
{
    private readonly ILogger<RoomController> _logger;
    private readonly IRoomRepository _room;
     private readonly IRoomServiceStaffRepository _roomservicestaff;


    public RoomController(ILogger<RoomController> logger, IRoomRepository room, IRoomServiceStaffRepository roomservicestaff)
    {
        _logger = logger;
        _room = room;
        _roomservicestaff = roomservicestaff;
    }
    [HttpGet]
    public async Task<ActionResult<List<RoomDTO>>> GetAllUsers()
    {
        var usersList = await _room.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    
    [HttpGet("{room_id}")]
    public async Task<ActionResult<RoomDTO>> GetRoomById([FromRoute] long room_id)
    {
        var room  = await _room.GetById(room_id);

        if (room is null)
            return NotFound("No guest found with given room id");
            var dto = room.asDTO;
            dto.RoomServiceStaff = await _room.GetAllForRoom(room.RoomId);


        return Ok(dto);
    }
    
}
