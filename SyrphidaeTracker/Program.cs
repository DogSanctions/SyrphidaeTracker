using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SyrphidaeTracker.Data;
using SyrphidaeTracker.Hubs;
using SyrphidaeTracker.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SyrphidaeTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Components.Authorization;
using SyrphidaeTracker.Areas.Identity;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SyrphidaeTrackerContextConnection") ?? throw new InvalidOperationException("Connection string 'SyrphidaeTrackerContextConnection' not found.");

builder.Services.AddDbContext<SyrphidaeTrackerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SyrphidaeTrackerUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SyrphidaeTrackerContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(); 
builder.Services.AddSignalR();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<SyrphidaeTrackerUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ISyrphidaeTracker, BugService>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    app.MapBlazorHub();
    app.MapHub<ChatHub>("/chathub");
    app.MapHub<CounterHub>("/counterhub");
    app.MapFallbackToPage("/_Host");
});

app.UseAuthentication();

app.Run();
