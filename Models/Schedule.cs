using Task.DTOs;

namespace Task.Models;


  public record Schedule
  {   
      public long ScheduleId { get; set; }
    public long RoomId { get; set; }
    public long GuestId { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }

 public ScheduleDTO asDTO => new ScheduleDTO
    {
       ScheduleId =ScheduleId,
       RoomId =RoomId,
       GuestId =GuestId,
       CheckIn =CheckIn,
       CheckOut =CheckOut,
    };


  } 