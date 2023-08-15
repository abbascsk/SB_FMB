using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SB_FMB_API.Services;
using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons;
using SB_FMB_Domain.Data;
using SB_FMB_Domain.Repositories;
using SB_FMB_Domain.Repositories.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddDbContext<FMBDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = false,
		ValidIssuer = builder.Configuration["JWT:Issuer"],
		ValidAudience = builder.Configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(key),
	};
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IPasswordHasher), typeof(PasswordHasher));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IMuminRepository), typeof(MuminRepository));
builder.Services.AddScoped(typeof(IThaliRepository), typeof(ThaliRepository));
builder.Services.AddScoped(typeof(IThaliItemRepository), typeof(ThaliItemRepository));
builder.Services.AddScoped(typeof(IFeedbackRepository), typeof(FeedbackRepository));
builder.Services.AddScoped(typeof(IThaliStopRequestRepository), typeof(ThaliStopRequestRepository));

builder.Services.AddScoped(typeof(IJwtManagerService), typeof(JwtManagerService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IMuminService), typeof(MuminService));
builder.Services.AddScoped(typeof(IThaliService), typeof(ThaliService));

//builder.Services.AddHostedService<SampleDataPopulationService>();

var app = builder.Build();

app.UseCors(x => {
	x.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader();
});

using (var scope = app.Services.CreateScope())
{
    using (var context = scope.ServiceProvider.GetService<FMBDbContext>())
        context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
