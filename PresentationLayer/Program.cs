var builder = WebApplication.CreateBuilder(args); // Create a builder for the web application using command-line arguments.

// Add services to the container.
builder.Services.AddControllersWithViews()        // Register MVC controllers with views into the service container.
    .AddRazorRuntimeCompilation();                // Enable runtime compilation of Razor views for real-time updates during development.

var app = builder.Build();                        // Build the application pipeline.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())             // Check if the environment is not Development.
{
    app.UseExceptionHandler("/Home/Error");       // Use a custom error page for handling exceptions.
    app.UseHsts();                                // Enable HTTP Strict Transport Security for secure connections.
}

app.UseHttpsRedirection();                        // Redirect HTTP requests to HTTPS.
app.UseStaticFiles();                             // Enable serving static files from the wwwroot folder.

app.UseRouting();                                 // Add routing middleware to process incoming requests.

app.UseAuthorization();                           // Add authorization middleware (placeholder if authorization is implemented later).

app.MapControllerRoute(                           // Define the default route pattern for controller actions.
    name: "default",
    pattern: "{controller=Image}/{action=Upload}/{id?}"); // Set default controller to 'Image' and action to 'Upload'.

app.Run();                                        // Run the application.
