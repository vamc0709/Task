using Task.DTOs;

namespace Task.Models;

public record Guest
{
    public long GuestId { get; set; }
    public string GuestName { get; set; }
    public string GuestDetails { get; set; }
    public GuestDTO asDTO => new GuestDTO
    {
      GuestId = GuestId,
        GuestName = GuestName,
        GuestDetails = GuestDetails, 
    };
}