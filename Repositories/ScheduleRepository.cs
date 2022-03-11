using Dapper;
using Task.DTOs;
using Task.Models;

namespace Task.Repositories;

public interface IScheduleRepository
{
    Task<Schedule> Create(Schedule Item);
    Task<bool> Update(Schedule Item);
    Task<bool> Delete(long ScheduleId);
    Task<Schedule> GetById(long ScheduleId);
    Task<List<Schedule>> GetList();
    Task<List<ScheduleDTO>> GetAllForGuest(long GuestId);

}
public class ScheduleRepository : BaseRepository, IScheduleRepository
{
    public ScheduleRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Schedule> Create(Schedule Item)
    {
        var query = $@"INSERT INTO schedule(schedule_id,room_id,guest_id,check_in,check_out)VALUES(@ScheduleId,@RoomId,@GuestId,@CheckIn,@CheckOut) RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Schedule>(query, Item);
            return res;

        }
    }

    public async Task<bool> Delete(long ScheduleId)
    {
        var query = $@"DELETE FROM schedule WHERE schedule_id=@ScheduleId";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, new { ScheduleId });
            return result > 0;

        }
    }

    public async Task<List<ScheduleDTO>> GetAllForGuest(long GuestId)
    {
        var query = $@"SELECT * FROM schedule WHERE guest_id = @GuestId";
        using (var con = NewConnection)
          
          return (await con.QueryAsync<ScheduleDTO>(query, new {GuestId})).AsList();
    }

    public async Task<Schedule> GetById(long ScheduleId)
    {
        var query = $@"SELECT * FROM schedule WHERE schedule_id = @ScheduleId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Schedule>(query, new { ScheduleId });
    }

    public async Task<List<Schedule>> GetList()
    {
        var query = $@"SELECT * FROM schedule ";
        List<Schedule> result;
        using (var con = NewConnection)
            result = (await con.QueryAsync<Schedule>(query)).AsList();
        return result;
    }

    public async Task<bool> Update(Schedule Item)
    {
        var query = $@"UPDATE schedule SET staff_id= @StaffId,guest_id=@Guest_id,room_id=@RoomId,check_in=@ChechIn,check_out=@Check_out WHERE schedule_id = @ScheduleId";
        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }
    
}

    