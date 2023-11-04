using BrowserServerSingnalR;
using BrowserServerSingnalR.Hub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// 将 SignalR 添加到 ASP.NET Core 依赖关系注入。
builder.Services.AddSignalR();
// 跨域策略
builder.Services.AddCors(options =>
{
	options.AddPolicy("CrosPolicy", (builder) =>
	{
		builder.AllowAnyHeader();
		builder.AllowAnyMethod();
		builder.AllowCredentials();
		builder.SetIsOriginAllowed((hosts) => true);
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CrosPolicy");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	// 将 SignalR 添加到 ASP.NET Core 路由系统。
	endpoints.MapHub<MessageHub>("/offers");
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
