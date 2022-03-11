using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task.DTOs;

public record ScheduleDTO
{
    [JsonPropertyName("stay_schedule_id")]
    public long ScheduleId { get; set; }
    [JsonPropertyName("room_id")]
    public long RoomId { get; set; }
    [JsonPropertyName("guest_id")]
    public long GuestId { get; set; }
    [JsonPropertyName("check_in")]
    public DateTimeOffset CheckIn { get; set; }
    [JsonPropertyName("check_out")]
    public DateTimeOffset CheckOut { get; set; }

}
public record ScheduleCreateDTO
{
    [JsonPropertyName("stay_schedule_id")]


    public long ScheduleId { get; set; }

    [JsonPropertyName("room_id")]


    public long RoomId { get; set; }

    [JsonPropertyName("guest_id")]

    public long GuestId { get; set; }
    [JsonPropertyName("check_in")]

    public DateTimeOffset CheckIn { get; set; }
    [JsonPropertyName("check_out")]

    public DateTimeOffset CheckOut { get; set; }



}

