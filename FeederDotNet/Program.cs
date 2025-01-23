using FeederDotNet.DAL;
using FeederDotNet.Data;
using FeederDotNet.Services;
using FeederDotNet.Workers;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHangfire(configuration => configuration
.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UseSqlServerStorage(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDbContext<SqlServerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddHangfireServer();



// repository
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

// services
builder.Services.AddTransient<ICrawlerServices, CrawlerServices>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHangfireDashboard("/dashboard");


RecurringJob.RemoveIfExists("CrawlerWroker.Execute");
RecurringJob.AddOrUpdate<CrawlerWroker>("CrawlerWroker.Execute", s => s.Execute(), Cron.Hourly);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
