using distributed_calculator_worker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

Emmersion.Http.DependencyInjectionConfig.ConfigureServices(builder.Services);
builder.Services.AddTransient<IRegistrationWorkflow, RegistrationWorkflow>();
builder.Services.AddTransient<ICreateJobWorkflow, CreateJobWorkflow>();
var jobRepository = new InMemoryJobRepository();
builder.Services.AddTransient<IJobRepository>(_ => jobRepository);
builder.Services.AddSingleton<IJobProcessor, JobProcessor>();

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

app.MapRazorPages();
app.MapControllers();

app.Run();
