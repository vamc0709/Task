using Task.DTOs;

namespace Task.Models;

public record RoomServiceStaff
{
    public long StaffId { get; set; }
    public String StaffName { get; set; }
    public String StaffAddress { get; set; }
    public long ContactNumber { get; set; }
    public String Gender { get; set; }

    public RoomServiceStaffDTO asDTO => new RoomServiceStaffDTO
    {
        StaffId = StaffId,
        StaffName = StaffName,
        StaffAddress = StaffAddress,
        ContactNumber = ContactNumber,
        Gender = Gender,
    };
}
