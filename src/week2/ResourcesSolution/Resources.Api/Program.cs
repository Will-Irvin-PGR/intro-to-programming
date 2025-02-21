using FluentValidation;
using Marten;
using Resources.Api.Resources;
using Resources.Api.Resources.Services;

public class Program {
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        var securityUrl = builder.Configuration.GetConnectionString("security-api") ?? throw new Exception("Need Security API");

        // builder.Services.AddHttpClient(); // If entire API only calls one other server
        builder.Services.AddHttpClient<SecurityApi>(client =>
        {
            client.BaseAddress = new Uri(securityUrl);
        }); // Specifies HttpClient to call the security Api

        // Registers service to find HTTP Client listed above
        builder.Services.AddScoped<INotifytheSecurityReviewTeam>(sp =>
        {
            return sp.GetRequiredService<SecurityApi>();
        });

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddCors(options =>
        {
            // classroom demonstration - probably ok, but check with your local authorities. ;)
            options.AddDefaultPolicy(pol =>
            {
                pol.AllowAnyHeader();
                pol.WithMethods();
                pol.AllowAnyOrigin();
            });
        });

        builder.Services.AddScoped<IValidator<ResourceListItemCreateModel>, ResourceListItemCreateModelValidations>();
        builder.Services.AddScoped<UserInformationProvider, UserInformationProvider>();

        builder.Services.AddMarten(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("resources") ?? throw new Exception("No String Found! Bailing!");
            options.Connection(connectionString);
        });

        var app = builder.Build();

        app.UseCors();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
