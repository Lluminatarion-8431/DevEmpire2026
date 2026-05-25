var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "DevEmpire2026 API Running!");

app.MapPost("/run-script", async (string scriptName) =>
{
    try
    {
        var scriptPath = Path.Combine("..", "PythonAutomation", "scripts", scriptName);

        if (!File.Exists(scriptPath))
        {
            return Results.BadRequest(new { error = $"Script not found: {scriptName}" });
        }

        var process = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"\"{scriptPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();

        string output = await process.StandardOutput.ReadToEndAsync();
        string error = await process.StandardError.ReadToEndAsync();

        process.WaitForExit();

        return Results.Ok(new
        {
            success = true,
            output = output,
            error = error,
            exitCode = process.ExitCode
        });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { success = false, error = ex.Message });
    }
});

app.Run();