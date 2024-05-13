using System.Text.Json.Serialization;
using SignalR_Poc;
using SignalR_Poc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISocketService, SocketService>();

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<SignalRHub>("chat-hub");

app.UseRouting();

app.MapControllers();

app.Run();

/*

Connection Text For Postman --> {"protocol":"json","version":1}
Sending Message Text For Postman --> {"arguments":["Test message"],"invocationId":"0","target":"SendMessage","type":1}

*/