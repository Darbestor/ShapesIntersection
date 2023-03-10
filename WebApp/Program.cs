using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(30); });
builder.Services.AddMemoryCache();
builder.Services.AddTransient<ImageBuilder>();
builder.Services.AddTransient<ImageGeneratorService>();
builder.Services.AddSingleton<ShapesMapper>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ShapesSessionRepository>();

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

app.UseAuthorization();

app.UseSession();
app.MapRazorPages();

app.Run();