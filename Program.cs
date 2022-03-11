using Task.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IGuestRepository , GuestRepository>();
builder.Services.AddTransient<IRoomRepository ,RoomRepository>();
builder.Services.AddTransient<IRoomServiceStaffRepository, RoomServiceStaffRepository>();
builder.Services.AddTransient<IScheduleRepository ,ScheduleRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
