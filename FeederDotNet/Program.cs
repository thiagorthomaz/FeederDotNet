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
builder.Services.AddTransient<IDataSetRepository, DataSetRepository>();

// services
builder.Services.AddTransient<ICrawlerServices, CrawlerServices>();
builder.Services.AddTransient<ISeedServices, SeedServices>();
builder.Services.AddTransient<IPredictionServices, PredictionServices>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHangfireDashboard("/dashboard");


RecurringJob.RemoveIfExists("CrawlerWorker.Execute");
RecurringJob.AddOrUpdate<CrawlerWorker>("CrawlerWorker.Execute", s => s.Execute(), Cron.Hourly);

RecurringJob.RemoveIfExists("SeederWorker.Execute");
RecurringJob.AddOrUpdate<SeederWorker>("SeederWorker.Execute", s => s.Execute(), Cron.Never);

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
